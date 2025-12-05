using Microsoft.EntityFrameworkCore;

namespace ManyToManyAPI_Demo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BookOrder> BookOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Key for the join table
            modelBuilder.Entity<BookOrder>().HasKey(bo => new { bo.BookId, bo.OrderId });

            // Relationships
            modelBuilder
                .Entity<BookOrder>()
                .HasOne(bo => bo.Book)
                .WithMany(b => b.BookOrders)
                .HasForeignKey(bo => bo.BookId);

            modelBuilder
                .Entity<BookOrder>()
                .HasOne(bo => bo.Order)
                .WithMany(o => o.BookOrders)
                .HasForeignKey(bo => bo.OrderId);
        }
    }
}
