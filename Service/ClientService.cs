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
    public class ClientService : IClientService
    {
        private readonly BusinessLogicDbContext _dbContext;
        

        public ClientService(BusinessLogicDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Client model)
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
                _dbContext.Entry(new Client { Id = id }).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<Client> GetAll()
        {
            var all = new List<Client>();
            try
            {
                all = _dbContext.Clients.ToList();
            }
            catch (Exception)
            {
            }
            return all;
        }

        public Client GetById(int id)
        {
            var result = new Client();
            try
            {
                result = _dbContext.Clients.Single(e => e.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Update(Client model)
        {
            try
            {
                var modelOriginal = _dbContext.Clients.Single(e => e.Id == model.Id);
                modelOriginal.Name = model.Name;
                modelOriginal.LastName = model.LastName;
                modelOriginal.Address = model.Address;
                modelOriginal.Email = model.Email;
                modelOriginal.Telephone = model.Telephone;
                modelOriginal.Dni = model.Dni;

                _dbContext.Update(modelOriginal);
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
