using DotNetCoreMVCDemos.Hubs;
using DotNetCoreMVCDemos.Models;
using DotNetCoreMVCDemos.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
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
        private readonly int FileSizeLimit;
        private readonly string[] AllowedExtensions;
        private readonly IWebHostEnvironment _environment;
        //HubConnection connection;
        public ChatController(IHttpContextAccessor httpContextAccessor, IHubContext<ChatHub> chatHub,
            IConfiguration configruation, IWebHostEnvironment environment)
        {
            session = httpContextAccessor.HttpContext.Session;
            _chatHub = chatHub;
            FileSizeLimit = configruation.GetSection("FileUpload").GetValue<int>("FileSizeLimit");
            AllowedExtensions = configruation.GetSection("FileUpload").GetValue<string>("AllowedExtensions").Split(",");
            _environment = environment;
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
        public PartialViewResult ConversationPanel(string UserId, string ChatUserId, string ChatUserName, string Lastseen, string Message)
        {
            ChatConversation chat = new ChatConversation();
            chat.UserId = UserId;
            chat.ChatUserName = ChatUserName;
            chat.ChatUserId = ChatUserId;
            chat.Lastseen = Lastseen;


            chat.Messages = ChatRepo.GetMessages(UserId, ChatUserId, Message);

            foreach (var doc in chat.Messages)
            {
                if (doc.Message.Contains(".jpeg") || doc.Message.Contains(".jpg") || doc.Message.Contains(".png") || doc.Message.Contains(".gif"))
                {
                    var path = Path.Combine(_environment.WebRootPath, "Documents", doc.Message);
                    var imageFileStream = System.IO.File.OpenRead(path);
                    string extention = doc.Message.Split('.')[1];
                    Byte[] bytes = System.IO.File.ReadAllBytes(path);
                    doc.DocUrl = "data:image/"+ extention + ";base64," + Convert.ToBase64String(bytes);
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
                        extention="docx";
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
                    FileBuffer = wc.DownloadData(FilePath);
                }
                catch
                {
                }
            }

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
                    var imageFileStream = System.IO.File.OpenRead(path);
                    string extention = doc.Message.Split('.')[1];
                    Byte[] bytes = System.IO.File.ReadAllBytes(path);
                    doc.DocUrl = "data:image/" + extention + ";base64," + Convert.ToBase64String(bytes);
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
                return PartialView("_ProfileModal", profileInfo);
            }
            return PartialView("_Logout");
        }
        public PartialViewResult GetContactInfo(string ChatUserId)
        {
            if (!string.IsNullOrEmpty(session.GetString("Email")) && !string.IsNullOrEmpty(ChatUserId))
            {
                ContactInfo contactInfo = new ContactInfo();
                contactInfo = ChatRepo.GetContactInfo(ChatUserId);
                return PartialView("_Contactinfo", contactInfo);
            }
            return PartialView("_Logout");
        }

        public async Task<IActionResult> UploadDoc([FromForm] UploadDocumentModel UploadDoc)
        {
            if (ModelState.IsValid)
            {
                //if (!Validate(UploadDoc.File))
                //{
                //    return BadRequest("Validation failed!");
                //}

                //var fileName = DateTime.Now.ToString("yyyymmddMMss") + "_" + Path.GetFileName(UploadDoc.File.FileName);
                //var folderPath = Path.Combine(_environment.WebRootPath, "uploads");
                //var filePath = Path.Combine(folderPath, fileName);
                //if (!Directory.Exists(folderPath))
                //    Directory.CreateDirectory(folderPath);

                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    await UploadDoc.File.CopyToAsync(fileStream);
                //}

                //var user = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                //var room = _context.Rooms.Where(r => r.Id == UploadDoc.RoomId).FirstOrDefault();
                //if (user == null || room == null)
                //    return NotFound();

                //string htmlImage = string.Format(
                //    "<a href=\"/uploads/{0}\" target=\"_blank\">" +
                //    "<img src=\"/uploads/{0}\" class=\"post-image\">" +
                //    "</a>", fileName);

                //var message = new Message()
                //{
                //    Content = Regex.Replace(htmlImage, @"(?i)<(?!img|a|/a|/img).*?>", string.Empty),
                //    Timestamp = DateTime.Now,
                //    FromUser = user,
                //    ToRoom = room
                //};

                //await _context.Messages.AddAsync(message);
                //await _context.SaveChangesAsync();

                //// Send image-message to group
                //var messageViewModel = _mapper.Map<Message, MessageViewModel>(message);
                //await _hubContext.Clients.Group(room.Name).SendAsync("newMessage", messageViewModel);

                return Ok();
            }

            return BadRequest();
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
