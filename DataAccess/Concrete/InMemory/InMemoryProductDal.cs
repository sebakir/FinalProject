using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //Naming Convention
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{CategoryId = 1,ProductId = 1,ProductName = "Bardak",UnitInStock = 15,UnitPrice = 15},
                new Product{CategoryId = 1, ProductId = 2, ProductName = "Kamera",UnitInStock = 3,UnitPrice = 500},
                new Product{CategoryId = 1,ProductId = 3,ProductName = "Telefon",UnitInStock = 15,UnitPrice = 1500},
                new Product{CategoryId = 1,ProductId = 4, ProductName = "Klavye", UnitInStock = 15,UnitPrice = 150},
                new Product {CategoryId = 1,ProductId = 5, ProductName = "Fare",UnitInStock = 1,UnitPrice = 85}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ -Language Intagreted Query
            Product producToDelete;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        producToDelete = p;
            //    }
            //}
            producToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(producToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul 
            Product producToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            producToUpdate.ProductName = product.ProductName;
            producToUpdate.CategoryId = product.CategoryId;
            producToUpdate.UnitInStock = product.UnitInStock;
            producToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
