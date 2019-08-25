using BuildServer.Interfaces;
using BuildServer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace BuildServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration;

            configuration = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
            .AddJsonFile(@"appsettings.json")
            .Build();

            //setup our DI
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<IBuilder, DotNetBuilder>();
            services.Configure<DotNetBuilder>(configuration);
            services.AddTransient<IFileArchiver, FileArchiver>();
            services.Configure<FileArchiver>(configuration);
            services.AddTransient<IAzureService, AzureService>();
            services.Configure<AzureService>(configuration);

            var serviceProvider = services.BuildServiceProvider();

            //will be endless cycle with queue
            string fileName = "HelloWorld";

            Worker worker = new Worker(
                serviceProvider.GetService<IBuilder>(),
                serviceProvider.GetService<IFileArchiver>(),
                serviceProvider.GetService<IAzureService>());

            worker.Work(fileName);
        }
    }
}
