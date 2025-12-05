using Microsoft.EntityFrameworkCore;
using MVC_AtmApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MVC_AtmApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.AccountNumber)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .Property(c => c.RowVersion)
                .IsRowVersion();

            // Link Transaction.AccountNumber ::: Customer.AccountNumber
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.AccountNumber)
                .HasPrincipalKey(c => c.AccountNumber);

            // Optional: store enum as string
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Type)
                .HasConversion<string>();
        }

    }
}
