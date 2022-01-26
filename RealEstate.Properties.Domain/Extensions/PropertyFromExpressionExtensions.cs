using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;

namespace RealEstate.Properties.Domain.Extensions
{
    /// <summary>
    /// Extensions for getting properties from LinQ expressions
    /// </summary>
    static class PropertyFromExpressionExtensions
    {
        /// <summary>
        /// Gets the property referenced by the expression
        /// </summary>
        /// <param name="expression">Lambda expression reference</param>
        /// <returns>Property taken from expression (if not found, returns null)</returns>
        public static PropertyInfo GetProperty(this LambdaExpression expression)
        {
            PropertyInfo property = null;
            if (expression.Body is MemberExpression body)
                property = (PropertyInfo)body.Member;
            else if (expression.Body is UnaryExpression unary && unary.Operand is MemberExpression operand)
                property = (PropertyInfo)operand.Member;

            return property;
        }

        /// <summary>
        /// Check correctly if the property is listed
        /// </summary>
        /// <param name="expressions">Lambda expression list</param>
        /// <returns>True if the property is included</returns>
        public static bool IsPropertyIncluded(this IEnumerable<LambdaExpression> expressions, PropertyInfo property)
        {
            return expressions.Any(expression => property.Equals(expression.GetProperty()));
        }
    }
}
