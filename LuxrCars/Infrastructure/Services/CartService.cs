
using LuxrCars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxrCars.Infrastructure.Services
{
    public class CartService 
    {
        public static string Key = "Cart";

        public List<OrderItemModel> GetCartItems()
        {
            if (HttpContext.Current.Session[Key] == null)
            {
                HttpContext.Current.Session[Key] = new List<OrderItemModel>();
            }

            return HttpContext.Current.Session[Key] as List<OrderItemModel>;

        }



        public void AddToCart(ProductModel product)
        {
            var items = GetCartItems();
            var cartItems = items.FirstOrDefault(i => i.ProductID == product.ProductID);
            if(cartItems == null)
            {
                items.Add(new OrderItemModel
                {
                    ProductID = product.ProductID,
                    Product = product,
                    Quantity = 1
                });
            }

            else
            {
                cartItems.Quantity += 1;
            }
            SaveCart(items);
        }

        public void SaveCart(List<OrderItemModel> items)
        {
            HttpContext.Current.Session[Key] = items;
        }

        public void RemoveFromCart(int productId)
        {
            var items = GetCartItems();
            var cartItems = items.FirstOrDefault(i => i.ProductID == productId);
            if (cartItems != null)
            {
                if(cartItems.Quantity > 1)
                {
                    cartItems.Quantity -= 1;
                }
               
                else
                {
                    items.Remove(cartItems);
                }
                

            }
            SaveCart(items);

        }

        public void ClearCart()
        {
            SaveCart(new List<OrderItemModel>());
        }
    }

}