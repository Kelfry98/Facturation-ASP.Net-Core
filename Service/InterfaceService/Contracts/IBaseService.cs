using System;
using System.Collections.Generic;
using System.Text;

namespace Service.InterfaceService.Contracts
{
   public  interface IBaseService <T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Add(T model);
        bool Update(T model);
        bool Delete(int id);
    }
}
