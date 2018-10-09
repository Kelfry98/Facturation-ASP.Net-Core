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
    public class ProductService: IProductService
    {
        private readonly BusinessLogicDbContext _dbContext;
        public ProductService(BusinessLogicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(Product model)
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
                _dbContext.Entry(new Product { Id = id }).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<Product> GetAll()
        {
            var all = new List<Product>();
            try
            {
                all = _dbContext.Products.Include(p => p.Providers).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return all;
        }

        public Product GetById(int id)
        {
            var result = new Product();
            try
            {
                result = _dbContext.Products.Single(e => e.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Update(Product model)
        {
            try
            {
                var origin = _dbContext.Products.Single(r => r.Id == model.Id);
                origin.NameProduct = model.NameProduct;
                origin.Price = model.Price;
                origin.IdProvider = model.IdProvider;
                origin.Quatity = model.Quatity;
                origin.Category = model.Category;
                origin.BrandProduct = model.BrandProduct;
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
