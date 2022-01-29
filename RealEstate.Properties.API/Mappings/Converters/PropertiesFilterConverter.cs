using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Contracts.DTO.Owner;
using RealEstate.Properties.Contracts.DTO.Property;
using RealEstate.Properties.Contracts.DTO.PropertyTrace;
using RealEstate.Properties.Contracts.DTO.PropertyImage;

namespace RealEstate.Properties.API.Mappings.Converters
{
    /// <summary>
    /// Mapping converter between tuple and properties filter response class
    /// </summary>
    public class PropertiesFilterConverter : ITypeConverter<IAsyncEnumerable<(
                OwnerEntity owner,
                PropertyEntity property,
                PropertyImageEntity propertyImage,
                PropertyTraceEntity propertyTrace)>, IAsyncEnumerable<PropertiesFilter>>
    {
        /// <summary>
        /// Convert the tuple to the properties filter class, iterating asynchronously
        /// </summary>
        /// <param name="source">Properties class tuple</param>
        /// <param name="destination">Properties filter</param>
        /// <param name="context">Resolution context</param>
        /// <returns>Properties filter converted</returns>
        public async IAsyncEnumerable<PropertiesFilter> Convert(IAsyncEnumerable<(
            OwnerEntity owner,
            PropertyEntity property,
            PropertyImageEntity propertyImage,
            PropertyTraceEntity propertyTrace)> source,
            IAsyncEnumerable<PropertiesFilter> destination,
            ResolutionContext context)
        {
            IRuntimeMapper mapper = context.Mapper;
            var sources = await source.ToArrayAsync();
            var owners = sources.Select(property => mapper.Map<OwnerResponse>(property.owner)).Distinct();
            var properties = sources.Select(property => mapper.Map<PropertyResponse>(property.property));
            var propertyImages = sources.Select(property => mapper.Map<PropertyImageResponse>(property.propertyImage));
            var propertyTraces = sources.Select(property => mapper.Map<PropertyTraceResponse>(property.propertyTrace));
            foreach (OwnerResponse owner in owners)
            {
                var propertiesExtended = properties.Where(property => property.OwnerId == owner.OwnerId)
                    .Select(property =>
                    {
                        property.PropertyImageId = propertyImages
                            .SingleOrDefault(propertyImage => propertyImage?.PropertyId == property.PropertyId)?.PropertyImageId;
                        property.PropertyTraces = propertyTraces
                            .Where(propertyTrace => propertyTrace.PropertyId == property.PropertyId);

                        return property;
                    });

                yield return new()
                {
                    OwnerId = owner.OwnerId,
                    OwnerName = owner.Name,
                    Properties = propertiesExtended
                };
            }
        }
    }
}
