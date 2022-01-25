using System;

namespace RealEstate.Properties.Contracts.DTO.Property
{
    /// <summary>
    /// Represents the property request
    /// </summary>
    public class PropertyRequest
    {
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
    }
}
