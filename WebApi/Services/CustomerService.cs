using APIKalbe.DBContext;
using APIKalbe.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerContext _customerService;
        public CustomerService(CustomerContext customerContext)
        {
            _customerService = customerContext;
        }
        public List<Master.Customer> GetCustomers()
        {
            return _customerService.Customer.ToList();
        }
        public Master.Customer GetCustomer(string CustomerId)
        {
            return _customerService.Customer.FirstOrDefault(x => x.CustomerId.Trim() == CustomerId);
        }
    }
}
