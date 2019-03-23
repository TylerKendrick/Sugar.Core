namespace System.Linq
{
    using Collections;
    using Collections.Generic;

    /// <summary>
    /// Provides common operations with enumerables not present in Linq for the non-generic IEnumerable.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Provides Enumerable.Cast as an extension method to the non-generic IEnumerable.
        /// </summary>
        /// <param name="self">The target for casting.</param>
        /// <returns>The target collection as an IEnumerable{object}</returns>
        public static IEnumerable<object> AsEnumerable(this IEnumerable self) => self.Cast<object>();
    }
}