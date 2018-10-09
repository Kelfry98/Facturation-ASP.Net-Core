using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using Service.InterfaceService;

namespace Facturaction.Controllers
{
  [Route("/users")]
  public class UserController : Controller
  {
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]

    public ActionResult Get()
    {
      return Ok(
        _userService.GetAll());
    }

 
    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
      return Ok(
       _userService.GetById(id));
    }
   
    [HttpPost]
    public ActionResult Post([FromBody]User model)
    {
      return Ok(
     _userService.Add(model));
    }

  
    [HttpPut]
    public ActionResult Put([FromBody]User model)
    {
      return Ok(
     _userService.Update(model));
    }

 
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      return Ok(
           _userService.Delete(id));
    }
  }


}
