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
    public class ProviderService : IProviderService
    {
        private readonly BusinessLogicDbContext _dbContext;

        public ProviderService(BusinessLogicDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Provider model)
        {
            try
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _dbContext.Entry(new Provider { Id = id }).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<Provider> GetAll()
        {
            var all = new List<Provider>();
            try
            {
                all = _dbContext.Providers.ToList();
            }
            catch (Exception)
            {
            }
            return all;
        }

        public Provider GetById(int id)
        {
            var result = new Provider();
            try
            {
                result = _dbContext.Providers.Single(e => e.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Update(Provider model)
        {
            try
            {
                var origin = _dbContext.Providers.Single(r => r.Id == model.Id);
                origin.LastName = model.LastName;
                origin.Name = model.Name;
                origin.NameCompany = model.NameCompany;
                origin.Telephone = model.Telephone;
                origin.Address = model.Address;
                origin.Dni = model.Dni;
                origin.Email = model.Email;
                _dbContext.Update(origin);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                
                return false;
            }
            return true;
        }
    }
}
