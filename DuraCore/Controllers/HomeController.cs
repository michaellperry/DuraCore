using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuraCore.Models;

namespace DuraCore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "What can we get for you?";

            return View(new Line());
        }

        [HttpPost]
        public ActionResult Checkout(Line line)
        {
            ViewBag.Message = "Here's what you ordered.";

            return View(new ShoppingCart
            {
                Item = line.Item,
                Uniquifier = Guid.NewGuid()
            });
        }

        [HttpPost]
        public ActionResult Confirmation(ShoppingCart shoppingCart)
        {
            ViewBag.Message = "Thank you for your order.";

            return View(new Confirmation
            {
                Item = shoppingCart.Item,
                ConfirmationNumber = "123"
            });
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
