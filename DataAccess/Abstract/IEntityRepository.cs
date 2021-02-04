using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic Constraint(Generic Kisit)
    //Class : referance type
    //IEntity : It canb e Ientity or implementation from Ientity
    //new() : it must can new
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter=null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetByCategory(int categoryId);
    }
}
