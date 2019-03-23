namespace System
{
    using Collections.Generic;

    /// <summary>
    /// Provides custom implementations of <see cref="IComparer{T}"/> through <see cref="Func{T, T, TOut}"/> instances.
    /// </summary>
    public static class CustomComparer
    {
        /// <summary>
        /// Provides a new instance of an <see cref="IComparer{T}"/> 
        /// that invokes the specified <see cref="Func{T, T, TOut}"/> <paramref name="comparer"/>.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <param name="comparer">The specified <see cref="Func{T, T, TOut}"/> to invoke for comparison.</param>
        public static IComparer<T> Create<T>(Func<T, T, int> comparer)
            => new InternalCustomComparer<T>(comparer);

        /// <summary>
        /// Converts a comparison delegate to a <see cref="Func{T, T, TOut}"/> signature
        /// </summary>
        /// <typeparam name="T">The input types for comparison.</typeparam>
        /// <param name="comparison">The comparison function.</param>
        /// <returns>Returns the delegate as a <see cref="Func{T, T, TOut}"/>.</returns>
        public static Func<T, T, int> ToFunc<T>(this Comparison<T> comparison)
            => (x, y) => comparison(x, y);

        /// <summary>
        /// Converts a comparison delegate to a <see cref="Comparison{T}"/> signature
        /// </summary>
        /// <typeparam name="T">The input types for comparison.</typeparam>
        /// <param name="func">The comparison function.</param>
        /// <returns>Returns the delegate as a <see cref="Comparison{T}"/>.</returns>
        public static Comparison<T> ToComparison<T>(this Func<T, T, int> func)
            => (x, y) => func(x, y);

        private class InternalCustomComparer<T> : IComparer<T>
        {
            private readonly Func<T, T, int> _comparer;

            public InternalCustomComparer(Func<T, T, int> comparer)
                => _comparer = comparer;

            public int Compare(T x, T y) => _comparer(x, y);
        }
    }
}