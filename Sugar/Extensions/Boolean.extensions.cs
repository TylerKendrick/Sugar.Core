namespace System
{
    using Collections.Generic;
    using Linq;

    /// <summary>
    /// Provides fluent extensions to boolean types.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Returns true if all values are true.
        /// </summary>
        public static bool All(this IEnumerable<bool> self) => self.All(Lambda.Identity);

        /// <summary>
        /// Returns true if no values are true.
        /// </summary>
        public static bool None(this IEnumerable<bool> self) => self.All(x => !x);
    }
}