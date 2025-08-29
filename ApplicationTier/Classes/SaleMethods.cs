using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationTier.Dtos;
using ApplicationTier.Interfaces;
using IndustryConnect_Week_Microservices.Models;

namespace ApplicationTier.Classes
{
    public class SaleMethods : ISaleMethods
    {
        public SaleMethods() { }

        public async Task<SaleDto> AddSale(int customerId, int productId, int storeId, DateTime? dateSold)
        {
            var context = new IndustryConnectWeek2Context();

            var sale = new Sale
            {
                CustomerId = customerId,
                ProductId = productId,
                StoreId = storeId,
                DateSold = dateSold
            };

            context.Add(sale);

            await context.SaveChangesAsync();

            return Mapper(sale);

        }



        private static SaleDto Mapper(Sale? sale)
        {
            if (sale != null)
            {
                var saleDto = new SaleDto
                {
                    CustomerId = sale?.CustomerId,
                    ProductId = sale?.ProductId,
                    StoreId = sale?.StoreId,
                    DateSold = sale?.DateSold,
                    Id = sale.Id
                };

                return saleDto;
            }
            else
            {
                return null;
            }

        }


    }
}
