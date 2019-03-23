namespace System
{
    using Collections.Generic;
    using Linq;

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
            => self.Aggregate((first, second) => first.IsNullOrWhitespace()
                ? second.IsNullOrWhitespace()
                    ? string.Empty
                    : second
                : second.IsNullOrWhitespace()
                    ? first
                    : string.Format("{0}{2}{1}", first, second, delimiter));

        /// <summary>
        /// Provides the <code>string.Format</code> static method as an instance extension method.
        /// </summary>
        public static string Format(this string self, params object[] args) => string.Format(self, args);

        /// <summary>
        /// Wraps Convert.FromBase64String as an instance extension method.
        /// </summary>
        public static byte[] FromBase64String(this string self) => Convert.FromBase64String(self);

        /// <summary>
        /// Returns true is the instance is not null.
        /// </summary>
        public static bool IsNotNull(this string self) => self != null;

        /// <summary>
        /// Returns true is the instance is null.
        /// </summary>
        public static bool IsNull(this string self) => self == null;

        /// <summary>
        /// Indicates whether the specified string is null or an <see cref="F:System.String.Empty"/> string or whitespace.
        /// </summary>
        public static bool IsNullOrWhitespace(this string self) => string.IsNullOrEmpty(self.Trim());

        /// <summary>
        /// Indicates whether the specified string is null or an <see cref="F:System.String.Empty"/> string.
        /// </summary>
        public static bool IsNullOrEmpty(this string self) => string.IsNullOrEmpty(self);
    }
}