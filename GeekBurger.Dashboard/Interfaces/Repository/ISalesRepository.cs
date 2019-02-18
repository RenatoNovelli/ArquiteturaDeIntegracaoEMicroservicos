using GeekBurger.Dashboard.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Interfaces.Repository
{
    public interface ISalesRepository
    {
        Task<List<Sales>> GetAll();
        Task<List<Sales>> GetByInterval(DateTime start, DateTime end);
        Task Add(Sales sale);
    }
}
