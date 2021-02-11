using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>//Dal or Dao
    {
        //interface methods are public in defaults.
        List<ProductDetailDto> GetProductDetails();
       
    }
}

//Code Refactoring
