using BuildServer.Interfaces;
using BuildServer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Shared;
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
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.development.json", true, true)
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

            RabbitMQConfigurations.ConfigureServices(services, configuration);
            services.AddScoped<IQueueService, QueueService>();

            var serviceProvider = services.BuildServiceProvider();

            // This line need for creating instance of QueueService
            var queueService = serviceProvider.GetService<IQueueService>();

            Console.WriteLine("HelloWorld");

            while (true)
            {

            }
        }
    }
}
