using LuxrCars.Domain.Managers;
using LuxrCars.Infrastructure;
using LuxrCars.Infrastructure.Data;

using LuxrCars.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxrCars.Controllers
{
    public class HomeController : Controller
    {
        private ProductManger _products;
        public HomeController()
        {
            var productRepo = new ProductRepository();
            _products = new ProductManger(productRepo);
        }
        // GET: Home
        public ActionResult Index()
        {
           var products = _products.GetInventory();
            return View(products);
        }
    }
}