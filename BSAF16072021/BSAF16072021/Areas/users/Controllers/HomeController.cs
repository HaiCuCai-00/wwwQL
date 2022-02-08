 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSAF16072021.Areas.users.Controllers
{
    public class HomeController : Controller
    {
        // GET: users/Home
        public ActionResult Index()
        {
            if (Session["trainer"] == null)
            {
                return RedirectToAction("Login", "Default");
            }
            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            return PartialView("_UsersMenuNavbar");
        }

        //logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Default");
        }
    }
}