using FluentValidation.AspNetCore;
using IDE.API.Extensions;
using IDE.BLL;
using IDE.BLL.HubConfig;
using IDE.DAL;
using IDE.DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Shared;

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
            services.RegisterCustomServices(Configuration);
            services.ConfigureJwt(Configuration);
            services.RegisterCustomValidators();

            services.AddCors();   
            services.AddSignalR();

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

            DALConfigurations.Configure(app, env);
            BLLConfigurations.Configure(app, env);


            app.UseCors(builder => builder
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("Token-Expired")
               .AllowCredentials()
               .WithOrigins("http://localhost:4200"));

            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationHub>("/notification");
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }

    }
}
