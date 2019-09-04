using BuildServer.Helpers;
using BuildServer.Interfaces;
using BuildServer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
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
            var logger = LogManager.GetCurrentClassLogger();
             try
            {
            IConfiguration configuration;

            configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.development.json", true, true)
                .Build();
               LogManager.Configuration = new NLogLoggingConfiguration(configuration.GetSection("NLog"));
            //setup our DI
           
            var serviceProvider = BuildDi(configuration);

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
            catch (Exception ex)
            { // NLog: catch any exception and log it.
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Shutdown();
            }
        }

        private static IServiceProvider BuildDi(IConfiguration config)
        {
            return ConfigureDi(new ServiceCollection(), config).BuildServiceProvider();
        }

        private static IServiceCollection ConfigureDi(IServiceCollection services, IConfiguration config)
        {
            RabbitMQConfigurations.ConfigureServices(services, config);
            StorageConfigurations.ConfigureServices(services, config);
            return services
                        .AddSingleton<IConfiguration>(config)
                        .AddTransient<IBuilder, DotNetBuilder>()
                        .Configure<DotNetBuilder>(config)
                        .AddTransient<IFileArchiver, FileArchiver>()
                        .Configure<FileArchiver>(config)
                        .AddTransient<IAzureService, AzureService>()
                        .Configure<AzureService>(config)
                        .AddTransient(x => new ProcessKiller(config))
                        .AddScoped<IQueueService, QueueService>()
                        .AddLogging(loggingBuilder =>
                            {
                            // configure Logging with NLog
                                loggingBuilder.ClearProviders();
                                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                                loggingBuilder.AddNLog();
                            })
                        .AddTransient<IAzureService, AzureService>()
                        .Configure<AzureService>(config);
        }
    }
}
