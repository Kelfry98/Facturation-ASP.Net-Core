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
  
    [Route("/clients")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
  
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                _clientService.GetAll());
        }

 
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
               _clientService.GetById(id));
        }
        
     
        [HttpPost]
        public ActionResult Post([FromBody]Client model)
        {
            return Ok(
               _clientService.Add(model));
        }
        
       
        [HttpPut] 
        public ActionResult Put([FromBody]Client model)
        {
            return Ok(
               _clientService.Update(model));
        }
        
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
               _clientService.Delete(id));
        }
    }
}
