using DotNetCoreMVCDemos.Hubs;
using DotNetCoreMVCDemos.Models;
using DotNetCoreMVCDemos.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Controllers
{
    public class AuthenticationController : Controller
    {
        public readonly ChatRepository ChatRepo = new ChatRepository();
        public readonly ISession session;
        private readonly IHubContext<ChatHub> _chatHub;
        public readonly AuthenticationRepository repo = new AuthenticationRepository();

        public AuthenticationController(IHttpContextAccessor httpContextAccessor, IHubContext<ChatHub> chatHub)
        {
            session = httpContextAccessor.HttpContext.Session;
            _chatHub = chatHub;    
        }

        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            System.Threading.Tasks.Task login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin LoginUser)
        {
            if (!ModelState.IsValid)
            {
                return View(LoginUser);
            }
            LoginUser = repo.UserLogin(LoginUser.Email, LoginUser.Password);
            if (!string.IsNullOrEmpty(LoginUser.Email))
            {
                session.SetString("Email", LoginUser.Email);
                session.SetString("UserId", LoginUser.UserId.ToString());
                session.SetString("UserName", LoginUser.UserName);
                session.SetString("Mobile", LoginUser.MobileNumber);
                session.SetString("Facebook", LoginUser.Facebook);
                session.SetString("Instagram", LoginUser.Instagram);
                session.SetString("Twitter", LoginUser.Twitter);
                session.SetString("Snapchat", LoginUser.Snapchat);
                session.SetString("ProfileImage", LoginUser.ProfileImage);
                ViewData["Message"] = null;
                //await _chatHub.Clients.All.SendAsync("ActiveInactiveUser");

                //await connection.InvokeAsync("SendUserStatus");

                return RedirectToAction("ChatHome", "Chat");
                
            }
            else
            {
                ViewData["Message"] = "User Login Details Failed!!";
                return View(LoginUser);
            }
        }

        [HttpPost]
        public ActionResult Register(UserRegister Register)
        {
            int code = -1;
            if (!ModelState.IsValid)
            {
                return View(Register);
            }
            code = repo.Registration(Register);
            if (code == 0)
            {
                TempData["Success"] = "User registration successfully";
                return RedirectToAction("Login");
            }
            else if (code == 2)
            {
                ViewData["Failed"] = "User already exists";
            }
            else
            {
                TempData["Success"] = null;
            }
            return View(Register);
        }

        
        public async Task<IActionResult> Logout()
        {
            int code = -1;
            code = repo.UserLogout(session.GetString("UserId"));
            if (code == 1)
            {
                //await _chatHub.Clients.All.SendAsync("ActiveInactiveUser");
                string ConnectionId = ChatRepo.GetSignalrConnection(session.GetString("UserId"));
                await _chatHub.Clients.Client(ConnectionId).SendAsync("UserDisconnected", ConnectionId, session.GetString("UserId"));
                //await connection.InvokeAsync("SendUserStatus");
            }
            HttpContext.Session.Clear();
            System.Threading.Tasks.Task login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Authentication");
        }
    }
}
