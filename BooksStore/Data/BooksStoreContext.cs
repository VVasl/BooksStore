using BooksStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Data
{
    public class BooksStoreContext : DbContext
    {
        public BooksStoreContext(DbContextOptions<BooksStoreContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>(entity =>
            {
                //entity.Property(p => p.Title)
                //      .IsRequired()
                //      .HasMaxLength(100);

                entity.Property(p => p.Price)
                      .HasColumnType("decimal(18,2)");

            });

            builder.Entity<OrderItem>()
                .Property(p => p.UnitPrice)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
