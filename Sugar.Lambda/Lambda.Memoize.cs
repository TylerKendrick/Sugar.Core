using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static partial class Lambda<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Provides the memoize monad as a delegate.
        /// </summary>
        public static readonly Func<Func<T1, T2, T3, T4, T5>, Func<T1, T2, T3, T4, T5>> Memoize = func =>
        {
            var curried = func.Curry();
            var substitution = Lambda.Memoizer(curried.Memoize());

            return substitution.Uncurry();
        };
    }

    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static partial class Lambda<T1, T2, T3, T4>
    {
        /// <summary>
        /// Provides the memoize monad as a delegate.
        /// </summary>
        public static readonly Func<Func<T1, T2, T3, T4>, Func<T1, T2, T3, T4>> Memoize = func =>
        {
            var curried = func.Curry();
            var substitution = Lambda.Memoizer(curried.Memoize());

            return substitution.Uncurry();
        };
    }

    public static partial class Lambda<T1, T2, TResult>
    {
        /// <summary>
        /// Provides the memoize monad as a delegate.
        /// </summary>
        public static readonly Func<Func<T1, T2, TResult>, Func<T1, T2, TResult>> Memoize = func =>
        {
            var curried = func.Curry();
            var substitution = Lambda.Memoizer(curried.Memoize());

            return substitution.Uncurry();
        };
    }

    public static partial class Lambda<T1, TResult>
    {
        /// <summary>
        /// Provides the memoize monad as a delegate.
        /// </summary>
        public static readonly Func<Func<T1, TResult>, Func<T1, TResult>> Memoize = Lambda.Memoizer;
    }

    public static partial class Lambda<T>
    {
        /// <summary>
        /// Provides the memoize monad as a delegate.
        /// </summary>
        public static readonly Func<Func<T, T>, Func<T, T>> Memoize = Lambda<T, T>.Memoize;
    }

    public static partial class Lambda
    {
        internal static Func<T1, T2> Memoizer<T1, T2>(Func<T1, T2> applicator)
        {
            var cache = new Dictionary<T1, T2>();
            var getOrAdd = new Func<T1, Func<T2>, T2>((key, generator)
                => cache.TryGetValue(key, out var value) ? value : generator());
            var curried = getOrAdd.Curry();

            return x => Substitution(curried, applicator.ApplyFirst, x);
        }

        /// <summary>
        /// Invokes the Lambda{T1, T2}.Memoize delegate.
        /// </summary>
        public static Func<T1, T2> Memoize<T1, T2>(this Func<T1, T2> func)
            => Lambda<T1, T2>.Memoize(func);

        /// <summary>
        /// Invokes the Lambda{T1, T2, T3}.Memoize delegate.
        /// </summary>
        public static Func<T1, T2, T3> Memoize<T1, T2, T3>(this Func<T1, T2, T3> func)
            => Lambda<T1, T2, T3>.Memoize(func);

        /// <summary>
        /// Invokes the Lambda{T1, T2, T3, T4}.Memoize delegate.
        /// </summary>
        public static Func<T1, T2, T3, T4> Memoize<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> func)
            => Lambda<T1, T2, T3, T4>.Memoize(func);

        /// <summary>
        /// Invokes the Lambda{T1, T2, T3, T4, T5}.Memoize delegate.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5> Memoize<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func)
            => Lambda<T1, T2, T3, T4, T5>.Memoize(func);
    }
}