using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Properties.Domain.Context;

namespace RealEstate.Properties.API.Installers
{
    class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            string connectionString = configuration.GetConnectionString(CommonValues.PropertiesConnection);
            DataDirectoryConfig.SetDataDirectoryPath(ref connectionString);

            services.AddDbContextPool<PropertiesContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
