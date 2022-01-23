using System;
using System.Linq;
using System.Collections.Generic;
using RealEstate.Properties.Domain.Entities;

namespace RealEstate.Properties.Domain.SeedWork.Collections
{
    /// <summary>
    /// Represents the collection of seed owners
    /// </summary>
    class OwnerCollection
    {
        /// <summary>
        /// Owner list
        /// </summary>
        public IEnumerable<OwnerEntity> List => new OwnerEntity[]
        {
            new()
            {
                OwnerId = new Guid("5691EAB3-50CE-4280-8659-CE208326FD97"),
                Name = "Cristian Bonilla",
                Address = "Cl. 20A Sur # 10-31",
                Birthday = new DateTime(1995, 8, 11)
            },
            new()
            {
                OwnerId = new Guid("DCBE29F5-AA35-40C3-ADC8-5E3B718A6000"),
                Name = "Natalia Guzman",
                Address = "Cl. 138 # 20-57",
                Birthday = new DateTime(1987, 5, 23)
            }
        };

        /// <summary>
        /// Gets the owner identifier based on the received index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Owner identifier</returns>
        public Guid this[int index] => List.ElementAt(index).OwnerId;
    }
}
