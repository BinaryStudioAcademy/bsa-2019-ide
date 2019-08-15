using IDE.DAL.Context;
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

namespace IDE.DAL
{
    public static class DALConfigurations
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBlobRepository, ArchivesBlobRepository>();
            services.AddScoped<INoSqlRepository<File>, NoSqlRepository<File>>();
            services.AddScoped<INoSqlRepository<FileHistory>, NoSqlRepository<FileHistory>>();
            services.AddScoped<IProjectStructureRepository, ProjectStructureRepository>();

            services.AddSingleton<IAzureBlobConnectionFactory>(new AzureBlobConnectionFactory(configuration));

            services.AddDbContext<IdeContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("IdeDBConnection")));

            ConfigureNoSqlDb(services, configuration);
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            UpdateDatabase(app);
        }

        private static void ConfigureNoSqlDb(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileStorageNoSqlDbSettings>(
                configuration.GetSection(nameof(FileStorageNoSqlDbSettings)));

            services.AddSingleton<IFileStorageNoSqlDbSettings>(sp =>
               sp.GetRequiredService<IOptions<FileStorageNoSqlDbSettings>>().Value);
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<IdeContext>())
                {
                    context.InitializeDatabase();
                    context.EnsureSeeded();
                }
            }
        }
    }
}
