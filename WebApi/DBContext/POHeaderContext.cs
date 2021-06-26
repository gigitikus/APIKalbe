using APIKalbe.Models;
using Microsoft.EntityFrameworkCore;
namespace APIKalbe.DBContext
{
    public class POHeaderContext : DbContext
    {
        public POHeaderContext(DbContextOptions<POHeaderContext> options) : base(options)
        {

        }

        public DbSet<Transactions.POHeader> PurchaseOrderHeader { get; set; }
    }
}
