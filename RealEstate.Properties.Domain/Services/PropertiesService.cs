using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using RealEstate.Properties.Domain.Context;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Domain.Repositories;
using RealEstate.Properties.Contracts.Services;
using RealEstate.Properties.Contracts.Exceptions;

namespace RealEstate.Properties.Domain.Services
{
    /// <inheritdoc cref="IPropertiesService"/>
    public class PropertiesService : IPropertiesService
    {
        readonly IPropertiesContext _context;
        readonly IOwnerRepository _ownerRepository;
        readonly IPropertyRepository _propertyRepository;
        readonly IPropertyImageRepository _propertyImageRepository;
        readonly IPropertyTraceRepository _propertyTraceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesService"/> class
        /// </summary>
        /// <param name="ownerRepository">Owner repository</param>
        /// <param name="context">Repository context</param>
        /// <param name="propertyRepository">Property repository</param>
        /// <param name="propertyImageRepository">Property image repository</param>
        /// <param name="propertyTraceRepository">Property trace repository</param>
        public PropertiesService(
            IPropertiesContext context,
            IOwnerRepository ownerRepository,
            IPropertyRepository propertyRepository,
            IPropertyImageRepository propertyImageRepository,
            IPropertyTraceRepository propertyTraceRepository)
        {
            _context = context;
            _ownerRepository = ownerRepository;
            _propertyRepository = propertyRepository;
            _propertyImageRepository = propertyImageRepository;
            _propertyTraceRepository = propertyTraceRepository;
        }

        /// <inheritdoc/>
        public async Task<PropertyEntity> AddProperty(PropertyEntity property)
        {
            PropertyEntity propertyAdded = _propertyRepository.Create(property);
            await _context.SaveAsync();

            return propertyAdded;
        }

        /// <inheritdoc/>
        public async Task<PropertyImageEntity> AddPropertyImage(Guid propertyId, byte[] image)
        {
            PropertyImageEntity propertyImage = _propertyImageRepository.Find(propertyImage => propertyImage.PropertyId == propertyId);
            if (propertyImage == null)
                throw new ServiceErrorException(HttpStatusCode.NotFound, "Property image not found with related property identifier");
            propertyImage.File = image;
            await _context.SaveAsync();

            return propertyImage;
        }

        /// <inheritdoc/>
        public async Task<PropertyEntity> EditPropertyPrice(Guid propertyId, decimal price)
        {
            PropertyEntity property = _propertyRepository.Find(property => property.PropertyId == propertyId);
            if (property == null)
                throw new ServiceErrorException(HttpStatusCode.NotFound, "Property not found with related property identifier");
            property.Price = price;
            await _context.SaveAsync();

            return property;
        }

        /// <inheritdoc/>
        public IAsyncEnumerable<(OwnerEntity, PropertyEntity, PropertyImageEntity, PropertyTraceEntity)> GetProperties()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IAsyncEnumerable<(OwnerEntity, PropertyEntity, PropertyImageEntity, PropertyTraceEntity)> GetProperties(string text)
        {
            throw new NotImplementedException();
        }
    }
}
