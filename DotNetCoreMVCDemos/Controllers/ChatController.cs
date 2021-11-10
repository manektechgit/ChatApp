using DotNetCoreMVCDemos.Hubs;
using DotNetCoreMVCDemos.Models;
using DotNetCoreMVCDemos.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Controllers
{
    public class ChatController : Controller
    {
        public readonly ChatRepository ChatRepo = new ChatRepository();
        public readonly ISession session;
        private readonly IHubContext<ChatHub> _chatHub;
        private readonly IHubContext<CallHub> _callHub;
        private readonly int FileSizeLimit;
        private readonly string[] AllowedExtensions;
        private readonly IWebHostEnvironment _environment;
        //HubConnection connection;
        public ChatController(IHttpContextAccessor httpContextAccessor, IHubContext<ChatHub> chatHub, IHubContext<CallHub> callHub,
            IConfiguration configruation, IWebHostEnvironment environment)
        {
            session = httpContextAccessor.HttpContext.Session;
            _chatHub = chatHub;
            FileSizeLimit = configruation.GetSection("FileUpload").GetValue<int>("FileSizeLimit");
            AllowedExtensions = configruation.GetSection("FileUpload").GetValue<string>("AllowedExtensions").Split(",");
            _environment = environment;
            _callHub = callHub;
        }
        public ActionResult ChatDemo()
        {
            if (string.IsNullOrEmpty(session.GetString("Email")))
                return RedirectToActionPermanent("Login", "Authentication");
            return View();
        }
        public ActionResult ChatHome()
        {
            if (string.IsNullOrEmpty(session.GetString("Email")))
                return RedirectToActionPermanent("Login", "Authentication");
            return View();
        }

        [HttpPost]
        public ActionResult ChatHome(ProfileInfo SaveUInfo)
        {
            int code = -1;
            if (!ModelState.IsValid)
            {
                return View(SaveUInfo);
            }
            code = ChatRepo.SaveUserInfo(SaveUInfo);
            //int code2 = repo.Registration(SaveUInfo);
            if (code == 0)
            {
                TempData["Success"] = "Your details Updated Successfuly";
                //return RedirectToAction("Login");
            }

            else
            {
                TempData["Success"] = null;
            }
            //return PartialView("~/Views/Chat/_ProfileModal.cshtml");
            return RedirectToAction("ChatHome");
            //HttpContext.Session.Clear();
        }

        //Hemant
        [HttpPost]
        public IActionResult UpdateProfilePicture(ProfileInfo LoginUserId, IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);

                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                    // Combines two strings into a path.
                    var filepath =
            new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lib", "images", "user", "500")).Root + $@"{ newFileName}";

                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        files.CopyTo(fs);
                        fs.Flush();
                        int code;
                        code = ChatRepo.UpdateProfilePicture(LoginUserId, newFileName);
                    }
                    session.SetString("ProfileImage", newFileName);
                }
            }
            return RedirectToAction("ChatHome");
        }
        //[ChildActionOnly]

        public PartialViewResult PersonalChat(string UserId, string UserName)
        {
            UserId = string.IsNullOrEmpty(UserId) ? session.GetString("UserId") : UserId;
            if (!string.IsNullOrEmpty(session.GetString("Email")) && !string.IsNullOrEmpty(UserId))
            {
                List<PersonalChatModel> personalChat = new List<PersonalChatModel>();
                personalChat = ChatRepo.GetPersonalChat(UserId, UserName);
                return PartialView("_PersonalChat", personalChat);
            }
            return PartialView("_Logout");
        }

        //public PartialViewResult ConversationPanel(string UserId, string ChatUserId, string ChatUserName, string Lastseen, string Message, IFormFile imageArr)
        //[EnableCors("CorsPolicy")]
        public PartialViewResult ConversationPanel(string UserId, string ChatUserId, string ChatUserName, string Lastseen, string Message, int? MsgCount)
        {
            ChatConversation chat = new ChatConversation();
            chat.UserId = UserId;
            chat.ChatUserName = ChatUserName;
            chat.ChatUserId = ChatUserId;
            chat.Lastseen = Lastseen;
            if (MsgCount == 0)
            {
                ChatRepo.SendNewContactMessage(UserId, ChatUserId);
            }
            chat.Messages = ChatRepo.GetMessages(UserId, ChatUserId, Message);

            foreach (var doc in chat.Messages)
            {
                if (doc.Message.Contains(".jpeg") || doc.Message.Contains(".jpg") || doc.Message.Contains(".png") || doc.Message.Contains(".gif"))
                {
                    var path = Path.Combine(_environment.WebRootPath, "Documents", doc.Message);
                    if (System.IO.File.Exists(path))
                    {
                        var imageFileStream = System.IO.File.OpenRead(path);
                        string extention = doc.Message.Split('.')[1];
                        Byte[] bytes = System.IO.File.ReadAllBytes(path);
                        doc.DocUrl = "data:image/" + extention + ";base64," + Convert.ToBase64String(bytes);
                    }

                }
            }
            if (!string.IsNullOrEmpty(Message))
            {
                string ConnectionId = ChatRepo.GetSignalrConnection(ChatUserId);
                Task.Run(() => _chatHub.Clients.Client(ConnectionId).SendAsync("SendMessageToUser", ConnectionId, ChatUserId, UserId, Message));
                //Task.Run(() => _chatHub.Clients.All.SendAsync("SendMessageToUser"));
            }
            return PartialView("_ConversationPanel", chat);
        }
        [HttpPost]
        public IActionResult UploadDocument([FromBody] UploadDocumentModel docData)
        {
            if (docData.File.Count > 0)
            {
                var folderPath = Path.Combine(_environment.WebRootPath, "Documents");
                string FileName = string.Empty;
                ChatConversation chat = new ChatConversation();
                chat.UserId = docData.UserId;
                chat.ChatUserId = docData.ChatUserID;
                foreach (var FileUrl in docData.File)
                {
                    string extention = FileUrl.url.Split(';')[0].Split('/')[1];
                    if (extention.Contains("wordprocessingml.document"))
                    {
                        extention = "docx";
                    }
                    else if (extention.Contains("msword"))
                    {
                        extention = "doc";
                    }
                    else if (extention.Contains("vnd.ms-excel"))
                    {
                        extention = "xls";
                    }
                    else if (extention.Contains("vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
                    {
                        extention = "xlsx";
                    }
                    else if (extention.Contains("vnd.ms-powerpoint"))
                    {
                        extention = "ppt";
                    }
                    else if (extention.Contains("x-ms-wmv"))
                    {
                        extention = "wmv";
                    }
                    FileName = DateTime.Now.ToString("yyyymmddMMss") + "." + extention;
                    string FilePath = Path.Combine(folderPath, FileName);
                    Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                    System.IO.File.WriteAllBytes(FilePath, Convert.FromBase64String(regex.Replace(FileUrl.url, string.Empty)));
                    chat.Messages = ChatRepo.GetMessages(docData.UserId, docData.ChatUserID, FileName);
                }
                string ConnectionId = ChatRepo.GetSignalrConnection(docData.ChatUserID);
                Task.Run(() => _chatHub.Clients.Client(ConnectionId).SendAsync("SendMessageToUser", ConnectionId, docData.ChatUserID, docData.UserId, FileName));
                return PartialView("_ConversationPanel", chat);
            }
            return null;
        }

        public IActionResult DownloadDocument(string filename)
        {
            Byte[] FileBuffer = null;
            var folderPath = Path.Combine(_environment.WebRootPath, "Documents");
            string FilePath = Path.Combine(folderPath, filename);
            string lsExtension = Path.GetExtension(FilePath);
            var lsFileName = Path.GetFileName(FilePath);
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                try
                {

                    if (System.IO.File.Exists(FilePath))
                    {
                        FileBuffer = wc.DownloadData(FilePath); //live
                                                                // FileBuffer = System.IO.File.ReadAllBytes(FilePath);
                        if (lsExtension.Trim('.') == Convert.ToString("pdf"))
                            return File(FileBuffer, "application/pdf;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("png"))
                            return File(FileBuffer, "image/png;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("gif"))
                            return File(FileBuffer, "image/gif;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("jpg"))
                            return File(FileBuffer, "image/jpg;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("jpeg"))
                            return File(FileBuffer, "image/jpeg;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("ppt"))
                            return File(FileBuffer, "application/ppt;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("doc") || lsExtension.Trim('.') == Convert.ToString("docx"))
                            return File(FileBuffer, "application/doc;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("txt"))
                            return File(FileBuffer, "application/txt;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("csv"))
                            return File(FileBuffer, "application/csv;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("wmv"))
                            return File(FileBuffer, "application/wmv;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("avi"))
                            return File(FileBuffer, "application/avi;", lsFileName);
                        else if (lsExtension.Trim('.') == Convert.ToString("webm"))
                            return File(FileBuffer, "application/webm;", lsFileName);
                        else
                            return null;
                    }
                    else return null;
                }
                catch
                {
                    return null;
                }
            }


        }
        public PartialViewResult MessagePanel(string UserId, string ChatUserId)
        {
            ChatConversation chat = new ChatConversation();
            chat.UserId = UserId;
            chat.ChatUserId = ChatUserId;
            chat.Messages = ChatRepo.GetMessages(UserId, ChatUserId, "");

            foreach (var doc in chat.Messages)
            {
                if (doc.Message.Contains(".jpeg") || doc.Message.Contains(".jpg") || doc.Message.Contains(".png") || doc.Message.Contains(".gif"))
                {

                    var path = Path.Combine(_environment.WebRootPath, "Documents", doc.Message);
                    if (System.IO.File.Exists(path))
                    {
                        var imageFileStream = System.IO.File.OpenRead(path);
                        string extention = doc.Message.Split('.')[1];
                        Byte[] bytes = System.IO.File.ReadAllBytes(path);
                        doc.DocUrl = "data:image/" + extention + ";base64," + Convert.ToBase64String(bytes);
                    }

                }
            }
            return PartialView("_MessagePanel", chat);
        }

        public PartialViewResult ProfileView(string UserId)
        {
            UserId = string.IsNullOrEmpty(UserId) ? session.GetString("UserId") : UserId;
            if (!string.IsNullOrEmpty(session.GetString("Email")) && !string.IsNullOrEmpty(UserId))
            {
                ProfileInfo profileInfo = new ProfileInfo();
                profileInfo.Email = session.GetString("Email");
                profileInfo.UserName = session.GetString("UserName");
                profileInfo.MobileNumber = session.GetString("Mobile");
                profileInfo.ProfileImage = session.GetString("ProfileImage");
                profileInfo.Facebook = session.GetString("Facebook");
                profileInfo.Instagram = session.GetString("Instagram");
                profileInfo.Twitter = session.GetString("Twitter");
                profileInfo.Snapchat = session.GetString("Snapchat");
                return PartialView("_ProfileModal", profileInfo);
            }
            return PartialView("_Logout");
        }
        public PartialViewResult GetContactInfo(string ChatUserId, string UserId)
        {
            UserId = string.IsNullOrEmpty(UserId) ? session.GetString("UserId") : UserId;
            if (!string.IsNullOrEmpty(session.GetString("Email")) && !string.IsNullOrEmpty(ChatUserId) && !string.IsNullOrEmpty(UserId))

            {
                ContactInfo contactInfo = new ContactInfo();
                contactInfo = ChatRepo.GetContactInfo(ChatUserId, UserId);
                List<ImageDetails> objimag = new List<ImageDetails>();
                if (contactInfo.Image != null)
                {
                    for (int i = 0; i < contactInfo.Image.Count; i++)
                    {
                        var path = Path.Combine(_environment.WebRootPath, "Documents", contactInfo.Image[i].ImageName.ToString());
                        if (System.IO.File.Exists(path))
                        {
                            var imageFileStream = System.IO.File.OpenRead(path);
                            string extention = contactInfo.Image[i].ImageName.ToString().Split('.')[1];
                            Byte[] bytes = System.IO.File.ReadAllBytes(path);
                            var Imagedetails = new ImageDetails
                            {
                                ImageName = contactInfo.Image[i].ImageName.ToString(),
                                ImageURL = "data:image/" + extention + ";base64," + Convert.ToBase64String(bytes)
                            };

                            objimag.Add(Imagedetails);
                        }
                    }
                }
                contactInfo.Image = objimag;
                return PartialView("_Contactinfo", contactInfo);
            }
            return PartialView("_Logout");
        }

        public async Task<IActionResult> CreateGroup(GroupCreate GroupCreate)
        {
            int code = -1;
            if (!ModelState.IsValid)
            {
                return View(GroupCreate);
            }
            code = await ChatRepo.CreateGroup(GroupCreate);
            return RedirectToAction("ChatHome");
        }

        public PartialViewResult GroupChat(string UserId, string GroupName)
        {
            UserId = string.IsNullOrEmpty(UserId) ? session.GetString("UserId") : UserId;
            if (!string.IsNullOrEmpty(session.GetString("Email")) && !string.IsNullOrEmpty(UserId))
            {
                List<GroupChatModel> groupChat = new List<GroupChatModel>();
                groupChat = ChatRepo.GetGroupChat(UserId, GroupName);
                return PartialView("_GroupChat", groupChat);
            }
            return PartialView("_Logout");
        }

        public PartialViewResult GroupConversationPanel(string GroupId, string UserId, string GroupName, int TotalMembers, string Message)
        {
            GroupChatConversation chat = new GroupChatConversation();
            chat.GroupId = GroupId;
            chat.GroupName = GroupName;
            chat.UserId = UserId;
            chat.TotalMembers = TotalMembers;


            chat.GroupMessages = ChatRepo.GetGroupMessages(GroupId, UserId, Message);

            foreach (var doc in chat.GroupMessages)
            {
                if (doc.Message.Contains(".jpeg") || doc.Message.Contains(".jpg") || doc.Message.Contains(".png") || doc.Message.Contains(".gif"))
                {
                    var path = Path.Combine(_environment.WebRootPath, "Documents", doc.Message);
                    if (System.IO.File.Exists(path))
                    {
                        var imageFileStream = System.IO.File.OpenRead(path);
                        string extention = doc.Message.Split('.')[1];
                        Byte[] bytes = System.IO.File.ReadAllBytes(path);
                        doc.DocUrl = "data:image/" + extention + ";base64," + Convert.ToBase64String(bytes);
                    }

                }
            }
            if (!string.IsNullOrEmpty(Message))
            {
                Task.Run(() => _chatHub.Clients.Group(GroupName).SendAsync("SendMessageToGrp", GroupName));
            }
            return PartialView("_GroupConversationPanel", chat);
        }
        public PartialViewResult GrpMessagePanel(string GroupId, string UserId)
        {
            GroupChatConversation chat = new GroupChatConversation();
            chat.GroupId = GroupId;
            chat.UserId = UserId;
            chat.GroupMessages = ChatRepo.GetGroupMessages(GroupId, UserId, "");

            foreach (var doc in chat.GroupMessages)
            {
                if (doc.Message.Contains(".jpeg") || doc.Message.Contains(".jpg") || doc.Message.Contains(".png") || doc.Message.Contains(".gif"))
                {
                    var path = Path.Combine(_environment.WebRootPath, "Documents", doc.Message);
                    if (System.IO.File.Exists(path))
                    {
                        var imageFileStream = System.IO.File.OpenRead(path);
                        string extention = doc.Message.Split('.')[1];
                        Byte[] bytes = System.IO.File.ReadAllBytes(path);
                        doc.DocUrl = "data:image/" + extention + ";base64," + Convert.ToBase64String(bytes);
                    }

                }
            }
            return PartialView("_GrpMessagePanel", chat);
        }

        public PartialViewResult GetMyContact(string GroupID, string UserId)
        {
            UserId = string.IsNullOrEmpty(UserId) ? session.GetString("UserId") : UserId;
            if (!string.IsNullOrEmpty(session.GetString("Email")) && !string.IsNullOrEmpty(UserId))
            {
                List<MyAllContacts> groupChat = new List<MyAllContacts>();
                groupChat = ChatRepo.GetMyContact(GroupID, UserId);
                return PartialView("_AddMembers", groupChat);
            }
            return PartialView("_Logout");
        }
        [HttpGet]
        public JsonResult AddMember(string GroupID, string ContactUserId)
        {
            if (!string.IsNullOrEmpty(GroupID) && !string.IsNullOrEmpty(ContactUserId))
            {
                int result = -1;
                result = ChatRepo.AddMember(GroupID, ContactUserId);
                if (result == 0)
                {
                    return Json(new { code = result });
                }
            }
            return null;
        }

        public IActionResult UploadGrpDocument([FromBody] UploadGrpDocumentModel docData)
        {
            if (docData.File.Count > 0)
            {
                var folderPath = Path.Combine(_environment.WebRootPath, "Documents");
                string FileName = string.Empty;
                GroupChatConversation chat = new GroupChatConversation();
                chat.UserId = docData.UserId;
                chat.GroupId = docData.GroupId;
                foreach (var FileUrl in docData.File)
                {
                    string extention = FileUrl.url.Split(';')[0].Split('/')[1];
                    if (extention.Contains("wordprocessingml.document"))
                    {
                        extention = "docx";
                    }
                    else if (extention.Contains("msword"))
                    {
                        extention = "doc";
                    }
                    else if (extention.Contains("vnd.ms-excel"))
                    {
                        extention = "xls";
                    }
                    else if (extention.Contains("vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
                    {
                        extention = "xlsx";
                    }
                    else if (extention.Contains("vnd.ms-powerpoint"))
                    {
                        extention = "ppt";
                    }
                    else if (extention.Contains("x-ms-wmv"))
                    {
                        extention = "wmv";
                    }
                    FileName = DateTime.Now.ToString("yyyymmddMMss") + "." + extention;
                    string FilePath = Path.Combine(folderPath, FileName);
                    Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                    System.IO.File.WriteAllBytes(FilePath, Convert.FromBase64String(regex.Replace(FileUrl.url, string.Empty)));
                    chat.GroupMessages = ChatRepo.GetGroupMessages(docData.GroupId, docData.UserId, FileName);
                }

                string ConnectionId = ChatRepo.GetSignalrConnection(docData.GroupId);
                Task.Run(() => _chatHub.Clients.Group(docData.GroupName).SendAsync("SendMessageToGrp", docData.GroupName));
                return PartialView("_GroupConversationPanel", chat);
            }
            return null;
        }
        public PartialViewResult GetGroupInfo(string GroupId)
        {
            if (!string.IsNullOrEmpty(session.GetString("Email")) && !string.IsNullOrEmpty(GroupId))
            {
                GroupContactInfo groupChat = new GroupContactInfo();
                groupChat = ChatRepo.GetGroupInfo(GroupId);
                List<ImageDetails> objimag = new List<ImageDetails>();
                if (groupChat.Image != null)
                {
                    for (int i = 0; i < groupChat.Image.Count; i++)
                    {
                        var path = Path.Combine(_environment.WebRootPath, "Documents", groupChat.Image[i].ImageName.ToString());
                        if (System.IO.File.Exists(path))
                        {
                            var imageFileStream = System.IO.File.OpenRead(path);
                            string extention = groupChat.Image[i].ImageName.ToString().Split('.')[1];
                            Byte[] bytes = System.IO.File.ReadAllBytes(path);
                            var Imagedetails = new ImageDetails
                            {
                                ImageName = groupChat.Image[i].ImageName.ToString(),
                                ImageURL = "data:image/" + extention + ";base64," + Convert.ToBase64String(bytes)
                            };

                            objimag.Add(Imagedetails);
                        }
                    }
                }
                groupChat.Image = objimag;
                return PartialView("_Groupinfo", groupChat);
            }
            return PartialView("_Logout");
        }

        public PartialViewResult CallList(string UserId, string UserName)
        {
            UserId = string.IsNullOrEmpty(UserId) ? session.GetString("UserId") : UserId;
            if (!string.IsNullOrEmpty(session.GetString("Email")) && !string.IsNullOrEmpty(UserId))
            {
                List<PersonalChatModel> callList = new List<PersonalChatModel>();
                callList = ChatRepo.GetPersonalChat(UserId, UserName);
                return PartialView("_CallList", callList);
            }
            return PartialView("_Logout");
        }
        public PartialViewResult MakeCall(string UserId, string ChatUserId, string ChatUserName, string Lastseen, string Message)
        {
            string UserConnectionId = ChatRepo.GetSignalrConnection(UserId);
            string ChatUserConnectionId = ChatRepo.GetSignalrConnection(ChatUserId);
            List<PersonalChatModel> callList = new List<PersonalChatModel>();
            callList = ChatRepo.GetPersonalChat(UserId, ChatUserName);
            return PartialView("_CallList", callList);

        }

        public PartialViewResult GetAllUsers(string UserId)
        {
            UserId = string.IsNullOrEmpty(UserId) ? session.GetString("UserId") : UserId;
            if (!string.IsNullOrEmpty(session.GetString("Email")) && !string.IsNullOrEmpty(UserId))
            {
                List<AllUsersModel> users = new List<AllUsersModel>();
                users = ChatRepo.GetAllUsers(UserId);
                return PartialView("_Contact", users);
            }
            return PartialView("_Logout");
        }
        public PartialViewResult GetContactDetails(string UserId)
        {
            UserId = string.IsNullOrEmpty(UserId) ? session.GetString("UserId") : UserId;
            if (!string.IsNullOrEmpty(session.GetString("Email")) && !string.IsNullOrEmpty(UserId))
            {
                ContactDetails contact = new ContactDetails();
                contact = ChatRepo.GetContactDetails(UserId);
                return PartialView("_ContactDetails", contact);
            }
            return PartialView("_Logout");
        }
        private bool Validate(IFormFile file)
        {
            if (file.Length > FileSizeLimit)
                return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !AllowedExtensions.Any(s => s.Contains(extension)))
                return false;

            return true;
        }
    }
}
