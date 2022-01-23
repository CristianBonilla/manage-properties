using System;
using System.Linq;
using System.Collections.Generic;
using RealEstate.Properties.Domain.Entities;

namespace RealEstate.Properties.Domain.SeedWork.Collections
{
    /// <summary>
    /// Represents the collection of seed properties
    /// </summary>
    class PropertyCollection
    {
        static OwnerCollection _owner;

        /// <summary>
        /// Property list
        /// </summary>
        public IEnumerable<PropertyEntity> List => new PropertyEntity[]
        {
            new()
            {
                PropertyId = new Guid("488148AE-7BBC-4186-8E36-C3BD1C0BFE34"),
                OwnerId = _owner[0],
                Name = "Headland Waters Mount Martha",
                Address = "6677 Schroeder Avenue",
                Price = 1358000000,
                CodeInternal = 34432111,
                Year = 2018,
            },
            new()
            {
                PropertyId = new Guid("12BA0DF8-CF55-4CCB-A109-C582906E6B12"),
                OwnerId = _owner[0],
                Name = "Luyary Jeddo",
                Address = "Moussaouidreef 8",
                Price = 1297566000,
                CodeInternal = 98801123,
                Year = 2021
            },
            new()
            {
                PropertyId = new Guid("39CD6B37-9F59-4E34-BBFF-34D3963BA558"),
                OwnerId = _owner[0],
                Name = "Runneymede",
                Address = "8098 Yundt Mission",
                Price = 1188954000,
                CodeInternal = 11983367,
                Year = 2020
            },
            new()
            {
                PropertyId = new Guid("0CA10F96-364A-4D8E-B870-BADDB7A9ACBF"),
                OwnerId = _owner[1],
                Name = "Zuburnano Up",
                Address = "701, avenue de Guilbert",
                Price = 1877544000,
                CodeInternal = 87711809,
                Year = 2021
            },
            new()
            {
                PropertyId = new Guid("CB9EC42F-3C07-4CA1-8BA8-59E09C504860"),
                OwnerId = _owner[1],
                Name = "The Kingfisher",
                Address = "193 Kshlerin Spring",
                Price = 1988411000,
                CodeInternal = 43309922,
                Year = 2020
            }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyCollection"/> class
        /// </summary>
        /// <param name="owner">Owner collection</param>
        public PropertyCollection(OwnerCollection owner) => _owner = owner;

        /// <summary>
        /// Gets the property identifier based on the received index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Property identifier</returns>
        public Guid this[int index] => List.ElementAt(index).PropertyId;
    }
}
