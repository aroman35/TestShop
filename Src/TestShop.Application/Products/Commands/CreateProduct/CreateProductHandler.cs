using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestShop.Application.Exceptions;
using TestShop.Application.Infrastructure;
using TestShop.Domain.Entities;

namespace TestShop.Application.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly ITestShopDbContext _testShopDbContext;

        public CreateProductHandler(ITestShopDbContext testShopDbContext)
        {
            _testShopDbContext = testShopDbContext
                                 ?? throw new ServiceConfigurationException(typeof(ITestShopDbContext));
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Amount);

            await _testShopDbContext.Products.AddAsync(product, cancellationToken);
            await _testShopDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}