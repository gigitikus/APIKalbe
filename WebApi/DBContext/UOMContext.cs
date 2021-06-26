using APIKalbe.Models;
using Microsoft.EntityFrameworkCore;

namespace APIKalbe.DBContext
{
    public class UOMContext : DbContext
    {
        public UOMContext(DbContextOptions<UOMContext> options) : base(options)
        {

        }
        public DbSet<Master.UnitOfMeasure> UnitOfMeasure { get; set; }
    }
}
