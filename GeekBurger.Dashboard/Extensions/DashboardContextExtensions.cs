using GeekBurger.Dashboard.Model;
using GeekBurger.Dashboard.Repository;
using System;
using System.Collections.Generic;

namespace GeekBurger.Dashboard.Extensions
{
    public static class DashboardContextExtensions
    {
        private static Random gen = new Random();

        public static void Seed(this DashboardContext context)
        {
            context.Sales.RemoveRange(context.Sales);
            context.SaveChanges();

            var storeA = Guid.NewGuid();
            var storeB = Guid.NewGuid();
            var storeC = Guid.NewGuid();

            context.Sales.AddRange(new List<Sales> {
                GenerateSales(storeA),
                GenerateSales(storeA),
                GenerateSales(storeB),
                GenerateSales(storeB),
                GenerateSales(storeB),
                GenerateSales(storeC),
                GenerateSales(storeC),
                GenerateSales(storeA)
            });

            context.SaveChanges();
        }

        private static Sales GenerateSales(Guid store)
        {
            return new Sales
            {
                Date = RandomDay(),
                Price = RandomPrice(),
                ProductId = Guid.NewGuid(),
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
