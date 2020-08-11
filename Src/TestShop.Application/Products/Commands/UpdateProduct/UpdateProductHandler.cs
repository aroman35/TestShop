using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestShop.Application.Exceptions;
using TestShop.Application.Infrastructure;
using TestShop.Domain.Entities;

namespace TestShop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly ITestShopDbContext _testShopDbContext;

        public UpdateProductHandler(ITestShopDbContext testShopDbContext)
        {
            _testShopDbContext = testShopDbContext
                                 ?? throw new ServiceConfigurationException(typeof(ITestShopDbContext));
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _testShopDbContext.Products.FindAsync(request.Id, cancellationToken);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            product.UpdateState(request.Name, request.Description, request.Amount);

            _testShopDbContext.Products.Update(product);
            await _testShopDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}