using System;

namespace RealEstate.Properties.Contracts.DTO.PropertyImage
{
    /// <summary>
    /// Represents the property image response
    /// </summary>
    public class PropertyImageResponse
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
        /// Property image file name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Property image if enabled
        /// </summary>
        public bool Enabled { get; set; }
    }
}
