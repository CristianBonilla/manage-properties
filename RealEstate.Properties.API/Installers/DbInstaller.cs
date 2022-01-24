using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Properties.Domain.Context;

namespace RealEstate.Properties.API.Installers
{
    /// <summary>
    /// Represents the DB installer
    /// </summary>
    class DbInstaller : IInstaller
    {
        /// <inheritdoc/>
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            string connectionString = configuration.GetConnectionString(CommonValues.PropertiesConnection);
            DataDirectoryConfig.SetDataDirectoryPath(ref connectionString);

            services.AddDbContextPool<PropertiesContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
