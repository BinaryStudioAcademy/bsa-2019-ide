using FluentValidation.AspNetCore;
using IDE.API.Extensions;
using IDE.BLL;
using IDE.BLL.HubConfig;
using IDE.BLL.Interfaces;
using IDE.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IDE.API
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        public Startup(IConfiguration configuration , ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
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

            //var serviceProvider = services.BuildServiceProvider();
            //var queueService = serviceProvider.GetService<IQueueService>();
            //queueService.ConfigureSubscription();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _logger.LogInformation("In Development environment");
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
                .WithExposedHeaders("Token-Expired", "Content-Disposition")
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
