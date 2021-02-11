using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> where TEntity:class ,IEntity,new() where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())//newledikten sonra garbare collector gelip bunu bellekten atar
            {
                var addedEntity = context.Entry(entity);//Referansi al
                addedEntity.State = EntityState.Added;//Nesneyi ekle
                context.SaveChanges();//islemleri gerceklesitr
            }
        }

        public void Delete(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())//newledikten sonra garbare collector gelip bunu bellekten atar
            {
                var deletedEntry = context.Entry(entity);//Referansi al
                deletedEntry.State = EntityState.Deleted;//Nesneyi Sil
                context.SaveChanges();//islemleri gerceklesitr
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext contex = new TContext())
            {
                return contex.Set<TEntity>().SingleOrDefault(filter);//Belli nesneyi getir
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())//newledikten sonra garbare collector gelip bunu bellekten atar
            {
                var updatedEntity = context.Entry(entity);//Referansi al
                updatedEntity.State = EntityState.Modified;//Nesneyi guncelle
                context.SaveChanges();//islemleri gerceklesitr
            }
        }
    }
}
