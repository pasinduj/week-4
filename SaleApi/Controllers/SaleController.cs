using ApplicationTier.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleMethods _saleMethods;

      

        public SaleController(ISaleMethods saleMethods)
        {
            _saleMethods = saleMethods;

        }


        [HttpPost(Name = "AddSale")]
        public async Task<JsonResult> AddSale(int customerId, int productId,int storeId)
        {

            var customer = await _saleMethods.AddSale(customerId, productId, storeId, DateTime.Now.AddMonths(-1));

            return new JsonResult(customer);
        }

    }
}
