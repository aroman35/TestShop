using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestShop.Application.Exceptions;
using TestShop.Application.Infrastructure;
using TestShop.Domain.Entities;

namespace TestShop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly ITestShopDbContext _testShopDbContext;

        public DeleteProductHandler(ITestShopDbContext testShopDbContext)
        {
            _testShopDbContext = testShopDbContext
                                 ?? throw new ServiceConfigurationException(typeof(ITestShopDbContext));
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _testShopDbContext.Products.FindAsync(request.Id);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            _testShopDbContext.Products.Remove(product);

            await _testShopDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}