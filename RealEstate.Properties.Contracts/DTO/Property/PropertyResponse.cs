using System;
using System.Collections.Generic;
using System.Linq;
using RealEstate.Properties.Contracts.DTO.PropertyTrace;

namespace RealEstate.Properties.Contracts.DTO.Property
{
    /// <summary>
    /// Represents the property response
    /// </summary>
    public class PropertyResponse
    {
        /// <summary>
        /// Property identifier
        /// </summary>
        public Guid PropertyId { get; set; }

        /// <summary>
        /// Property image identifier
        /// </summary>
        public Guid? PropertyImageId { get; set; }

        /// <summary>
        /// Property owner identifier
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Property name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Property price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Property code internal
        /// </summary>
        public int CodeInternal { get; set; }

        /// <summary>
        /// Property year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Property traces
        /// </summary>
        public IEnumerable<PropertyTraceResponse> PropertyTraces { get; set; } = Enumerable.Empty<PropertyTraceResponse>();
    }
}
