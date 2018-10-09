using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Model;
using Service.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
  public class UserService : IUserService

  {
    //injectar la dependencia de BusinessLogicDbContext
    //readonly define que dicho calor solo se puede modificar en un constructor
    private readonly BusinessLogicDbContext _businessLogicDbContext;

    public UserService(
      BusinessLogicDbContext businessLogicDbContext)
    {
      _businessLogicDbContext = businessLogicDbContext;
    }
    public bool Add(User model)
    {
      try
      {
        _businessLogicDbContext.Add(model);
        _businessLogicDbContext.SaveChanges();
      }
      catch (Exception)
      {

        return false;
      }
      return true;
    }

    public bool Update(User model)
    {
            try
            {
                var origin = _businessLogicDbContext.Users.Single(r => r.Id == model.Id);
                origin.LastName = model.LastName;
                origin.Name = model.Name;
                origin.Password = model.Password;
                origin.Telephone = model.Telephone;
                origin.UserName = model.UserName;
                origin.Email = model.Email;
                origin.Dni = model.Dni;
                origin.Authorize = model.Authorize;
                origin.Address = model.Address;
                _businessLogicDbContext.Update(origin);
                _businessLogicDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
    }


    public IEnumerable<User> GetAll()
    {
      var all = new List<User>();
      try
      {
        all = _businessLogicDbContext.Users.ToList();
      }
      catch (Exception)
      {
      }
      return all;
    }

    public bool Delete(int id)
    {
      try
      {
        _businessLogicDbContext.Entry(new User {Id = id }).State = EntityState.Deleted;
        _businessLogicDbContext.SaveChanges();
      }
      catch (Exception)
      {

        return false;
      }
      return true;
    }

        public User GetById(int id)
        {
            var result = new User();
            try
            {
                result = _businessLogicDbContext.Users.Single(e => e.Id == id);
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
