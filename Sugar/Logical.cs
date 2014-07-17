using System.Linq;

namespace System
{
    public static class Logical
    {
        /// <summary>
        /// Equivalent to <paramref name="self"/> && <paramref name="other"/>
        /// </summary>
        public static bool And(bool self, bool other)
        {
            return self && other;
        }

        /// <summary>
        /// Returns true if all values are true.
        /// </summary>
        public static bool And(bool self, params bool[] others)
        {
            return self && others.All();
        }

        public static bool And(bool self, Func<bool, bool, bool> aggregator, params bool[] others)
        {
            return others.All(x => aggregator(self, x));
        }

        /// <summary>
        /// Equivalent to <paramref name="self"/> || <paramref name="other"/>.
        /// </summary>
        public static bool Or(bool self, bool other)
        {
            return self || other;
        }

        /// <summary>
        /// Returns true if any values are true.
        /// </summary>
        public static bool Or(bool self, params bool[] others)
        {
            return self || others.Any();
        }

        public static bool Or(bool self, Func<bool, bool, bool> aggregator, params bool[] others)
        {
            return others.Any(x => aggregator(self, x));
        }

        public static bool Not(bool self)
        {
            return !self;
        }
    }
}