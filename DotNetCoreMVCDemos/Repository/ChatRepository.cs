using DotNetCoreMVCDemos.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Repository
{
    public class ChatRepository
    {
        public readonly AuthenticationRepository repo = new AuthenticationRepository();
        public List<PersonalChatModel> GetPersonalChat(string UserId, string UserName)
        {
            List<PersonalChatModel> personalChat = new List<PersonalChatModel>();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@UserName", UserName);
            objParameter[1] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.Fill(dtChat, "[GetPersonalChat]", objParameter);

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    PersonalChatModel chat = new PersonalChatModel
                    {
                        UserId = Convert.ToString(row["UserId"]),
                        Email = Convert.ToString(row["Email"]),
                        UserName = Convert.ToString(row["UserName"]),
                        Status = Convert.ToString(row["Status"]),
                        Lastseen = Convert.ToString(row["Lastseen"]),
                        LastMessage = Convert.ToString(row["LastMessage"]),
                        LastMessageTime = Convert.ToString(row["LastMessageTime"]),
                        MessageCount = Convert.ToInt16(row["MessageCount"]),
                        ProfileImage = Convert.ToString(row["ProfileImage"])
                    };
                    personalChat.Add(chat);
                }
            }
            return personalChat;
        }
        public int SaveUserInfo(ProfileInfo userLogin)
        {
            ProfileInfo objUsers = new Models.ProfileInfo();
            DataTable dtUser = new DataTable();
            int ResultCode = 1;
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@UserID", userLogin.UserId);
            objParameter[1] = new SqlParameter("@ProfileImage", userLogin.ProfileImage);
            objParameter[2] = new SqlParameter("@Facebook", userLogin.Facebook);
            objParameter[3] = new SqlParameter("@Snapchat", userLogin.Snapchat);

            objParameter[4] = new SqlParameter("@Twitter", userLogin.Twitter);
            objParameter[5] = new SqlParameter("@Instagram", userLogin.Instagram);

            Common.SqlHelper.Fill(dtUser, "[SaveUserInfo]", objParameter);

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    ResultCode = Convert.ToInt32(row["ResultCode"]);
                }
                return ResultCode;
            }
            else
            {
                return ResultCode;
            }
        }
        public int DeleteChatMessage(int userid, int Conversationid)
        {
            Messages msg = new Models.Messages();
            DataTable dtUser = new DataTable();
            int ResultCode = 1;
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@UserID", userid);
            objParameter[1] = new SqlParameter("@ConversationID", Conversationid);


            Common.SqlHelper.Fill(dtUser, "[DeleteChatConversation]", objParameter);

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    ResultCode = Convert.ToInt32(row["ResultCode"]);
                }
                return ResultCode;
            }
            else
            {
                return ResultCode;
            }

        }
        public int ClearChatMessages(int UserId, int ChatUserId)
        {
            List<ChatConversation> messages = new List<ChatConversation>();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@userId", UserId);
            objParameter[1] = new SqlParameter("@chatUserid", ChatUserId);
            Common.SqlHelper.Fill(dtChat, "[ClearChatMessages]", objParameter);
            int ResultCode = 1;

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    ResultCode = Convert.ToInt32(row["ResultCode"]);
                }
                return ResultCode;
            }
            else
            {
                return ResultCode;
            }
        }
        public int UpdateProfilePicture(ProfileInfo userid, string newPath)
        {
            ProfileInfo objUsers = new Models.ProfileInfo();
            DataTable dtUser = new DataTable();
            int ResultCode = 1;
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@UserID", userid.UserId);
            objParameter[1] = new SqlParameter("@ProfileImage", newPath);

            Common.SqlHelper.Fill(dtUser, "[SaveProfileImage]", objParameter);

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    ResultCode = Convert.ToInt32(row["ResultCode"]);
                }
                return ResultCode;
            }
            else
            {
                return ResultCode;
            }
        }

        public List<Messages> GetMessages(string UserId, string ChatUserId, string Message)
        {
            List<Messages> messages = new List<Messages>();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            objParameter[1] = new SqlParameter("@ChatUserId", ChatUserId);
            objParameter[2] = new SqlParameter("@Message", Message);
            Common.SqlHelper.Fill(dtChat, "[GetMessages]", objParameter);

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    Messages message = new Messages
                    {
                        ConversationID = Convert.ToInt32(row["ConversationID"]),
                        Message = Convert.ToString(row["Message"]),
                        MessageTime = Convert.ToString(row["MessageTime"]),
                        UserID = Convert.ToString(row["UserId"]),
                        IsRead = Convert.ToByte(row["IsRead"]),
                        ProfileImage = Convert.ToString(row["ProfileImage"]),
                        Name = Convert.ToString(row["Name"]),
                        IsStar = Convert.ToBoolean(row["IsStar"]),
                    };
                    messages.Add(message);
                }
            }
            return messages;
        }

        public ContactInfo GetContactInfo(string ChatUserId, string UserId)
        {
            List<ImageDetails> image = new List<ImageDetails>();
            List<string> documentList = new List<string>();

            ContactInfo objUsers = new ContactInfo();
            DataSet dsuser = new DataSet();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@ChatUserId", ChatUserId);
            objParameter[1] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.FillDataset(dsuser, "[GetContactInfo]", objParameter);

            if (dsuser != null && dsuser.Tables[1].Rows.Count > 0)
            {
                objUsers.UserId = Convert.ToInt32(dsuser.Tables[1].Rows[0]["UserId"]);
                objUsers.Email = Convert.ToString(dsuser.Tables[1].Rows[0]["Email"]);
                objUsers.ChatUserName = Convert.ToString(dsuser.Tables[1].Rows[0]["UserName"]);
                objUsers.MobileNumber = Convert.ToString(dsuser.Tables[1].Rows[0]["Mobile"]);
                objUsers.ProfileImage = Convert.ToString(dsuser.Tables[1].Rows[0]["ProfileImage"]);
                if (dsuser.Tables[0] != null && dsuser.Tables[0].Rows.Count > 0)
                {
                    objUsers.TotalMediaFile = Convert.ToInt32(dsuser.Tables[0].Rows[0]["TotalMediaFile"]);
                    objUsers.TotalDocumentFile = Convert.ToInt32(dsuser.Tables[0].Rows[0]["TotalDocumentFile"]);
                    for (int i = 0; i < dsuser.Tables[0].Rows.Count; i++)
                    {
                        if (dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".jpeg") || dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".jpg")
                            || dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".png") || dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".gif"))
                        {
                            var imagedetails = new ImageDetails
                            {
                                ImageName = dsuser.Tables[0].Rows[i]["Message"].ToString(),
                                ImageURL = dsuser.Tables[0].Rows[i]["Message"].ToString(),
                            };
                            image.Add(imagedetails);
                        }
                        if (dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".pdf") || dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".doc")
                            || dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".xls") || dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".ppt")
                            || dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".mp4") || dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".wmv")
                            || dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".webm") || dsuser.Tables[0].Rows[i]["Message"].ToString().Contains(".avi"))
                        {
                            documentList.Add(dsuser.Tables[0].Rows[i]["Message"].ToString());

                        }

                    }
                }



                objUsers.Image = image;
                objUsers.Documents = documentList;
            }
            return objUsers;
        }

        public int AddSignalrConnection(string SignalrId, string UserId)
        {
            DataTable dtUser = new DataTable();
            int ResultCode = -1;
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@SignalrId", SignalrId);
            objParameter[1] = new SqlParameter("@UserId", UserId);

            Common.SqlHelper.Fill(dtUser, "[AddSignalrConnection]", objParameter);
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    ResultCode = Convert.ToInt32(row["ResultCode"]);
                }
                return ResultCode;
            }
            else
            {
                return ResultCode;
            }
        }

        public string GetSignalrConnection(string ChatUserID)
        {
            DataTable dtUser = new DataTable();
            string SignalrId = null;
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@ChatUserID", ChatUserID);

            Common.SqlHelper.Fill(dtUser, "[GetSignalrConnection]", objParameter);
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    SignalrId = Convert.ToString(row["SignalrId"]);
                }
                return SignalrId;
            }
            else
            {
                return SignalrId;
            }
        }

        public async Task<int> CreateGroup(GroupCreate Group)
        {
            DataTable dtUser = new DataTable();
            int ResultCode = -1;
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@GroupName", Group.GroupName);
            objParameter[1] = new SqlParameter("@UserId", Group.UserId);

            Common.SqlHelper.Fill(dtUser, "[CreateGroup]", objParameter);
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    ResultCode = Convert.ToInt32(row["ResultCode"]);
                }
                return ResultCode;
            }
            else
            {
                return ResultCode;
            }
        }

        public List<GroupChatModel> GetGroupChat(string UserId, string GroupName)
        {
            List<GroupChatModel> groupChat = new List<GroupChatModel>();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@GroupName", GroupName);
            objParameter[1] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.Fill(dtChat, "[GetGroupChat]", objParameter);

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    GroupChatModel chat = new GroupChatModel
                    {
                        GroupName = Convert.ToString(row["GroupName"]),
                        LastMessage = Convert.ToString(row["LastMessage"]),
                        LastMessageTime = Convert.ToString(row["LastMessageTime"]),
                        MessageCount = Convert.ToInt16(row["MessageCount"]),
                        TotalMembers = Convert.ToInt16(row["TotalMembers"]),
                        GroupID = Convert.ToString(row["GroupID"])

                    };
                    groupChat.Add(chat);
                }
            }
            return groupChat;
        }

        public List<GroupMessages> GetGroupMessages(string GroupId, string UserId, string Message)
        {
            List<GroupMessages> messages = new List<GroupMessages>();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@GroupId", GroupId);
            objParameter[1] = new SqlParameter("@UserId", UserId);
            objParameter[2] = new SqlParameter("@Message", Message);
            Common.SqlHelper.Fill(dtChat, "[GetGroupMessages]", objParameter);

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    GroupMessages message = new GroupMessages
                    {
                        //ConversationID = Convert.ToInt32(row["ConversationID"]),
                        Message = Convert.ToString(row["Message"]),
                        MessageTime = Convert.ToString(row["MessageTime"]),
                        UserID = Convert.ToString(row["UserId"]),
                        ProfileImage = Convert.ToString(row["ProfileImage"]),
                        //ChatUserID = Convert.ToString(row["ChatUserID"]),
                        //IsRead = Convert.ToByte(row["IsRead"]),
                        Name = Convert.ToString(row["Name"]),
                        GroupMsgID = Convert.ToString(row["GroupMsgID"]),
                        IsStar = Convert.ToBoolean(row["IsStar"])
                    };
                    messages.Add(message);
                }
            }
            return messages;
        }

        public List<string> GetGrpSignalrConnection(string GroupID, string UserID)
        {
            DataTable dtUser = new DataTable();
            List<string> GrpConnectionId = new List<string>();
            string SignalrId = null;
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@GroupID", GroupID);
            objParameter[1] = new SqlParameter("@UserID", UserID);

            Common.SqlHelper.Fill(dtUser, "[GetGrpSignalrConnection]", objParameter);
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    SignalrId = Convert.ToString(row["SignalrId"]);
                    GrpConnectionId.Add(SignalrId);
                }
                return GrpConnectionId;
            }
            else
            {
                return GrpConnectionId;
            }
        }
        public List<MyAllContacts> GetMyContact(string GroupID, string UserId)
        {
            List<MyAllContacts> Contacts = new List<MyAllContacts>();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@GroupId", GroupID);
            objParameter[1] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.Fill(dtChat, "[GetMyContact]", objParameter);

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    MyAllContacts Contact = new MyAllContacts
                    {
                        Name = Convert.ToString(row["Name"]),
                        ContactUserId = Convert.ToString(row["ContactUserId"]),
                        IsExist = Convert.ToInt32(row["IsExist"]),
                        ProfileImage = Convert.ToString(row["ProfileImage"])
                    };
                    Contacts.Add(Contact);
                }
            }
            return Contacts;
        }
        public int AddMember(string GroupID, string ContactUserId)
        {
            DataTable dtUser = new DataTable();
            int ResultCode = -1;
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@GroupId", GroupID);
            objParameter[1] = new SqlParameter("@UserId", ContactUserId);

            Common.SqlHelper.Fill(dtUser, "[AddMember]", objParameter);
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    ResultCode = Convert.ToInt32(row["ResultCode"]);
                }
                return ResultCode;
            }
            else
            {
                return ResultCode;
            }
        }

        public GroupContactInfo GetGroupInfo(string GroupId)
        {
            GroupContactInfo objUsers = new GroupContactInfo();
            DataSet dsUser = new DataSet();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@GroupId", GroupId);
            Common.SqlHelper.FillDataset(dsUser, "[GetGroupInfo]", objParameter);
            List<ImageDetails> image = new List<ImageDetails>();
            //List<string> memberList = new List<string>();
            List<MemberDetails> memberList = new List<MemberDetails>();
            List<string> documentList = new List<string>();

            if (dsUser != null && dsUser.Tables[0].Rows.Count > 0)
            {
                objUsers.GroupName = Convert.ToString(dsUser.Tables[0].Rows[0]["GroupName"]);
                objUsers.TotalMembers = Convert.ToInt32(dsUser.Tables[0].Rows[0]["TotalMembers"]);
                objUsers.TotalMediaFile = Convert.ToInt32(dsUser.Tables[0].Rows[0]["TotalMediaFile"]);
                objUsers.TotalDocumentFile = Convert.ToInt32(dsUser.Tables[0].Rows[0]["TotalDocumentFile"]);
                for (int i = 0; i < dsUser.Tables[0].Rows.Count; i++)
                {
                    if (dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".jpeg") || dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".jpg")
                        || dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".png") || dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".gif"))
                    {
                        var imagedetails = new ImageDetails
                        {
                            ImageName = dsUser.Tables[0].Rows[i]["GroupMessage"].ToString(),
                            ImageURL = dsUser.Tables[0].Rows[i]["GroupMessage"].ToString(),
                        };
                        image.Add(imagedetails);
                    }
                    if (dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".pdf") || dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".doc")
                        || dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".xls") || dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".ppt")
                        || dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".mp4") || dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".wmv")
                        || dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".webm") || dsUser.Tables[0].Rows[i]["GroupMessage"].ToString().Contains(".avi"))
                    {
                        documentList.Add(dsUser.Tables[0].Rows[i]["GroupMessage"].ToString());

                    }
                }
                objUsers.Image = image;
                objUsers.Documents = documentList;

                if (dsUser != null && dsUser.Tables[1].Rows.Count > 0)
                {
                    for (int j = 0; j < dsUser.Tables[1].Rows.Count; j++)
                    {
                        var member = new MemberDetails
                        {
                            Name = dsUser.Tables[1].Rows[j]["MemberName"].ToString(),
                            ProfileImage = dsUser.Tables[1].Rows[j]["ProfileImage"].ToString(),
                        };
                        memberList.Add(member);
                    }
                    objUsers.Members = memberList;
                }
            }
            return objUsers;
        }

        public List<AllUsersModel> GetAllUsers(string UserId)
        {
            List<AllUsersModel> users = new List<AllUsersModel>();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.Fill(dtChat, "[GetAllUsers]", objParameter);

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    AllUsersModel chat = new AllUsersModel
                    {
                        UserContactID = Convert.ToString(row["UserContactID"]),
                        UserName = Convert.ToString(row["UserName"]),
                        ProfileImage = Convert.ToString(row["ProfileImage"]),
                        Lastseen = Convert.ToString(row["Lastseen"])
                    };
                    users.Add(chat);
                }
            }
            return users;
        }
        public ContactDetails GetContactDetails(string UserId)
        {
            ContactDetails contact = new ContactDetails();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.Fill(dtChat, "[GetContactDetails]", objParameter);

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    contact.ContactUserID = Convert.ToString(row["ContactUserID"]);
                    contact.UserName = Convert.ToString(row["UserName"]);
                    contact.Email = Convert.ToString(row["Email"]);
                    contact.Mobile = Convert.ToString(row["Mobile"]);
                }
            }
            return contact;
        }

        public void SendNewContactMessage(string UserId, string ChatUserId)
        {
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            objParameter[1] = new SqlParameter("@ChatUserId", ChatUserId);

            Common.SqlHelper.Fill(dtUser, "[SendNewContactMessage]", objParameter);
        }

        public void AddStar(string ConversationID, bool Status, byte MsgType, string UserId, string GroupMsgID)
        {
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[5];
            objParameter[0] = new SqlParameter("@ConversationID", ConversationID);
            objParameter[1] = new SqlParameter("@GroupMsgID", GroupMsgID);
            objParameter[2] = new SqlParameter("@Status", Status);
            objParameter[3] = new SqlParameter("@MsgType", MsgType);
            objParameter[4] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.Fill(dtUser, "[AddStarMessage]", objParameter);
        }
        public List<StarredMessage> GetStarredMessages(string UserId)
        {
            List<StarredMessage> messages = new List<StarredMessage>();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.Fill(dtChat, "[GetStarredMessages]", objParameter);
            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    StarredMessage message = new StarredMessage
                    {
                        Message = Convert.ToString(row["Message"]),
                        MessageTime = Convert.ToString(row["MessageTime"])
                        //ProfileImage = Convert.ToString(row["ProfileImage"]),
                    };
                    messages.Add(message);
                }
            }
            return messages;
        }

        public void LeaveGroup(string GroupId, string UserId)
        {
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@GroupId", GroupId);
            objParameter[1] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.Fill(dtUser, "[LeaveGroup]", objParameter);
        }

        public void ChangeTheme(string UserId, string Theme)
        {
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            objParameter[1] = new SqlParameter("@Theme", Theme);
            Common.SqlHelper.Fill(dtUser, "[ChangeTheme]", objParameter);
        }

        public List<ForwardMessageChatModel> GetForwardMessageChat(string UserId)
        {
            List<ForwardMessageChatModel> chats = new List<ForwardMessageChatModel>();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            Common.SqlHelper.Fill(dtChat, "[GetForwardMessageChat]", objParameter);

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    ForwardMessageChatModel chat = new ForwardMessageChatModel
                    {
                        Name = Convert.ToString(row["Name"]),
                        ChatUserId = Convert.ToString(row["ChatUserId"]),
                        ProfileImage = Convert.ToString(row["ProfileImage"]),
                        GroupID = Convert.ToString(row["GroupID"])
                    };
                    chats.Add(chat);
                }
            }
            return chats;
        }

        public MessageModel SaveForwardMessage(string UserId, string ChatUserId, string ConversationID, string GroupMsgID)
        {
            MessageModel Message = new MessageModel();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            objParameter[1] = new SqlParameter("@ChatUserId", ChatUserId);
            objParameter[2] = new SqlParameter("@ConversationID", ConversationID);
            objParameter[3] = new SqlParameter("@GroupMsgID", GroupMsgID);

            Common.SqlHelper.Fill(dtChat, "[SaveForwardMessage]", objParameter);

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    Message.Message = Convert.ToString(row["Message"]);
                    Message.MessageTime = Convert.ToString(row["MessageTime"]);
                    Message.ConversationID = Convert.ToString(row["ConversationID"]);
                    Message.GroupMsgID = "";
                }
            }
            return Message;
        }

        public MessageModel SendForwardGroupMessage(string UserId, string GroupID, string GroupMsgID,string ConversationID)
        {
            MessageModel Message = new MessageModel();
            DataTable dtChat = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            objParameter[1] = new SqlParameter("@GroupMsgID", GroupMsgID);
            objParameter[2] = new SqlParameter("@GroupID", GroupID);
            objParameter[3] = new SqlParameter("@ConversationID", ConversationID);
            
            Common.SqlHelper.Fill(dtChat, "[SaveForwardGroupMessage]", objParameter);

            if (dtChat != null && dtChat.Rows.Count > 0)
            {
                foreach (DataRow row in dtChat.Rows)
                {
                    Message.Message = Convert.ToString(row["Message"]);
                    Message.MessageTime = Convert.ToString(row["MessageTime"]);
                    Message.GroupMsgID = Convert.ToString(row["GroupMsgID"]);
                    Message.ConversationID = "";
                }
            }
            return Message;
        }
    }
}
