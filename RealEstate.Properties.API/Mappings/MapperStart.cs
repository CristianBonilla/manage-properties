using AutoMapper;

namespace RealEstate.Properties.API.Mappings
{
    /// <summary>
    /// Initialize the mapping configuration
    /// </summary>
    class MapperStart
    {
        /// <summary>
        /// Set the necessary configuration for the mappings
        /// </summary>
        /// <returns>Mapper configuration</returns>
        public static MapperConfiguration Build()
        {
            MapperConfiguration configuration = new(configuration => configuration.AddProfile<PropertiesProfile>());
            configuration.AssertConfigurationIsValid<PropertiesProfile>();

            return configuration;
        }
    }
}
