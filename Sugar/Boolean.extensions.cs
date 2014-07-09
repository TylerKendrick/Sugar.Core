using System.Collections.Generic;
using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Provides fluent extensions to boolean types.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Equivalent to <paramref name="self"/> && <paramref name="other"/>
        /// </summary>
        public static bool And(this bool self, bool other)
        {
            return self && other;
        }

        /// <summary>
        /// Returns true if all values are true.
        /// </summary>
        public static bool And(this bool self, params bool[] others)
        {
            return self && others.All();
        }

        /// <summary>
        /// Returns true if all values are true.
        /// </summary>
        public static bool All(this IEnumerable<bool> self)
        {
            return self.All(x => x);
        }

        /// <summary>
        /// Equivalent to <paramref name="self"/> || <paramref name="other"/>.
        /// </summary>
        public static bool Or(this bool self, bool other)
        {
            return self || other;
        }

        /// <summary>
        /// Returns true if any values are true.
        /// </summary>
        public static bool Or(this bool self, params bool[] others)
        {
            return self || others.Any();
        }

        /// <summary>
        /// Provides a fluent, explicit value comparison for true.
        /// </summary>
        public static bool IsTrue(this bool self)
        {
            return self;
        }

        /// <summary>
        /// Provides a fluent, explicit value comparison for false.
        /// </summary>
        public static bool IsFalse(this bool self)
        {
            return self == false;
        }
    }
}