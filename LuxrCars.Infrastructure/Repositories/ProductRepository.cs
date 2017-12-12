﻿using LuxrCars.Domain.Interface.Repositories;
using LuxrCars.Domain.Models;
using LuxrCars.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Infrastructure.Repositories
{
   public class ProductRepository:IProductRepository
    {
        public ProductModel[] GetProductAvailable()
        {
            using (var context = new DataEntities())
            {
                var query = from c in context.Products
                            where c.Quantity > 0
                            select new
                            {
                                Product = c,
                                Images = c.Image

                            };
                var records = query.ToArray();

                var products = from r in records
                               let images = from i in r.Images
                                            select new ImageModel
                                            {
                                                ImageID = i.ImageID,
                                                ProductID = i.ProductID,
                                                Url = new Uri(i.Url)
                                            }
                               select new ProductModel
                               {
                                   ProductID = r.Product.ProductID,
                                   Name = r.Product.Name,
                                   Price = r.Product.Price,
                                   Quantity = r.Product.Quantity,
                                   cModel = r.Product.cModel,
                                   Year = r.Product.Year,
                                   Power = r.Product.Power,
                                   Speed = r.Product.Speed,
                                   Image = images.ToArray()

                               };
                return products.ToArray();

            }
           
        }
    }
}
