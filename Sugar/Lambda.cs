namespace System
{
    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static partial class Lambda<T1, T2, TResult>
    {
        /// <summary>
        /// Provides the S Combinator as a delegate.
        /// A function of the form: x => y => z => x(z)(y(z))
        /// </summary>
        public static readonly Func<Func<T2, Func<T1, TResult>>, Func<Func<T2, T1>, Func<T2, TResult>>> Substitution =
            x => y => z => x(z)(y(z));
    }

    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static partial class Lambda<T1, TResult>
    {
        /// <summary>
        /// Provides the K Combinator as a delegate.
        /// A function of the form: x => y => x
        /// </summary>
        public static readonly Func<T1, Func<TResult, T1>> Constant = x => _ => x;
    }

    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static partial class Lambda<T>
    {
        /// <summary>
        /// Provides the I Combinator as a delegate.
        /// A function of the form: x => x
        /// </summary>
        public static readonly Func<T, T> Identity = x => x;
    }

    public static partial class Lambda
    {
        /// <summary>
        /// Provides the I Combinator as a delegate.
        /// A function of the form: x => x
        /// </summary>
        public static T Identity<T>(T x) => Lambda<T>.Identity(x);

        /// <summary>
        /// Provides the K Combinator as a delegate.
        /// A function of the form: x => y => x
        /// </summary>
        public static T1 Constant<T1, T2>(T1 x, T2 y) => Lambda<T1, T2>.Constant(x)(y);

        /// <summary>
        /// Provides the S Combinator as a delegate.
        /// A function of the form: x => y => z => x(z)(y(z))
        /// </summary>
        public static TResult Substitution<T1, T2, TResult>(
            Func<T2, Func<T1, TResult>> first,
            Func<T2, T1> second,
            T2 arg) => Lambda<T1, T2, TResult>.Substitution(first)(second)(arg);

        /// <summary>
        /// A function of the form: x => y => z => x(y(z))
        /// </summary>
        public static Func<T2, TResult> Compose<T1, T2, TResult>(this Func<T1, TResult> func,
            Func<T2, T1> other) => x => func(other(x));
    }
}