using IDE.DAL.Context;
using IDE.DAL.Entities.Elastic;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Factories;
using IDE.DAL.Factories.Abstractions;
using IDE.DAL.Interfaces;
using IDE.DAL.Repositories;
using IDE.DAL.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Storage;

namespace IDE.DAL
{
    public static class DALConfigurations
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INoSqlRepository<File>, NoSqlRepository<File>>();
            services.AddScoped<INoSqlRepository<FileHistory>, NoSqlRepository<FileHistory>>();
            services.AddScoped<IProjectStructureRepository, ProjectStructureRepository>();
            services.AddScoped<IGitRepository, GitRepository>();
            services.AddScoped<IFileRepository, FileRepository>();


            services.AddDbContext<IdeContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("IdeDBConnection")));

            StorageConfigurations.ConfigureServices(services, configuration);
            ConfigureNoSqlDb(services, configuration);
            ConfigureElasticSearch(services, configuration);
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            UpdateDatabases(app);
        }

        private static void ConfigureElasticSearch(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISearchClientFactory>(x => new SearchClientFactory(configuration.GetSection("ElasticSearch").Value));
            services.AddScoped<FileSearchRepository>();
        }

        private static void ConfigureNoSqlDb(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileStorageNoSqlDbSettings>(
                configuration.GetSection(nameof(FileStorageNoSqlDbSettings)));

            services.AddSingleton<IFileStorageNoSqlDbSettings>(sp =>
               sp.GetRequiredService<IOptions<FileStorageNoSqlDbSettings>>().Value);
        }

        private static void UpdateDatabases(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<IdeContext>())
                {
                    var fileStorageNoSqlDbSettings = serviceScope.ServiceProvider.GetService<IFileStorageNoSqlDbSettings>();
                    context.InitializeDatabase();
                    context.EnsureSeeded(fileStorageNoSqlDbSettings);
                }
            }
        }
    }
}
