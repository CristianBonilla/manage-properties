using System;
using System.Reflection;
using System.Linq.Expressions;
using RealEstate.Properties.Domain.Extensions;

namespace RealEstate.Properties.Domain.Helpers
{
    /// <summary>
    /// Helper to filter matches of a objects collection, based on their property values
    /// </summary>
    static class MatchesHelper
    {
        /// <summary>
        /// Checks for matches by looping through the object's properties, returning true
        /// </summary>
        /// <param name="obj">Current object</param>
        /// <param name="text">Match text</param>
        /// <param name="includedProperties">Properties to include in the search</param>
        /// <returns>Boolean value if matches are found</returns>
        public static bool HasMatches<TObject>(
            TObject obj,
            string text,
            params Expression<Func<TObject, object>>[] includedProperties) where TObject : notnull
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propertyValue = property.GetValue(obj, null);
                if (propertyValue == null)
                    continue;
                bool isIncluded = includedProperties.IsPropertyIncluded(property);
                Type propertyType = property.PropertyType;
                if (!isIncluded || propertyType != typeof(string) && !propertyType.IsValueType)
                    continue;
                string propertyValueText = propertyValue?.ToString() ?? string.Empty;
                bool hasMatches = propertyValueText.Contains(text, StringComparison.OrdinalIgnoreCase);
                if (hasMatches)
                    return true;
            }

            return false;
        }
    }
}
