using LuxrCars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Domain.Interface.Repositories
{
   public interface IProductRepository
    {
        ProductModel[] GetProductAvailable();

        ProductModel GetProductsById(int y);

    }
}
