using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestShop.Application.Exceptions;
using TestShop.Application.Infrastructure;
using TestShop.Domain.Entities;

namespace TestShop.Application.Products.Queries.GetProductsList
{
    public class GetProductsListHandler : IRequestHandler<GetProductsListQuery, ICollection<Product>>
    {
        private readonly ITestShopDbContext _testShopDbContext;

        public GetProductsListHandler(ITestShopDbContext testShopDbContext)
        {
            _testShopDbContext = testShopDbContext
                                 ?? throw new ServiceConfigurationException(typeof(ITestShopDbContext));
        }

        public async Task<ICollection<Product>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            return await _testShopDbContext.Products
                .AsNoTracking()
                .OrderByDescending(x => x.CreationDate)
                .Skip(request.Offset)
                .Take(request.Count)
                .ToArrayAsync(cancellationToken);
        }
    }
}