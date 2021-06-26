using APIKalbe.Models;
using Microsoft.EntityFrameworkCore;

namespace APIKalbe.DBContext
{
    public class NoSeriesContext : DbContext
    {
        public NoSeriesContext(DbContextOptions<NoSeriesContext> options) : base(options)
        {

        }
        public DbSet<Master.NoSeries> NoSeries { get; set; }
    }
}
