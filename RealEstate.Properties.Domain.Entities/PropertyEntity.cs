using System;

namespace RealEstate.Properties.Domain.Entities
{
    /// <summary>
    /// Represents the property
    /// </summary>
    public class PropertyEntity
    {
        /// <summary>
        /// Property identifier
        /// </summary>
        public Guid PropertyId { get; set; }

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
        /// Property owner
        /// </summary>
        public OwnerEntity Owner { get; set; }
    }
}
