using APIKalbe.Models;
using Microsoft.EntityFrameworkCore;

namespace APIKalbe.DBContext
{
    public class LanguageContext : DbContext
    {
        public LanguageContext(DbContextOptions<LanguageContext> options) : base(options)
        {

        }
        public DbSet<Master.Language> Language { get; set; }
    }
}
