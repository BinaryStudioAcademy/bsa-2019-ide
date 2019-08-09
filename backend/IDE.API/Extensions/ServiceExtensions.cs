using AutoMapper;
using FluentValidation;
using IDE.API.Validators;
using IDE.BLL.Interfaces;
using IDE.BLL.JWT;
using IDE.BLL.MappingProfiles;
using IDE.BLL.Services;
using IDE.BLL.Services.Abstract;
using IDE.Common.Authentification;
using IDE.Common.DTO.Authentification;
using IDE.Common.DTO.Common;
using IDE.Common.DTO.User;
using IDE.DAL.Factories;
using IDE.DAL.Factories.Abstractions;
using IDE.DAL.Repositories;
using IDE.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace IDE.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<JwtIssuerOptions>();
            services.AddScoped<JWTFactory>();
            services.AddScoped<AuthService>();
            services.AddScoped<IBlobRepository, ArchivesBlobRepository>();
            services.AddScoped<UserService>();
        }

        public static void RegisterServicesWithIConfiguration(this IServiceCollection services, IConfiguration conf)
        {
            services.AddSingleton<IAzureBlobConnectionFactory>(new AzureBlobConnectionFactory(conf));
        }

        public static void RegisterCustomValidators(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<RevokeRefreshTokenDTO>, RevokeRefreshTokenDTOValidator>();
            services.AddSingleton<IValidator<RefreshTokenDTO>, RefreshTokenDTOValidator>();

            services.AddSingleton<IValidator<UserRegisterDTO>, UserRegusterDTOValidator>();
            services.AddSingleton<IValidator<ProjectDTO>, ProjectDTOValidation>();
            services.AddSingleton<IValidator<UserLoginDTO>, UserLogInDTOValidator>();
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<ProjectProfile>();
                cfg.AddProfile<ImageProfile>();
                cfg.AddProfile<BuildProfile>();
                cfg.AddProfile<GitCredentiaProfile>();
            });
        }

        public static void RegisterHttpClientFactories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IImageUploader, ImgurUploaderService>(client =>
            {
                var imgurClientId = configuration["BsaIdeImgurClientId"];
                var imgurApiUrl = configuration.GetSection("ImgurApiUrl").Value;

                client.BaseAddress = new Uri(imgurApiUrl);
                client.DefaultRequestHeaders.Add("Authorization", $"Client-ID {imgurClientId}");
            });
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration["SecretJWTKey"];
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options => {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions => {

                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;

                configureOptions.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

    }
}
