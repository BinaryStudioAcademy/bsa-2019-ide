
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using IDE.API.Extensions;
﻿using IDE.DAL.Context;
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

            services.RegisterCustomServices();
            services.RegisterCustomValidators();
            services.ConfigureJwt(Configuration);

            services.AddMvcCore()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation()
                .AddAuthorization()
                .AddJsonFormatters();

            services.AddDbContext<IdeContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("IdeDBConnection")));
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

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
