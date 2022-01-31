using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Properties.Domain.Entities;

namespace RealEstate.Properties.Contracts.Services
{
    /// <summary>
    /// Represents the property domain service interface
    /// </summary>
    public interface IPropertiesService
    {
        /// <summary>
        /// Adds the property directly to the database
        /// </summary>
        /// <param name="property">Property</param>
        /// <returns>Property added</returns>
        Task<PropertyEntity> AddProperty(PropertyEntity property);

        /// <summary>
        /// Update the property image directly to the database
        /// </summary>
        /// <param name="propertyId">Property identifier</param>
        /// <param name="image">Image byte array</param>
        /// <param name="imageName">Image name</param>
        Task UpdatePropertyImage(Guid propertyId, byte[] image, string imageName);

        /// <summary>
        /// Changes the property price directly in the database
        /// </summary>
        /// <param name="propertyId">Property identifier</param>
        /// <param name="price">Price to change</param>
        /// <returns>Property with the price changed</returns>
        Task<PropertyEntity> UpdatePropertyPrice(Guid propertyId, decimal price);

        /// <summary>
        /// Find property image by property identifier
        /// </summary>
        /// <param name="propertyId">Property identifier</param>
        /// <returns>Property image found</returns>
        PropertyImageEntity FindPropertyImage(Guid propertyId);

        /// <summary>
        /// Get all matching properties
        /// </summary>
        /// <returns>Tuple of property entities whose match was true</returns>
        IAsyncEnumerable<(
            OwnerEntity,
            PropertyEntity,
            PropertyImageEntity,
            PropertyTraceEntity)>
            GetProperties();

        /// <summary>
        /// Performs a property filter matching the received text
        /// </summary>
        /// <param name="text">Text to match</param>
        /// <returns>Tuple of property entities whose match was true</returns>
        IAsyncEnumerable<(
            OwnerEntity,
            PropertyEntity,
            PropertyImageEntity,
            PropertyTraceEntity)>
            GetProperties(string text);

        /// <summary>
        /// Get property traces by property identifier
        /// </summary>
        /// <param name="propertyId">Property identifier</param>
        /// <returns>Property traces</returns>
        IAsyncEnumerable<PropertyTraceEntity> GetTracesByProperty(Guid propertyId);
    }
}
