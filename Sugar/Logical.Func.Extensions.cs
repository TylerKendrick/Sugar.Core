namespace System
{
    public static partial class Logical
    {
        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical AND operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> And<T>(this Func<T, bool> self, Func<T, bool> other)
            => x => self(x) && other(x);

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical OR operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> Or<T>(this Func<T, bool> self, Func<T, bool> other)
            => x => self(x) || other(x);

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical Not operation on <paramref name="self"/>.
        /// </summary>
        public static Func<T, bool> Not<T>(this Func<T, bool> self)
            => x => !self(x);

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical AND operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> And<T>(this Func<T, bool> self, Predicate<T> other)
            => x => self(x) && other(x);

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical OR operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> Or<T>(this Func<T, bool> self, Predicate<T> other)
            => x => self(x) || other(x);


        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical AND operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> And<T>(this Func<T, bool> self, bool other)
            => x => self(x) && other;

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical OR operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> Or<T>(this Func<T, bool> self, bool other)
            => x => self(x) || other;
    }
}