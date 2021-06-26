using APIKalbe.Models;
using Microsoft.EntityFrameworkCore;

namespace APIKalbe.DBContext
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }
        public DbSet<Master.Customer> Customer { get; set; }
    }
}
