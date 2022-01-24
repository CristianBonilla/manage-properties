using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Properties.API.Options;

namespace RealEstate.Properties.API.Installers
{
    /// <summary>
    /// Represents the Swagger installer
    /// </summary>
    class SwaggerInstaller : IInstaller
    {
        /// <inheritdoc/>
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            IConfigurationSection swaggerSection = configuration.GetSection(nameof(SwaggerOptions));
            services.Configure<SwaggerOptions>(swaggerSection);
            SwaggerOptions swagger = swaggerSection.Get<SwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new()
                {
                    Title = "Real Estate Properties API",
                    Version = "v1",
                    Description = "API to get property information, stored from a database",
                    Contact = swagger.Contact
                });
                options.AddSecurityDefinition(CommonValues.Bearer, new()
                {
                    Description = "JWT Authentication header using the bearer scheme",
                    Name = "Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = CommonValues.Bearer,
                    BearerFormat = "JWT"
                });
                OpenApiSecurityScheme apiSecurity = new()
                {
                    Reference = new OpenApiReference
                    {
                        Id = CommonValues.Bearer,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { apiSecurity, new List<string>() } });
            });
        }
    }
}
