using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Attribute >> java Annotation
    public class ProductsController : ControllerBase //api products ile erisliyor
    {
        //Bir gelisitirici gelecekte gelecek talplerede dikkate almak.
        //Loosely Coupled -- Gevsek baglilik
        //naming convention -- isimlendirme standarti
        //hicbirsey somut sinif ustunden gitmiyor suan
        //IOC Container -- Inversion of Control -- degisimin kontrolu
        IProductService _productService;//Field
        public ProductsController(IProductService productService)
        {
            _productService = productService; //referansi aldik , fielde verdik heryerden erisebiliriz art8ik
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //return new List<Product>
            //{
            //    new Product{ProductId =1 , ProductName="Elma"},
            //    new Product{ProductId =2 , ProductName="Armut"},

            //};
            //Dependency Chain --- Bagimlilik Zinciri
            // _productService = new ProductManager(new EfProductDal());

            //swagger >> default documentasyon api icin 
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);//200 status code
            }

            return BadRequest(result); 
            
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        
    }
}
