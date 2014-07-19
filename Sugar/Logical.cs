using System.Linq;

namespace System
{
    public static class Logical
    {
        /// <summary>
        /// Equivalent to <paramref name="self"/> && <paramref name="other"/>
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

        public static bool Or(this bool self, Func<bool, bool, bool> aggregator, params bool[] others)
        {
            return others.Any(x => aggregator(self, x));
        }

        public static bool Not(this bool self)
        {
            return Operators.Boolean.Not(self);
        }
    }
}