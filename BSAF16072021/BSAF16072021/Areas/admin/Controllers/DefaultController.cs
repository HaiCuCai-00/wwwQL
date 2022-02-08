using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using BSAF16072021.Models;

namespace BSAF16072021.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        private SQL160721Entities2 db = new SQL160721Entities2();
        // GET: admin/Default
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["admin"] != null)
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
            var acc = db.Admins.SingleOrDefault(x => x.admin_name == usr && x.admin_password == pwd);
            if (acc != null)
                {
                //đăng nhập thành công
                Session["admin"] = "acc";
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