using System;

namespace RealEstate.Properties.Contracts.DTO.Owner
{
    /// <summary>
    /// Represents owner response
    /// </summary>
    public class OwnerResponse
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
