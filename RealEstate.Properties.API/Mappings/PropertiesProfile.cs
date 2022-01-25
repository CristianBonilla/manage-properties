using System.Collections.Generic;
using AutoMapper;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Contracts.DTO.Owner;
using RealEstate.Properties.Contracts.DTO.Property;
using RealEstate.Properties.Contracts.DTO.PropertyImage;
using RealEstate.Properties.Contracts.DTO.PropertyTrace;
using RealEstate.Properties.API.Mappings.Converters;

namespace RealEstate.Properties.API.Mappings
{
    /// <summary>
    /// Property profile to create maps, based on entities
    /// </summary>
    public class PropertiesProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesProfile"/> class
        /// </summary>
        public PropertiesProfile()
        {
            CreateMap<OwnerEntity, OwnerRequest>();
            CreateMap<OwnerEntity, OwnerResponse>();
            CreateMap<PropertyEntity, PropertyRequest>();
            CreateMap<PropertyEntity, PropertyResponse>();
            CreateMap<PropertyImageEntity, PropertyImageRequest>();
            CreateMap<PropertyTraceEntity, PropertyTraceRequest>();
            CreateMap<IAsyncEnumerable<(
                OwnerEntity,
                PropertyEntity,
                PropertyImageEntity,
                PropertyTraceEntity)>, IAsyncEnumerable<PropertiesFilter>>()
                .ConvertUsing<PropertiesFilterConverter>();
        }
    }
}
