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
            => predicate.And(self);

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical AND operation of <paramref name="self"/> 
        /// and <paramref name="predicate"/>.
        /// </summary>
        public static Func<T, bool> And<T>(this bool self, Predicate<T> predicate)
            => predicate.And(self);

        /// <summary>
        /// Equivalent to <paramref name="self"/> AND <paramref name="other"/>
        /// </summary>
        public static bool And(this bool self, bool other)
            => Operators.Boolean.And(self, other);

        /// <summary>
        /// Returns true if all values are true.
        /// </summary>
        public static bool And(this bool self, params bool[] others)
            => self.And(others.All());

        /// <summary>
        /// Returns true if all values are true.
        /// </summary>
        public static bool And(this bool self, Func<bool, bool, bool> aggregator, params bool[] others)
            => others.All(x => aggregator(self, x));

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical OR operation of <paramref name="self"/> 
        /// and <paramref name="predicate"/>.
        /// </summary>
        public static Func<T, bool> Or<T>(this bool self, Func<T, bool> predicate)
            => predicate.Or(self);

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical OR operation of <paramref name="self"/> 
        /// and <paramref name="predicate"/>.
        /// </summary>
        public static Func<T, bool> Or<T>(this bool self, Predicate<T> predicate)
            => predicate.Or(self);

        /// <summary>
        /// Equivalent to <paramref name="self"/> || <paramref name="other"/>.
        /// </summary>
        public static bool Or(this bool self, bool other)
            => Operators.Boolean.Or(self, other);

        /// <summary>
        /// Returns true if any values are true.
        /// </summary>
        public static bool Or(this bool self, params bool[] others)
            => self.Or(others.Length != 0);

        /// <summary>
        /// Returns true if any values are true.
        /// </summary>
        public static bool Or(this bool self, Func<bool, bool, bool> aggregator, params bool[] others)
            => others.Any(x => aggregator(self, x));

        /// <summary>
        /// Returns true if the specified instance is false.
        /// </summary>
        public static bool Not(this bool self) => Operators.Boolean.Not(self);
    }
}