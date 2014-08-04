using System.Linq;

namespace System
{
    /// <summary>
    /// Provides extension methods for boolean operations.
    /// </summary>
    public static partial class Logical
    {
        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical AND operation of <paramref name="self"/> 
        /// and <paramref name="predicate"/>.
        /// </summary>
        public static Func<T, bool> And<T>(this bool self, Func<T, bool> predicate)
        {
            return predicate.And(self);
        }

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical AND operation of <paramref name="self"/> 
        /// and <paramref name="predicate"/>.
        /// </summary>
        public static Func<T, bool> And<T>(this bool self, Predicate<T> predicate)
        {
            return predicate.And(self);
        }

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
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical OR operation of <paramref name="self"/> 
        /// and <paramref name="predicate"/>.
        /// </summary>
        public static Func<T, bool> Or<T>(this bool self, Func<T, bool> predicate)
        {
            return predicate.Or(self);
        }

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical OR operation of <paramref name="self"/> 
        /// and <paramref name="predicate"/>.
        /// </summary>
        public static Func<T, bool> Or<T>(this bool self, Predicate<T> predicate)
        {
            return predicate.Or(self);
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