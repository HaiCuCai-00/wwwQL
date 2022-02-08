using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSAF16072021.Areas.training.Controllers
{
    public class HomeController : Controller
    {
        // GET: Training/Home
        public ActionResult Index()
        {
            // kiểm tra có phải là admin hay training ko
            /*   if (Session["training"] == null )
               { 
                   if (Session["admin"] == null)
                   {
                       return RedirectToAction("Login", "Default");
                   }
               }
             */
            if (Session["training"] == null)
            {
               return RedirectToAction("Login", "Default");
            }
            return View();


        }


        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            return PartialView("_TrainingMenuNavbar");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Default");
        }
    }
}