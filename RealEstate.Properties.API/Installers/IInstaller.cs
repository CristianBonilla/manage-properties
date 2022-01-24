using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.Properties.API.Installers
{
    /// <summary>
    /// Represents the installer for specific features, via dependencies injection
    /// </summary>
    interface IInstaller
    {
        /// <summary>
        /// Sets the services to be installed specifically
        /// </summary>
        /// <param name="services">Collection to establish new services</param>
        /// <param name="configuration">Key and value properties configuration</param>
        /// <param name="env">Gets the running environment variables of the application</param>
        void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env);
    }
}
