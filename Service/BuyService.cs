using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.ViewModel;
using Service.InterfaceService;
using Service.InterfaceService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class BuyService: IBuyService
    {
        private readonly BusinessLogicDbContext _dbContext;
        public BuyService(BusinessLogicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(ProductVM model)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                model.Buys.DateBuy = DateTime.Parse(dateTime.ToShortDateString());
                _dbContext.Add(model);
                _dbContext.SaveChanges();
                var max = _dbContext.Buys.Max(e => e.Id);
                BuyProduct buyProduct;
                foreach (var item in model.Products)
                {
                    buyProduct = new BuyProduct();
                    buyProduct.Id = item.Id;
                    buyProduct.IdBuy = max;
                    buyProduct.Quatity = item.Quatity;
                    _dbContext.BuyProducts.Add(buyProduct);
                    _dbContext.SaveChanges();

                    var NQuantity = _dbContext.Products.Find(buyProduct.IdProduct);
                    NQuantity.Quatity = NQuantity.Quatity - item.Quatity;
                    _dbContext.Products.Update(NQuantity);
                    _dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _dbContext.Entry(new Buy { Id = id }).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<Buy> GetAll()
        {
            var all = new List<Buy>();
            try
            {
                all = _dbContext.Buys.Include(b => b.IdClient)
                                     .Include(b => b.IdUser)
                                     .ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return all;
        }

        public Buy GetById(int id)
        {
            var result = new Buy();
            try
            {
                result = _dbContext.Buys.Single(e => e.Id == id);

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Update(Buy model)
        {
            try
            {
                var modelOriginal = _dbContext.Buys.Single(e => e.Id == model.Id);
      
                modelOriginal.TotalBuy = model.TotalBuy;
                modelOriginal.TotalArticle = model.TotalArticle;
                modelOriginal.IdUser = model.IdUser;
                modelOriginal.IdClient = model.IdClient;
                modelOriginal.DateBuy = model.DateBuy;

                _dbContext.Update(modelOriginal);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;

        }

        public bool Update(ProductVM model)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ProductVM> IBaseService<ProductVM>.GetAll()
        {
            throw new NotImplementedException();
        }

        ProductVM IBaseService<ProductVM>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
