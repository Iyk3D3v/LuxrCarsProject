using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxrCars.Controllers  
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Place()
        {
            return Content($"{User.Identity.Name}, you have placed an order");
        }
    }
}