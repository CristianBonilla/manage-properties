using System;

namespace RealEstate.Properties.Domain.Entities
{
    /// <summary>
    /// Represents the owner according to the property
    /// </summary>
    public class OwnerEntity
    {
        /// <summary>
        /// Owner identifier
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Owner name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Owner address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Owner photo
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Owner birthday
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
