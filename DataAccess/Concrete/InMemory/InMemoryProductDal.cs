using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//global value
        public InMemoryProductDal()//when InMemoryProductDal created it will work
        {
            //Oracle,Sql Server, Postgres, MongoDb
            _products = new List<Product>
            {
                new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15 },
                new Product{CategoryId=2,ProductId=2,ProductName="kamera",UnitPrice=500,UnitsInStock=3 },
                new Product{CategoryId=3,ProductId=3,ProductName="telefon",UnitPrice=1500,UnitsInStock=2 },
                new Product{CategoryId=4,ProductId=4,ProductName="klavye",UnitPrice=150,UnitsInStock=65 },
                new Product{CategoryId=5,ProductId=5,ProductName="fare",UnitPrice=85,UnitsInStock=1 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ -- Lnaguage Integraded Query
            //Lambda p=>
            Product productToDelete = null;//dont have referance yet
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;//it will take referance
            //    }
            //}

            productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList(); // yeni liste olusturup dondurur
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gonderdigim urun id'sine sahip olan listedeki urunu bul
            Product productToUpdate = null;
            productToUpdate  = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            product.UnitsInStock = product.UnitsInStock;

        }
    }
}
