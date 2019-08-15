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
            services.RegisterAutoMapper();

            services.RegisterCustomServices();
            services.RegisterServicesWithIConfiguration(Configuration);
            services.RegisterCustomValidators();
            services.ConfigureJwt(Configuration);
            services.ConfigureNoSqlDb(Configuration);
            services.RegisterAutoMapper();
            services.RegisterHttpClientFactories(Configuration);
            services.RegisterRabbitMQ(Configuration.GetSection("RabbitMQ").Value);

            services.AddCors();       

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
            
            UpdateDatabase(app);
            
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
