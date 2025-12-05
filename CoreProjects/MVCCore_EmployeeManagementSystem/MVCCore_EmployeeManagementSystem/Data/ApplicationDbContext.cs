using Microsoft.EntityFrameworkCore;
using MVCCore_EmployeeManagementSystem.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MVCCore_EmployeeManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasIndex(a => new { a.EmployeeId, a.Date })
                .IsUnique(); 
        }
    }
}

