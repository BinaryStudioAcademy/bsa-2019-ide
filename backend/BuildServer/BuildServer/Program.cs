using BuildServer.Helpers;
using BuildServer.Interfaces;
using BuildServer.Services;
using BuildServer.Services.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Shared;
using Storage;
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
            services.AddTransient<IProjectBuilder, ProjectBuilder>();

            services.AddTransient<GoConsoleBuilder>();
            services.AddTransient<TSConsoleBuilder>();
            services.AddTransient<CSharpConsoleBuilder>();
            services.Configure<CSharpConsoleBuilder>(configuration);
            services.Configure<TSConsoleBuilder>(configuration);
            services.Configure<GoConsoleBuilder>(configuration);

            services.AddTransient<IFileArchiver, FileArchiver>();
            services.Configure<FileArchiver>(configuration);

            services.AddTransient<IAzureService, AzureService>();
            services.Configure<AzureService>(configuration);
            services.AddTransient(x => new ProcessKiller(configuration));

            RabbitMQConfigurations.ConfigureServices(services, configuration);
            services.AddScoped<IQueueService, QueueService>();
            StorageConfigurations.ConfigureServices(services, configuration);
            services.AddTransient<IAzureService, AzureService>();
            services.Configure<AzureService>(configuration);

            var serviceProvider = services.BuildServiceProvider();

            // This line need for creating instance of QueueService
            var queueService = serviceProvider.GetService<IQueueService>();

            var outputDirectory = configuration.GetSection("OutputDirectory").Value;
            var buildDirectory = configuration.GetSection("BuildDirectory").Value;
            var inputDirectory = configuration.GetSection("InputDirectory").Value;
            Directory.CreateDirectory(outputDirectory);
            Directory.CreateDirectory(buildDirectory);
            Directory.CreateDirectory(inputDirectory);

            Console.WriteLine("HelloWorld");

            while (true) { }
        }
    }
}
