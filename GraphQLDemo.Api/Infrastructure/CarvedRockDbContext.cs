using GraphQLDemo.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Api.Data
{
    public class CarvedRockDbContext: DbContext
    {
        public CarvedRockDbContext(DbContextOptions<CarvedRockDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductReview>()
                .HasOne(r=> r.Product)
                .WithMany(r=> r.ProductReviews)
                .HasForeignKey(r=>r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
