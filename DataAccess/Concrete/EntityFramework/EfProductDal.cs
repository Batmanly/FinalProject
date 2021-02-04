using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext())//newledikten sonra garbare collector gelip bunu bellekten atar
            {
                var addedEntity = context.Entry(entity);//Referansi al
                addedEntity.State = EntityState.Added;//Nesneyi ekle
                context.SaveChanges();//islemleri gerceklesitr
            }
        }

        public void Delete(Product entity)
        {
            //IDisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext())//newledikten sonra garbare collector gelip bunu bellekten atar
            {
                var deletedEntry = context.Entry(entity);//Referansi al
                deletedEntry.State = EntityState.Deleted;//Nesneyi Sil
                context.SaveChanges();//islemleri gerceklesitr
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {
                return contex.Set<Product>().SingleOrDefault(filter);//Belli nesneyi getir
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public List<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            //IDisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext())//newledikten sonra garbare collector gelip bunu bellekten atar
            {
                var updatedEntity = context.Entry(entity);//Referansi al
                updatedEntity.State = EntityState.Modified;//Nesneyi guncelle
                context.SaveChanges();//islemleri gerceklesitr
            }
        }
    }
}
