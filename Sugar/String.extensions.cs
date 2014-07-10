using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Provides common operations with <see cref="System.String"/> objects as extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Takes a collection of strings and aggregates them using a specified delimiter.
        /// </summary>
        /// <param name="self">The target collection of string to delimit.</param>
        /// <param name="delimiter">The specified string delimiter.</param>
        /// <returns>Returns a string delimited aggregate of the provided string collection.</returns>
        public static string Delimit(this IEnumerable<string> self, string delimiter = ", ")
        {
            Func<string, bool> isNullOrEmptyOrWhitespace = x => Fluent.String(x)
                .Is.Null()
                .Or.Empty()
                .Or.Whitespace();

            return self.Aggregate((first, second) => isNullOrEmptyOrWhitespace(first)
                ? isNullOrEmptyOrWhitespace(second)
                    ? string.Empty
                    : second
                : isNullOrEmptyOrWhitespace(second)
                    ? first
                    : string.Format("{0}{2}{1}", first, second, delimiter));
        }

        /// <summary>
        /// Provides the <code>string.Format</code> static method as an instance extension method.
        /// </summary>
        public static string Format(this string self, params object[] args)
        {
            return string.Format(self, args);
        }
    }
}