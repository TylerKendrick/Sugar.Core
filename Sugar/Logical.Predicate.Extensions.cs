namespace System
{
    public static partial class Logical
    {

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical Not operation on <paramref name="self"/>.
        /// </summary>
        public static Func<T, bool> Not<T>(this Predicate<T> self)
        {
            return x => !self(x);
        }

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical AND operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> And<T>(this Predicate<T> self, Func<T, bool> other)
        {
            return x => self(x) && other(x);
        }

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical OR operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> Or<T>(this Predicate<T> self, Func<T, bool> other)
        {
            return x => self(x) || other(x);
        }


        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical AND operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> And<T>(this Predicate<T> self, Predicate<T> other)
        {
            return x => self(x) && other(x);
        }

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical OR operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> Or<T>(this Predicate<T> self, Predicate<T> other)
        {
            return x => self(x) || other(x);
        }


        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical AND operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> And<T>(this Predicate<T> self, bool other)
        {
            return x => self(x) && other;
        }

        /// <summary>
        /// Returns a <see cref="Func{TIn, TOut}"/> that computes 
        /// the logical OR operation on <paramref name="self"/> 
        /// and <paramref name="other"/>.
        /// </summary>
        public static Func<T, bool> Or<T>(this Predicate<T> self, bool other)
        {
            return x => self(x) || other;
        }
    }
}