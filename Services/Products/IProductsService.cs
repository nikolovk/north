using Entities.Models;
using System;
using System.Collections.Generic;
namespace Services.Products
{
    public interface IProductsService
    {
        List<Product> GetProducts();

        Product GetById(int id);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);
    }
}
