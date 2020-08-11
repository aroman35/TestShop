using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestShop.Application.Infrastructure;
using TestShop.Infrastructure.Storage;
using TestShop.Infrastructure.Storage.Settings;

namespace TestShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDataStorage(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var shopDataBaseSettings = new ShopDataBaseSettings();
            configuration.GetSection(nameof(ShopDataBaseSettings)).Bind(shopDataBaseSettings);

            serviceCollection.AddDbContext<ITestShopDbContext, TestShopDbContext>(options =>
                options.UseNpgsql(shopDataBaseSettings.GetConnectionString()));

            return serviceCollection;
        }
    }
}