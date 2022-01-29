using System;

namespace RealEstate.Properties.Domain.Extensions
{
    /// <summary>
    /// Evaluate types through API Reflection
    /// </summary>
    static class EvaluateTypesHelper
    {
        const string ASSEMBLY_NAME = "RealEstate.Properties";

        /// <summary>
        /// Check if the type is a user defined object (class or structure) based on the project assembly
        /// </summary>
        /// <param name="property">Current object property</param>
        /// <returns>True/False</returns>
        public static bool IsUserDefinedObject(this Type propertyType)
        {
            string propertyAssemblyName = propertyType.Assembly.FullName;
            bool isClass = propertyType.IsClass;
            bool isStruct = propertyType.IsValueType && !propertyType.IsPrimitive && !propertyType.IsEnum;

            return (isClass || isStruct) && propertyAssemblyName.StartsWith(ASSEMBLY_NAME);
        }
    }
}
