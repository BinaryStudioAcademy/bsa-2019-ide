using FluentValidation.AspNetCore;
using IDE.API.Extensions;
using IDE.DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.RegisterCustomServices();
            services.RegisterServicesWithIConfiguration(Configuration);
            services.RegisterCustomValidators();
            services.ConfigureJwt(Configuration);
            services.RegisterAutoMapper();
            services.AddCors();

            services.AddMvcCore()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation()
                .AddAuthorization()
                .AddJsonFormatters();
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
            .WithOrigins("http://localhost:4200"));

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
