using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuraCore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "What can we get for you?";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Demo app for \"Don't Click Submit Twice!!!\"";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Michael L Perry";

            return View();
        }
    }
}
