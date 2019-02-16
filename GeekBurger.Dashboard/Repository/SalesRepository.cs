using GeekBurger.Dashboard.Interfaces.Repository;
using GeekBurger.Dashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekBurger.Dashboard.Repository
{
    public class SalesRepository : ISalesRepository
    {
        private SalesContext _context;

        public SalesRepository(SalesContext context)
        {
            _context = context;
        }

        public List<Sales> GetAll()
        {
            return _context.Sales?
                .ToList();
        }

        public List<Sales> GetByInterval(DateTime start, DateTime end)
        {
            return _context.Sales
                .Where(x => x.Date >= start && x.Date < end)
                .ToList();
        }

        public bool Add(Sales sale)
        {
            _context.Sales.Add(sale);
            return true;
        }

    }
}
