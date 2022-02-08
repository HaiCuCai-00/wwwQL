using BSAF16072021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSAF16072021.Areas.training.Controllers
{
    public class DefaultController : Controller
    {
        private SQL160721Entities2 db = new SQL160721Entities2();
        // GET: Admin/Default
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["training"] != null)
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
            var acc = db.Trainings.SingleOrDefault(x => x.training_name == usr && x.training_password == pwd);
            if (acc != null)
            {
                //đăng nhập thành công
                Session["training"] = "acc";
                return RedirectToAction("Index", "Home");
            }
            else if  (acc == null)
                {
                var acca = db.Admins.SingleOrDefault(x => x.admin_name == usr && x.admin_password == pwd);
                if (acca != null)
                {
                    //đăng nhập thành công
                    Session["admin"] = "acca";
                    return RedirectToAction("Index", "Home");
                }
            }
            {
                // đăng nhập thất bại 
                return View();
            }

        }
    }
}