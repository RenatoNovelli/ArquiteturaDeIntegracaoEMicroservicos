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

        public List<Sale> GetAll()
        {
            return _context.Sales?
                .ToList();
        }

        public List<Sale> GetByHour(int hour)
        {
            var date = DateTime.Now.Date;

            var start = date.AddHours(hour);
            var end = start.AddHours(1);

            return _context.Sales
                .Where(x => x.Date >= start && x.Date < end)
                .ToList();
        }

        public bool Add(Sale sale)
        {
            _context.Sales.Add(sale);
            return true;
        }

        public bool Update(Product product)
        {
            return true;
        }

    }
}
