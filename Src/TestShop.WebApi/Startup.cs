using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestShop.Infrastructure.Extensions;

namespace TestShop.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers();
            serviceCollection.ConfigureDataStorage(_configuration);
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            applicationBuilder.UseHttpsRedirection();

            applicationBuilder.UseRouting();

            applicationBuilder.UseAuthorization();
            // UseCache
            // UseValidations

            applicationBuilder.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}