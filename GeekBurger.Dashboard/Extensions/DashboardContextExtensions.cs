using GeekBurger.Dashboard.Model;
using GeekBurger.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekBurger.Dashboard.Extensions
{
    public static class DashboardContextExtensions
    {
        private static Random gen = new Random();
        private static Guid store = Guid.NewGuid();
        public static void Seed(this DashboardContext context)
        {
            var itemsToDelete = context.Sales.ToList();

            context.Sales.RemoveRange(itemsToDelete);
            context.SaveChanges();

            for (var i = 0; i < 10000; i++)
            {
                context.Sales.Add(GenerateSales());
            }

            context.SaveChanges();
        }

        private static Sales GenerateSales()
        {
            return new Sales
            {
                Date = RandomDay(),
                Price = RandomPrice(),
                SaleId = Guid.NewGuid(),
                StoreId = store
            };
        }

        private static DateTime RandomDay()
        {
            return DateTime.Today.AddMinutes(gen.Next(1440));
        }

        private static decimal RandomPrice()
        {
            return gen.Next(100);
        }

    }
}
