using FluentValidation;
using IDE.API.Validators;
using IDE.BLL;
using IDE.Common.Authentication;
using IDE.Common.DTO.Common;
using IDE.Common.DTO.File;
using IDE.Common.DTO.User;
using IDE.Common.ModelsDTO.DTO.Authentification;
using IDE.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Shared;
using System;
using System.Text;
using System.Threading.Tasks;
using IDE.Common.ModelsDTO.DTO.File;
using IDE.Common.DTO.Project;

namespace IDE.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<JwtIssuerOptions>();

            BLLConfigurations.ConfigureServices(services, configuration);

            DALConfigurations.ConfigureServices(services, configuration);

            RabbitMQConfigurations.ConfigureServices(services, configuration);
        }

        public static void RegisterCustomValidators(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<RevokeRefreshTokenDTO>, RevokeRefreshTokenDTOValidator>();
            services.AddSingleton<IValidator<RefreshTokenDTO>, RefreshTokenDTOValidator>();
            services.AddSingleton<IValidator<UserRegisterDTO>, UserRegisterDTOValidator>();
            services.AddSingleton<IValidator<ProjectDTO>, ProjectDTOValidation>();
            services.AddSingleton<IValidator<UserLoginDTO>, UserLogInDTOValidator>();
            services.AddSingleton<IValidator<FileCreateDTO>, FileCreateDTOValidator>();
            services.AddSingleton<IValidator<FileUpdateDTO>, FileUpdateDTOValidator>();
            services.AddSingleton<IValidator<FileRenameDTO>, FileRenameDTOValidator>();
            services.AddSingleton<IValidator<ProjectCreateDTO>, ProjectCreateDTOValidator>();
            services.AddSingleton<IValidator<ProjectUpdateDTO>, ProjectUpdateDTOValidator>();
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = "some_big_key_value_here_secret";// configuration["SecretJWTKey"];
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
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
            }).AddJwtBearer(configureOptions =>
            {
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