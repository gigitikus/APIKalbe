using APIKalbe.Models;
using Microsoft.EntityFrameworkCore;

namespace APIKalbe.DBContext
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {

        }
        public DbSet<Invoice.Header> InvoiceHeader { get; set; }
        public DbSet<Invoice.Lines> InvoiceLine { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice.Lines>()
                .HasKey(c => new { c.InvoiceNo, c.InvoiceLineNo });
        }
    }
}
