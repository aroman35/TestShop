using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TestShop.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection serviceCollection)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;
            serviceCollection.AddMediatR(assembly);
            serviceCollection.AddValidatorsFromAssembly(assembly);

            return serviceCollection;
        }
    }
}