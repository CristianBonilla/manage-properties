using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.Properties.API.Installers
{
    interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env);
    }
}
