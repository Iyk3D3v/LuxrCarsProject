using LuxrCars.Domain.Managers;
using LuxrCars.Infrastructure.Repositories;
using LuxrCars.Infrastructure.Services;
using LuxrCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxrCars.Controllers
{
    public class CartController : Controller
    {
        private CartService _cart;
        private ProductManger _products;

        public CartController()
        {
            var productRepo = new ProductRepository();
            _products = new ProductManger(productRepo);
            _cart = new CartService();
        }
        // GET: Cart
        public ActionResult Details()
        {
            var model = new CartViewModel
            {
                Inventory = _products.GetInventory(),
                Cart = _cart.GetCartItems()

            };
            return View(model);
        }

        public ActionResult Add (int id = 0)
        {
            var product = _products.GetProduct(id);
            _cart.AddToCart(product);

            return RedirectToAction("Details","Cart");

        }

        public ActionResult Remove(int id = 0)
        {
            
            _cart.RemoveFromCart(id);
          
            return RedirectToAction("Details","Cart");  

        }


    }
}