using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Entities
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Define relationship between Invoices and InvoiceLines
            builder.Entity<InvoiceLine>()
                .HasOne(x => x.Invoice)
                .WithMany(x => x.InvoiceLines);
           
        }

    }
}
