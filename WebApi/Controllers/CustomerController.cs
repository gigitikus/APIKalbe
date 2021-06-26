using APIKalbe.Models;
using APIKalbe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/Customer/GetCustomers")]
        public IEnumerable<Master.Customer> GetCustomers()
        {
            return _customerService.GetCustomers().OrderBy(c => c.CompanyName);
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/Customer/GetCustomer/{CustomerId?}")]
        public Master.Customer GetCustomer(string customerId)
        {
            return _customerService.GetCustomer(customerId);
        }
    }
}
