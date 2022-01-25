using System;

namespace RealEstate.Properties.Contracts.DTO.PropertyImage
{
    /// <summary>
    /// Represents the property image request
    /// </summary>
    public class  PropertyImageRequest
    {
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
    }
}
