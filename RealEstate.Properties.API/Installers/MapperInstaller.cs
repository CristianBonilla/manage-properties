using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using RealEstate.Properties.API.Mappings;

namespace RealEstate.Properties.API.Installers
{
    /// <summary>
    /// Represents the mapper installer
    /// </summary>
    class MapperInstaller : IInstaller
    {
        /// <inheritdoc/>
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            MapperConfiguration mapperConfiguration = MapperStart.Build();
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
