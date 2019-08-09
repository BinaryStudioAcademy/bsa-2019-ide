using FluentValidation.AspNetCore;
using IDE.API.Extensions;
using IDE.DAL.Context;
using IDE.DAL.Interfaces;
using IDE.DAL.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IDE.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdeContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("IdeDBConnection")));
            services.RegisterAutoMapper();

            services.RegisterCustomServices();
            services.RegisterServicesWithIConfiguration(Configuration);
            services.RegisterCustomValidators();
            services.ConfigureJwt(Configuration);
            services.RegisterAutoMapper();
            services.RegisterHttpClientFactories(Configuration);
            services.AddCors();

            // TODO IN THIS TASK remove to extentions

            services.Configure<FileStorageNoSqlDbSettings>(
                Configuration.GetSection(nameof(FileStorageNoSqlDbSettings)));

            services.AddSingleton<IFileStorageNoSqlDbSettings>(sp =>
               sp.GetRequiredService<IOptions<FileStorageNoSqlDbSettings>>().Value);

            //_______________________________________________________

            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Token-Expired")
                .AllowCredentials()
                .AllowAnyOrigin());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
