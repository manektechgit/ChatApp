using DotNetCoreMVCDemos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Repository
{
    public class ChatRepository
    {
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
                        MessageCount= Convert.ToInt16(row["MessageCount"])
                    };
                    personalChat.Add(chat);
                }
            }
            return personalChat;
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
                        IsRead = Convert.ToByte(row["IsRead"])                        
                    };
                    messages.Add(message);
                }
            }
            return messages;
        }

        public ContactInfo GetContactInfo(string ChatUserId)
        {
            ContactInfo objUsers = new ContactInfo();
            DataTable dtUser = new DataTable();
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@ChatUserId", ChatUserId);
            Common.SqlHelper.Fill(dtUser, "[GetContactInfo]", objParameter);

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    objUsers.UserId = Convert.ToInt32(row["UserId"]);
                    objUsers.Email = Convert.ToString(row["Email"]);
                    objUsers.ChatUserName= Convert.ToString(row["UserName"]);
                    objUsers.MobileNumber = Convert.ToString(row["Mobile"]);
                }
            }
            return objUsers;
        }

        public int AddSignalrConnection(string SignalrId,string UserId)
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
    }
}
