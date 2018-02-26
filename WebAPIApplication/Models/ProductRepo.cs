using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class ProductRepo
    {
        private readonly List<Product> _products;
        private long _maxID;

        public ProductRepo()
        {
            _products = new List<Product>()
            {
                new Product { Id = 1, Name = "Bread", Category = "Food", Price = 60m},
                new Product {Id = 2, Name = "Milk", Category = "Food", Price = 100m },
                new Product {Id = 3, Name = "Porsche", Category = "Vehicle", Price = 1000000000m },
                new Product {Id = 4, Name = "Hat", Category = "Clothes", Price = 2000m },
                new Product { Id = 5, Name = "Bike", Category = "Vehicle", Price = 200000m}
            };
            _maxID = 5;
        }
        public IEnumerable<Product> GetAll()
        {
            foreach (var product in _products)
            {
                yield return product;
            }
        }

        public Product GetById(long id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetByCategory(string name)
        {
            return _products.Where(p => string.Equals(name, p.Category, StringComparison.InvariantCultureIgnoreCase));
        }

        public Product Add(Product product)
        {
            _maxID++;
            product.Id = _maxID;
            _products.Add(product);
            return product;
        }

        public bool Update(long id, Product product)
        {
            if (product == null)
                throw new ArgumentNullException();
            var storedProduct = _products.FirstOrDefault(p => p.Id == id);
            if (storedProduct == null)
                return false;
            storedProduct.Name = product.Name;
            storedProduct.Category = product.Category;
            storedProduct.Price = product.Price;
            return true;
        }

        public bool Update(long id)
        {
            var storedProduct = _products.FirstOrDefault(p => p.Id == id);
            if (storedProduct == null)
                return false;
            _products.Remove(storedProduct);
            return true;
        }
    }
}