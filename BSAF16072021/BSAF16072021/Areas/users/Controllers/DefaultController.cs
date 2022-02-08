using BSAF16072021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSAF16072021.Areas.users.Controllers
{
    public class DefaultController : Controller
    {
        private SQL160721Entities2 db = new SQL160721Entities2();
        // GET: user/Default
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["trainer"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //Post
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var usr = username;
            var pwd = password;
            var acc = db.Trainers.SingleOrDefault(x => x.trainer_name == usr && x.trainer_name == pwd);
            if (acc != null)
            {
                //đăng nhập thành công
                Session["trainer"] = "acc";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // đăng nhập thất bại 
                return View();
            }

        }
    }
}