using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeamTalk.Models.BAL;
using TeamTalk.Models.Entities;

namespace TeamTalk.Controllers
{

    
    public class UserController : Controller
    {
        // GET: User
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult SaveUser(User user)
        {
            BUser bu = new BUser();
            bu.Register(user);
            return View("Register");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            BUser bu = new BUser();
            bu.LogOut();
            return View("Login");
        }


        [AllowAnonymous]
        public ActionResult DoLogin(User user)
        {
            //    bool isValid = false;
            BUser bu = new BUser();
            if (bu.Login(user.Username, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.Username.ToLower(),true);
                return RedirectToAction("Home", "Home");
            }
            else
            {
                ViewBag.Wrong = "Username or password is invalid";
                return View("Login");
            }

        }

     
       



    }
}