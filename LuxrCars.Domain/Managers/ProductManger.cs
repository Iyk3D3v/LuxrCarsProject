using LuxrCars.Domain.Interface.Repositories;
using LuxrCars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Domain.Managers
{
    public class ProductManger
    {

        private IProductRepository _product;
        public ProductManger(IProductRepository product)
        {
            _product = product;
        }

      public ProductModel[] GetInventory()
        {
            return _product.GetProductAvailable();
        }


    }
}
