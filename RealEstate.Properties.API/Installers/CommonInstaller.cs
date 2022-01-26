using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.Properties.API.Installers
{
    /// <summary>
    /// Represents the common installer
    /// </summary>
    public class CommonInstaller : IInstaller
    {
        /// <inheritdoc/>
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers()
                .AddNewtonsoftJson(JsonSerializer);
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.UseApiBehavior = false;
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddRouting(options => options.LowercaseUrls = true);
            //Another alternative - services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddCors(options =>
            {
                options.AddPolicy(CommonValues.AllowOrigins, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .WithMethods("GET", "POST", "PUT", "DELETE");
                });
            });
        }

        /// <summary>
        /// Configures the JSON serializer for the APIs
        /// </summary>
        /// <param name="options">JSON format options</param>
        private void JsonSerializer(MvcNewtonsoftJsonOptions options)
        {
            JsonSerializerSettings settings = options.SerializerSettings;
            settings.Converters.Add(new StringEnumConverter());
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.Formatting = Formatting.None;
        }
    }
}
