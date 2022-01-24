using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Properties.API.Options;

namespace RealEstate.Properties.API.Installers
{
    /// <summary>
    /// Represents the JWT installer
    /// </summary>
    public class JwtInstaller : IInstaller
    {
        /// <inheritdoc/>
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            IConfigurationSection jwtSection = configuration.GetSection(nameof(JwtOptions));
            services.Configure<JwtOptions>(jwtSection);
            JwtOptions jwtOptions = jwtSection.Get<JwtOptions>();
            services.AddSingleton(jwtOptions);
            byte[] key = Encoding.ASCII.GetBytes(jwtOptions.Secret);
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = !env.IsDevelopment(); // Development only
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });
            services.AddAuthorization();
        }
    }
}
