using ApplicationTier.Classes;
using ApplicationTier.Interfaces;
using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerMethods _customerMethods;

        public CustomerController(ICustomerMethods customerMethods)
        {
            _customerMethods = customerMethods;

        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<JsonResult> AddCustomer(string firstName, string lastName)
        {

            var customer = await _customerMethods.AddCustomer(firstName, lastName, DateTime.Now.AddYears(-20));

            return new JsonResult(customer); 
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public async Task<JsonResult> DeleteCustomer(int customerId)
        {

            var customer = await _customerMethods.DeleteCustomer(customerId);

            return new JsonResult(customer);
        }

    }
}
