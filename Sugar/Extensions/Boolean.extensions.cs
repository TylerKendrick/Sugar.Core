using System;
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
            return Logical.And(self, other);
        }

        /// <summary>
        /// Returns true if all values are true.
        /// </summary>
        public static bool And(this bool self, params bool[] others)
        {
            return Logical.And(self, others);
        }

        public static bool And(this bool self, Func<bool, bool, bool> aggregator, params bool[] others)
        {
            return Logical.And(self, aggregator, others);
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
            return Logical.Or(self, other);
        }

        /// <summary>
        /// Returns true if any values are true.
        /// </summary>
        public static bool Or(this bool self, params bool[] others)
        {
            return Logical.Or(self, others);
        }

        public static bool Or(this bool self, Func<bool, bool, bool> aggregator, params bool[] others)
        {
            return Logical.Or(self, aggregator, others);
        } 
    }
}