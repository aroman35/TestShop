using Microsoft.EntityFrameworkCore;
using TestShop.Application.Infrastructure;
using TestShop.Domain.Entities;

namespace TestShop.Infrastructure.Storage
{
    public class TestShopDbContext : DbContext, ITestShopDbContext
    {
        public DbSet<Product> Products { get; protected set; }
        public DbSet<ProductPhoto> ProductPhotos { get; protected set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestShopDbContext).Assembly);
        }
    }
}