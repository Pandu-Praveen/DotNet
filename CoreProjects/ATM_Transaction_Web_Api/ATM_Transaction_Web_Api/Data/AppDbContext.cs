using System.Collections.Generic;
using System.Reflection.Emit;
using ATM_Transaction_Web_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM_Transaction_Web_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Account>().HasIndex(a => a.AccountNumber).IsUnique();

        //    modelBuilder
        //        .Entity<Account>()
        //        .Property(a => a.CreatedDate)
        //        .HasDefaultValueSql("GETUTCDATE()");

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
