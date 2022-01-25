using System.Collections.Generic;
using AutoMapper;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Contracts.DTO.Property;

namespace RealEstate.Properties.API.Mappings.Converters
{
    /// <summary>
    /// Mapping converter between tuple and properties filter response class
    /// </summary>
    public class PropertiesFilterConverter : ITypeConverter<IAsyncEnumerable<(
                OwnerEntity,
                PropertyEntity,
                PropertyImageEntity,
                PropertyTraceEntity)>, IAsyncEnumerable<PropertiesFilter>>
    {
        /// <summary>
        /// Convert the tuple to the properties filter class, iterating asynchronously
        /// </summary>
        /// <param name="source">Properties class tuple</param>
        /// <param name="destination">Properties filter</param>
        /// <param name="context">Resolution context</param>
        /// <returns>Properties filter converted</returns>
        public async IAsyncEnumerable<PropertiesFilter> Convert(IAsyncEnumerable<(
            OwnerEntity,
            PropertyEntity,
            PropertyImageEntity,
            PropertyTraceEntity)> source,
            IAsyncEnumerable<PropertiesFilter> destination,
            ResolutionContext context)
        {
            await foreach (var (owner, property, _, propertyTrace) in source)
                yield return new()
                {
                    OwnerName = owner.Name,
                    PropertyName = property.Name,
                    PropertyCodeInternal = property.CodeInternal,
                    PropertyPrice = property.Price,
                    PropertyYear = property.Year,
                    PropertyTraceName = propertyTrace.Name,
                    PropertyTraceValue = propertyTrace.Value,
                    PropertyTraceTax = propertyTrace.Tax
                };
        }
    }
}
