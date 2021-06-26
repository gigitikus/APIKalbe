using APIKalbe.Models;
using System.Collections.Generic;

namespace APIKalbe.Services
{
    public interface ICustomerService
    {
        List<Master.Customer> GetCustomers();
        Master.Customer GetCustomer(string CustomerId);
    }
}
