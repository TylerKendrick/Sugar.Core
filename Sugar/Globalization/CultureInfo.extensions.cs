using System;
using System.Globalization;

namespace Sugar.Globalization
{
    /// <summary>
    /// Used to simplify the use of <see cref="CultureInfo"/> for use with string formatting.
    /// </summary>
    public static class CultureInfoExtensions
    {
        /// <summary>
        /// Uses format strings to simplify invocation of <see cref="IFormatProvider"/> with format strings.
        /// </summary>
        /// <param name="self">The target format provider.</param>
        /// <param name="formatString">The applied format string.</param>
        /// <param name="parameters">The parameters to apply to the format string.</param>    
        /// <returns>
        /// A copy of <paramref name="formatString"/> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="parameters"/>.
        /// </returns>
        public static string Format(this IFormatProvider self, string formatString, params object[] parameters)
        {
            return string.Format(self, formatString, parameters);
        }
    }
}