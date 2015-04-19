using Entities.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Products
{
    public class ProductsService : Services.Products.IProductsService
    {
        private IUowData uowData;

        public ProductsService(IUowData uowData)
        {
            this.uowData = uowData;
        }

        public List<Product> GetProducts()
        {
            var products = this.uowData.Products.All().ToList();
            return products;
        }

        public Product GetById(int id)
        {
            Product product = this.uowData.Products.GetById(id);
            return product;
        }

        public void AddProduct(Product product)
        {
            this.uowData.Products.Add(product);
            this.uowData.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            this.uowData.Products.Update(product);
            this.uowData.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            this.uowData.Products.Delete(id);
            this.uowData.SaveChanges();
        }
    }
}
