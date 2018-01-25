using LuxrCars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxrCars.Models
{
    public class CartViewModel
    {
        public ProductModel[] Inventory { get; set; } = new ProductModel[] { };
        public List<OrderItemModel> Cart { get; set; } = new List<OrderItemModel> { };





    }
}