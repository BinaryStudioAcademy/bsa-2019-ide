using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using IDE.BLL.JWT;
using IDE.BLL.Services;
using IDE.BLL.Interfaces;
using IDE.BLL.MappingProfiles;
using System;
using IDE.BLL.HubConfig;
using Microsoft.Extensions.Logging;
using IDE.BLL.Services.Queue;

namespace IDE.BLL
{
    public static class BLLConfigurations
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<JWTFactory>();

            services.AddScoped<AuthService>();
            services.AddScoped<UserService>();
            services.AddScoped<IEmailService>(x => new EmailService(Environment.GetEnvironmentVariable("emailApiKey"), configuration["CurrentWebAPIAddressForMail"], configuration["websiteMail"], x.GetService<ILogger<EmailService>>()));
            services.AddScoped<INotificationService,NotificationService>();
            services.AddScoped<IProjectMemberSettingsService, ProjectMemberSettingsService>();
            services.AddScoped<IProjectStructureService, ProjectStructureService>();
            services.AddScoped<IProjectTemplateService, ProjectTemplateService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IRightsService, RightsService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IBuildService, BuildService>();
            services.AddScoped<IInfoService, InfoService>();
            services.AddScoped<IEditorSettingService, EditorSettingService>();

            services.AddScoped<IQueueService, QueueService>();

            services.AddScoped<FileService>();
            services.AddScoped<FileHistoryService>();
            services.AddScoped<ProjectStructureService>();

            RegisterHttpClientFactories(services, configuration);
            RegisterAutoMapper(services);

            services.AddHostedService<BuildQueueSubscriberService>();
            services.AddHostedService<RunQueueSubscriberService>();
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<ProjectProfile>();
                cfg.AddProfile<ImageProfile>();
                cfg.AddProfile<BuildProfile>();
                cfg.AddProfile<FileProfile>();
                cfg.AddProfile<FileHistoryProfile>();
                cfg.AddProfile<GitCredentialProfile>();
                cfg.AddProfile<ProjectStructureProfile>();
                cfg.AddProfile<NotificationProfile>();
            });
        }

        private static void RegisterHttpClientFactories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IImageUploader, ImgurUploaderService>(client =>
            {
                var imgurClientId = configuration["BsaIdeImgurClientId"];
                var imgurApiUrl = configuration.GetSection("ImgurApiUrl").Value;

                client.BaseAddress = new Uri(imgurApiUrl);
                client.DefaultRequestHeaders.Add("Authorization", $"Client-ID {imgurClientId}");
            });
        }
    }
}
