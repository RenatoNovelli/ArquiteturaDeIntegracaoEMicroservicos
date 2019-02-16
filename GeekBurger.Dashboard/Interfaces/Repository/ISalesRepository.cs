using GeekBurger.Dashboard.Model;
using System;
using System.Collections.Generic;

namespace GeekBurger.Dashboard.Interfaces.Repository
{
    public interface ISalesRepository
    {
        List<Sales> GetAll();
        List<Sales> GetByInterval(DateTime start, DateTime end);
        bool Add(Sales sale);
    }
}
