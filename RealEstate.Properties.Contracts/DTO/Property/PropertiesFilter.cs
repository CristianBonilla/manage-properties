namespace RealEstate.Properties.Contracts.DTO.Property
{
    /// <summary>
    /// Renders the property list response with filter
    /// </summary>
    public class PropertiesFilter
    {
        /// <summary>
        /// Owner name
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Property name
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Property code internal
        /// </summary>
        public int PropertyCodeInternal { get; set; }

        /// <summary>
        /// Property price
        /// </summary>
        public decimal PropertyPrice { get; set; }

        /// <summary>
        /// Property year
        /// </summary>
        public int PropertyYear { get; set; }

        /// <summary>
        /// Property trace name
        /// </summary>
        public string PropertyTraceName { get; set; }

        /// <summary>
        /// Property trace value
        /// </summary>
        public decimal PropertyTraceValue { get; set; }

        /// <summary>
        /// Property trace tax
        /// </summary>
        public decimal PropertyTraceTax { get; set; }
    }
}
