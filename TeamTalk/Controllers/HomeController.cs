using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamTalk.Models.BAL;
using TeamTalk.Models.Entities;
using Newtonsoft.Json;

namespace TeamTalk.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadMessages(Messages msg)
        {
            BMessages bm = new BMessages();
            var msgs = bm.LoadMessages(msg.FromUser, msg.ToUser, msg.CreateDate);
            return Json(JsonConvert.SerializeObject(msgs), JsonRequestBehavior.AllowGet);
        }

        public ActionResult _OnlineUser()
        {
            BUser bu = new BUser();
            var OnlineUsers = bu.GetOnlineUsers();
            var OfflineUsers = bu.GetOfflineUsers();
            dynamic TeamTalkers = new ExpandoObject();
            TeamTalkers.OnlineUser = OnlineUsers;
            TeamTalkers.OfflineUser = OfflineUsers;
            return View("_UserList", TeamTalkers);
        }

    }
}