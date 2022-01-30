using System;
using System.IO;
using System.Reflection;
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
        /// <summary>
        /// Get the path of the xml file for comments
        /// </summary>
        static string XmlCommentsFilePath
        {
            get
            {
                string xmlFilename = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";

                return Path.Combine(DataDirectoryConfig.DirectoryPath, xmlFilename);
            }
        }

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
                OpenApiSecurityScheme apiSecurity = new()
                {
                    Reference = new OpenApiReference
                    {
                        Id = CommonValues.Bearer,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { apiSecurity, new List<string>() } });
                options.IncludeXmlComments(XmlCommentsFilePath);
            });
        }
    }
}
