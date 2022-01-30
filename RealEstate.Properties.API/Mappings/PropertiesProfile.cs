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
            CreateMap<OwnerRequest, OwnerEntity>()
                .ForMember(member => member.OwnerId, options => options.Ignore());
            CreateMap<OwnerEntity, OwnerResponse>();
            CreateMap<PropertyRequest, PropertyEntity>()
                .ForMember(member => member.PropertyId, options => options.Ignore())
                .ForMember(member => member.Owner, options => options.Ignore());
            CreateMap<PropertyEntity, PropertyResponse>()
                .ForMember(member => member.PropertyImageId, options => options.Ignore())
                .ForMember(member => member.PropertyTraces, options => options.Ignore());
            CreateMap<PropertyImageRequest, PropertyImageEntity>()
                .ForMember(member => member.PropertyImageId, options => options.Ignore())
                .ForMember(member => member.Property, options => options.Ignore());
            CreateMap<PropertyImageEntity, PropertyImageResponse>();
            CreateMap<PropertyTraceRequest, PropertyTraceEntity>()
                .ForMember(member => member.PropertyTraceId, options => options.Ignore())
                .ForMember(member => member.Property, options => options.Ignore());
            CreateMap<PropertyTraceEntity, PropertyTraceResponse>();
            CreateMap<IAsyncEnumerable<(
                OwnerEntity,
                PropertyEntity,
                PropertyImageEntity,
                PropertyTraceEntity)>, IAsyncEnumerable<PropertiesFilter>>()
                .ConvertUsing<PropertiesFilterConverter>();
        }
    }
}
