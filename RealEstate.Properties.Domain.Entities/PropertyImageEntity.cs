using System;

namespace RealEstate.Properties.Domain.Entities
{
    /// <summary>
    /// Represents the property image
    /// </summary>
    public class PropertyImageEntity
    {
        /// <summary>
        /// Property image identifier
        /// </summary>
        public Guid PropertyImageId { get; set; }

        /// <summary>
        /// Property identifier
        /// </summary>
        public Guid PropertyId { get; set; }

        /// <summary>
        /// Property image file
        /// </summary>
        public byte[] File { get; set; }

        /// <summary>
        /// Property image if enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public PropertyEntity Property { get; set; }
    }
}
