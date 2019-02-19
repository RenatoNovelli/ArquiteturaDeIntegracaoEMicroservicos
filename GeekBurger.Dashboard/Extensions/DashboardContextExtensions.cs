using GeekBurger.Dashboard.Model;
using GeekBurger.Dashboard.Repository;
using System;
using System.Collections.Generic;

namespace GeekBurger.Dashboard.Extensions
{
    public static class DashboardContextExtensions
    {
        private static Random gen = new Random();
        private static Guid[] stores = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
        public static void Seed(this DashboardContext context)
        {
            context.Sales.RemoveRange(context.Sales);
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
                StoreId = RandomStore()
            };
        }

        private static Guid RandomStore()
        {
            var i = gen.Next(3);
            return stores[i];
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
