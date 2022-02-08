using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSAF16072021.Areas.admin.Controllers
{
    public class HomeController : BaseController
    {

        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            return PartialView("_AdminMenuNavbar");
        }
        //logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Default");
        }
    }
}