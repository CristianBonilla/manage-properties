using System;

namespace RealEstate.Properties.Domain.Entities
{
    /// <summary>
    /// Represents the property trace
    /// </summary>
    public class PropertyTraceEntity
    {
        /// <summary>
        /// Property trace identifier
        /// </summary>
        public Guid PropertyTraceId { get; set; }

        /// <summary>
        /// Property identifier
        /// </summary>
        public Guid PropertyId { get; set; }

        /// <summary>
        /// Property trace date sale
        /// </summary>
        public DateTime DateSale { get; set; }

        /// <summary>
        /// Property trace name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property trace value
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Property trace tax
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Property
        /// </summary>
        public PropertyEntity Property { get; set; }
    }
}
