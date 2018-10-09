using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.ViewModel;
using Service.InterfaceService;

namespace Facturaction.Controllers
{
    [Route("/buys")]
    public class BuyController : Controller
    {
        private readonly IBuyService _buyService;

        public BuyController(IBuyService buyService)
        {
            _buyService = buyService;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                _buyService.GetAll());  
            
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                _buyService.GetById(id));
        }


        [HttpPost]
        public ActionResult Post([FromBody]ProductVM model)
        {
            return Ok(
                _buyService.Add(model));
        }

        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                _buyService.Delete(id));
        }
    }
}
