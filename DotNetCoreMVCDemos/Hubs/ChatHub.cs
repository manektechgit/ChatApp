using DotNetCoreMVCDemos.Models;
using DotNetCoreMVCDemos.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Hubs
{
    public class ChatHub : Hub
    {
        public readonly ChatRepository ChatRepo = new ChatRepository();
        public readonly static List<UserLogin> _Connections = new List<UserLogin>();
        private readonly static Dictionary<string, string> _ConnectionsMap = new Dictionary<string, string>();
        public readonly ISession session;
      
        public ChatHub( IHttpContextAccessor httpContextAccessor)
        {
         
            session = httpContextAccessor.HttpContext.Session;
        }


        //public async Task SendUserStatus()
        //{            
        //    await Clients.All.SendAsync("ActiveInactiveUser");
        //}
        public async Task SendAndGetMessage(string ChatUserId, string UserId, string Message)
        {
            string ConnectionId = ChatRepo.GetSignalrConnection(ChatUserId);
            await Clients.Client(ConnectionId).SendAsync("SendMessageToUser", ConnectionId, ChatUserId, UserId, Message);
            //await Clients.Client(ConnectionId).SendAsync("SendMessageToUser", ConnectionId);
            //await Clients.All.SendAsync("SendMessageToUser");
        }
        public async Task MessageTyping(string ChatUserId, string UserId)
        {
            string ConnectionId = ChatRepo.GetSignalrConnection(ChatUserId);
            await Clients.Client(ConnectionId).SendAsync("UserTypeMessage", ConnectionId, UserId);
            //await Clients.All.SendAsync("UserTypeMessage");
        }
        public async Task MessageRead(string ChatUserId)
        {
            string ConnectionId = ChatRepo.GetSignalrConnection(ChatUserId);
            await Clients.Client(ConnectionId).SendAsync("UserReadMessage", ConnectionId);
            //await Clients.All.SendAsync("UserTypeMessage");
        }
        public async Task SendAndGetGrpMessage(string GroupId, string UserId, string GroupName)
        {
            List<string> GrpConnectionId = new List<string>();
            GrpConnectionId = ChatRepo.GetGrpSignalrConnection(GroupId, UserId);
            foreach (string ConId in GrpConnectionId)
            {
                await Groups.AddToGroupAsync(ConId, GroupName);
            }
            await Clients.Group(GroupName).SendAsync("SendMessageToGrp", GroupName);
        }
        public async Task SendToAddGroup(string UserId)
        {
            string ConnectionId = ChatRepo.GetSignalrConnection(UserId);
            await Clients.Client(ConnectionId).SendAsync("AddIntoGroup", ConnectionId);
        }
        public async Task GrpMessageTyping(string GroupId, string UserId, string GroupName)
        {
            List<string> GrpConnectionId = new List<string>();
            GrpConnectionId = ChatRepo.GetGrpSignalrConnection(GroupId, UserId);
            foreach (string ConId in GrpConnectionId)
            {
                await Groups.AddToGroupAsync(ConId, GroupName);
            }
            await Clients.Group(GroupName).SendAsync("GrpTypeMessage", GroupName, UserId);
        }
        public async Task SendPrivate(string receiverName, string message)
        {
            if (_ConnectionsMap.TryGetValue(receiverName, out string userId))
            {
                // Who is the sender;
                //var sender = repo.UserLogin(LoginUser.Email, LoginUser.Password);
                string userName = session.GetString("UserName");
                if (!string.IsNullOrEmpty(message.Trim()))
                {
                    // Build the message
                    Messages Message = new Messages()
                    {
                        Message = Regex.Replace(message, @"<.*?>", string.Empty),
                        //From = userName,
                        //Avatar = sender.Avatar,
                        //Room = "",
                        MessageTime = DateTime.Now.ToLongTimeString()
                    };

                    // Send the message
                    await Clients.Client(userId).SendAsync("newMessage", Message);
                    await Clients.Caller.SendAsync("newMessage", Message);
                }
            }
        }

        public async Task Join()
        {
            try
            {
                var user = new UserLogin { UserName = session.GetString("UserName"), };
                if (user != null)
                {
                    // Remove user from others list
                    if (!string.IsNullOrEmpty("CurrentRoom"))
                        await Clients.OthersInGroup("CurrentRoom").SendAsync("removeUser", user);

                    // Join to new chat room
                    await Leave("CurrentRoom");
                    await Groups.AddToGroupAsync(Context.ConnectionId, "CurrentRoom");
                    //user.CurrentRoom = roomName;

                    // Tell others to update their list of users
                    await Clients.OthersInGroup("CurrentRoom").SendAsync("addUser", user);
                }
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("onError", "You failed to join the chat room!" + ex.Message);
            }
        }

        public async Task Leave(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public IEnumerable<PersonalChatModel> GetUsers(string roomName)
        {
            return ChatRepo.GetPersonalChat(session.GetString("UserId"), "");
        }

        public override async Task OnConnectedAsync()
        {
            
            ChatRepo.AddSignalrConnection(Context.ConnectionId, session.GetString("UserId"));
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId, session.GetString("UserId"));
            await base.OnConnectedAsync();
            //try
            //{
            //    UserLogin userLogin = new UserLogin { UserName= IdentityName };
            //    if (!_Connections.Any(u => u.UserName == IdentityName))
            //    {
            //        _Connections.Add(userLogin);
            //        _ConnectionsMap.Add(IdentityName, Context.ConnectionId);
            //    }
            //    ChatRepo.AddSignalrConnection(Context.ConnectionId, session.GetString("UserId"));
            //    Clients.Caller.SendAsync("SendUserStatus" /*user.Avatar*/);
            //}
            //catch (Exception ex)
            //{
            //    Clients.Caller.SendAsync("onError", "OnConnected:" + ex.Message);
            //}
            //return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
           
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId, session.GetString("UserId"));
            await base.OnDisconnectedAsync(ex);
        }
       
        //public override Task OnDisconnectedAsync(Exception exception)
        //{
        //    try
        //    {
        //        var user = _Connections.Where(u => u.UserName == IdentityName).First();
        //        _Connections.Remove(user);

        //        // Tell other users to remove you from their list
        //        Clients.OthersInGroup("CurrentRoom").SendAsync("removeUser", user);

        //        // Remove mapping
        //        _ConnectionsMap.Remove(user.UserName);
        //    }
        //    catch (Exception ex)
        //    {
        //        Clients.Caller.SendAsync("onError", "OnDisconnected: " + ex.Message);
        //    }

        //    return base.OnDisconnectedAsync(exception);
        //}

        private string IdentityName
        {
            get { return session.GetString("UserName"); }
        }

        private string GetDevice()
        {
            var device = Context.GetHttpContext().Request.Headers["Device"].ToString();
            if (!string.IsNullOrEmpty(device) && (device.Equals("Desktop") || device.Equals("Mobile")))
                return device;

            return "Web";
        }
    }
    ////[HubName("chatHub")]
    //public class ChatHub : Hub
    //{
    //    //public static void BroadcastData()
    //    //{
    //    //    //IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
    //    //    context.Clients.All.refreshChatData();
    //    //}

    //    public async Task SendUserStatus()
    //    {
    //        await Clients.All.SendAsync("ActiveInactiveUser");
    //    }

    //    //public async Task SendMessage(string user, string message)
    //    //{
    //    //    await Clients.All.SendAsync("ReceiveMessage", user, message);
    //    //}
    //}

   
}
