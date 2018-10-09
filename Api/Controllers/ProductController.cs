using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.InterfaceService;

namespace Facturaction.Controllers
{
   
    [Route("/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                _productService.GetAll());
        }

        
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                _productService.GetById(id));
        }
        
       
        [HttpPost]
        public ActionResult Post([FromBody]Product model)
        {
            return Ok(
                _productService.Add(model));
        }
        
      
        [HttpPut]
        public ActionResult Put([FromBody]Product model)
        {
            return Ok(
                _productService.Update(model));
        }
        
      
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                _productService.Delete(id));
        }
    }
}
