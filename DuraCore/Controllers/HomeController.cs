using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuraCore.Database;
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
            Order order = null;
            using (var context = new OrderContext())
            {
                order = new Order
                {
                    Item = shoppingCart.Item,
                    Uniquifier = shoppingCart.Uniquifier
                };
                context.Orders.Add(order);

                context.SaveChanges();
            }

            ProcessOrder(order.OrderId);

            ViewBag.Message = "Thank you for your order.";

            return View(new Confirmation
            {
                Item = shoppingCart.Item,
                ConfirmationNumber = "CN" + order.OrderId
            });
        }

        public ActionResult Shipments()
        {
            List<Confirmation> model;
            using (var context = new OrderContext())
            {
                var shipments =
                    from s in context.Shipments
                    orderby s.ShipmentId descending
                    select new { s.Order.Item, s.Order.OrderId };

                model = shipments
                    .AsEnumerable()
                    .Select(s => new Confirmation
                    {
                        Item = s.Item,
                        ConfirmationNumber = "CN" + s.OrderId
                    })
                    .ToList();
            }
            return View(model);
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

        private void ProcessOrder(int orderId)
        {
            using (var context = new OrderContext())
            {
                context.Shipments.Add(new Shipment { OrderId = orderId });

                context.SaveChanges();
            }
        }
    }
}
