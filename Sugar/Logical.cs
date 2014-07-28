using System.Linq;

namespace System
{
    /// <summary>
    /// Provides extension methods for boolean operations.
    /// </summary>
    public static class Logical
    {
        /// <summary>
        /// Equivalent to <paramref name="self"/> AND <paramref name="other"/>
        /// </summary>
        public static bool And(this bool self, bool other)
        {
            return Operators.Boolean.And(self, other);
        }

        /// <summary>
        /// Returns true if all values are true.
        /// </summary>
        public static bool And(this bool self, params bool[] others)
        {
            return self.And(others.All());
        }

        /// <summary>
        /// Returns true if all values are true.
        /// </summary>
        public static bool And(this bool self, Func<bool, bool, bool> aggregator, params bool[] others)
        {
            return others.All(x => aggregator(self, x));
        }

        /// <summary>
        /// Equivalent to <paramref name="self"/> || <paramref name="other"/>.
        /// </summary>
        public static bool Or(this bool self, bool other)
        {
            return Operators.Boolean.Or(self, other);
        }

        /// <summary>
        /// Returns true if any values are true.
        /// </summary>
        public static bool Or(this bool self, params bool[] others)
        {
            return self.Or(others.Any());
        }

        /// <summary>
        /// Returns true if any values are true.
        /// </summary>
        public static bool Or(this bool self, Func<bool, bool, bool> aggregator, params bool[] others)
        {
            return others.Any(x => aggregator(self, x));
        }

        /// <summary>
        /// Returns true if the specified instance is false.
        /// </summary>
        public static bool Not(this bool self)
        {
            return Operators.Boolean.Not(self);
        }
    }
}