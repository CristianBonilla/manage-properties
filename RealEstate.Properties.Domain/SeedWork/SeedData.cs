using System;
using System.Collections.Generic;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Domain.SeedWork.Collections;

namespace RealEstate.Properties.Domain.SeedWork
{
    /// <summary>
    /// Responsible for providing the seed data when creating the database
    /// </summary>
    class SeedData
    {
        static OwnerCollection Owners => new();
        static PropertyCollection Properties => new(Owners);

        /// <summary>
        /// Owner seed data
        /// </summary>
        public static IEnumerable<OwnerEntity> OwnersSeed => Owners.List;

        /// <summary>
        /// Property seed data
        /// </summary>
        public static IEnumerable<PropertyEntity> PropertiesSeed => Properties.List;

        /// <summary>
        /// Property traces seed data
        /// </summary>
        public static IEnumerable<PropertyTraceEntity> PropertyTracesSeed => new PropertyTraceEntity[]
        {
            new()
            {
                PropertyTraceId = new Guid("C4C42999-A4FC-40FB-B10B-6A14FC588FAB"),
                PropertyId = Properties[0],
                DateSale = new DateTime(2018, 2, 11),
                Name = "Headland Waters Mount Martha Trace",
                Value = 1058000000,
                Tax = 5430000
            },
            new()
            {
                PropertyTraceId = new Guid("529BBF7D-880A-4BB8-80FC-F605B3DF0344"),
                PropertyId = Properties[1],
                DateSale = new DateTime(2021, 5, 20),
                Name = "Luyary Jeddo Trace",
                Value = 1117566000,
                Tax = 6132000
            },
            new()
            {
                PropertyTraceId = new Guid("AE699884-D68A-486D-877D-55BD62046D66"),
                PropertyId = Properties[2],
                DateSale = new DateTime(2020, 12, 11),
                Name = "Runneymede Trace",
                Value = 1008954000,
                Tax = 5011000
            },
            new()
            {
                PropertyTraceId = new Guid("774C3477-C8D5-49C5-9281-ADDB60D175B0"),
                PropertyId = Properties[3],
                DateSale = new DateTime(2021, 7, 25),
                Name = "Zuburnano Up Trace",
                Value = 1417844000,
                Tax = 6234000
            },
            new()
            {
                PropertyTraceId = new Guid("C82D1AC6-215F-4C21-AA2F-2140FE532A6B"),
                PropertyId = Properties[4],
                DateSale = new DateTime(2021, 8, 22),
                Name = "The Kingfisher Trace",
                Value = 1122910000,
                Tax = 8950000
            }
        };
    }
}
