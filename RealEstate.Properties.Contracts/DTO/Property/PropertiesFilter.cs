using System;
using System.Linq;
using System.Collections.Generic;

namespace RealEstate.Properties.Contracts.DTO.Property
{
    /// <summary>
    /// Renders the property list response with filter
    /// </summary>
    public class PropertiesFilter
    {
        /// <summary>
        /// Owner identifier
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Owner name
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Owned properties
        /// </summary>
        public IEnumerable<PropertyResponse> Properties { get; set; } = Enumerable.Empty<PropertyResponse>();
    }
}
