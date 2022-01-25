using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using RealEstate.Properties.Domain.Context;
using RealEstate.Properties.Domain.Helpers;
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
        public async IAsyncEnumerable<(
            OwnerEntity,
            PropertyEntity,
            PropertyImageEntity,
            PropertyTraceEntity)>
            GetProperties()
        {
            var owners = _ownerRepository.Get().ToAsyncEnumerable();
            await foreach (OwnerEntity owner in owners)
            {
                var properties = _propertyRepository.Get(property => property.OwnerId == owner.OwnerId).ToAsyncEnumerable();
                await foreach(PropertyEntity property in properties)
                {
                    PropertyImageEntity propertyImage = _propertyImageRepository.Find(propertyImage => propertyImage.PropertyId == property.PropertyId);
                    PropertyTraceEntity propertyTrace = _propertyTraceRepository.Find(propertyTrace => propertyTrace.PropertyId == property.PropertyId);

                    yield return (owner, property, propertyImage, propertyTrace);
                }
            }
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<(
            OwnerEntity,
            PropertyEntity,
            PropertyImageEntity,
            PropertyTraceEntity)>
            GetProperties(string text)
        {
            var properties = GetProperties();
            await foreach (var (owner, property, propertyImage, propertyTrace) in properties)
            {
                bool ownerMatch = MatchesHelper.HasMatches(owner, text, owner => owner.Name);
                bool propertyMatch = MatchesHelper.HasMatches(
                    property,
                    text,
                    property => property.Name,
                    property => property.CodeInternal,
                    property => property.Price,
                    property => property.Year);
                bool propertyTraceMatch = MatchesHelper.HasMatches(
                    propertyTrace,
                    text,
                    propertyTrace => propertyTrace.Name,
                    propertyTrace => propertyTrace.Value,
                    propertyTrace => propertyTrace.Tax);
                if (ownerMatch || propertyMatch || propertyTraceMatch)
                    yield return (owner, property, propertyImage, propertyTrace);
            }
        }
    }
}
