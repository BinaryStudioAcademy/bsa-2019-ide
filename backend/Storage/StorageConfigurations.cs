using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Storage.Interfaces;

namespace Storage
{
    public static class StorageConfigurations
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBlobRepository, ArchivesBlobRepository>();
            services.AddSingleton<IAzureBlobConnectionFactory>(new AzureBlobConnectionFactory(configuration));
        }
    }
}
