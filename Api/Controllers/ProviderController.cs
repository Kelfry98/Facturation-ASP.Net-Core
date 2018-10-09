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
   
    [Route("/providers")]
    public class ProviderController : Controller
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                _providerService.GetAll());
        }

    
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                _providerService.GetById(id));
        }
        
      
        [HttpPost]
        public ActionResult Post([FromBody]Provider model)
        {
            return Ok(
                _providerService.Add(model));
        }
        
      
        [HttpPut]
        public ActionResult Put([FromBody]Provider model)
        {
            return Ok(
                _providerService.Update(model));
        }
        
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                _providerService.Delete(id));
        }
    }
}
