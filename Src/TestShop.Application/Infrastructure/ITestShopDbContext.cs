using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TestShop.Domain.Entities;

namespace TestShop.Application.Infrastructure
{
    public interface ITestShopDbContext : IDisposable, IAsyncDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<Domain.Entities.Product> Products { get; }
        DbSet<ProductPhoto> ProductPhotos { get; }
        DatabaseFacade Database { get; }
    }
}