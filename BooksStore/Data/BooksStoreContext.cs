using BooksStore.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Data
{
    public class BooksStoreContext : IdentityDbContext<StoreUser>
    {
        public BooksStoreContext(DbContextOptions<BooksStoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>(entity =>
            {
                entity.Property(p => p.Price)
                      .HasColumnType("decimal(18,2)");

            });

            builder.Entity<OrderItem>()
                .Property(p => p.UnitPrice)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
