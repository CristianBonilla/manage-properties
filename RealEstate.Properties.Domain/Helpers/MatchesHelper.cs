using System;
using System.Reflection;
using System.Linq.Expressions;
using RealEstate.Properties.Domain.Extensions;
using System.Linq;

namespace RealEstate.Properties.Domain.Helpers
{
    /// <summary>
    /// Helper to filter matches of a objects collection, based on their property values
    /// </summary>
    static class MatchesHelper
    {
        /// <summary>
        /// Using the reflection API, perform a match of the object
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="text">Text</param>
        /// <param name="includedProperties">Object properties to include in the search</param>
        /// <returns>True/False</returns>
        public static bool MatchesByText<TObject>(
            TObject obj,
            string text,
            params Expression<Func<TObject, object>>[] includedProperties) where TObject : class =>
            !string.IsNullOrWhiteSpace(text) && HasMatches(obj, text, includedProperties);

        /// <summary>
        /// Checks for matches by looping through the object's properties, returning true
        /// </summary>
        /// <param name="obj">Current object</param>
        /// <param name="text">Match text</param>
        /// <param name="includedProperties">Properties to include in the search</param>
        /// <returns>Boolean value if matches are found</returns>
        private static bool HasMatches<TObject>(
            TObject obj,
            string text,
            params LambdaExpression[] includedProperties) where TObject : notnull
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
                if (propertyType.IsUserDefinedObject())
                    return HasMatches(propertyValue, text, IncludedInternalProperties(propertyValue, includedProperties));
                if (!isIncluded || propertyType != typeof(string) && !propertyType.IsValueType)
                    continue;
                string propertyValueText = propertyValue?.ToString() ?? string.Empty;
                bool hasMatches = propertyValueText.Contains(text, StringComparison.OrdinalIgnoreCase);
                if (hasMatches)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Filter included internal properties of user-defined object (class or structure)
        /// </summary>
        /// <typeparam name="TObject">User defined object type</typeparam>
        /// <param name="objectValue">User defined object value</param>
        /// <param name="includedProperties">Included properties to check if has inner object properties</param>
        /// <returns>Returns the internal included properties</returns>
        private static LambdaExpression[] IncludedInternalProperties<TObject>(
            TObject objectValue,
            params LambdaExpression[] includedProperties) where TObject : notnull
        {
            PropertyInfo[] internalProperties = objectValue.GetType().GetProperties();
            var includedInternalProperties = includedProperties.Where(expression => internalProperties
                .Any(internalProperty => expression.GetProperty()?.Equals(internalProperty) ?? false))
                .ToArray();

            return includedInternalProperties;
        }
    }
}
