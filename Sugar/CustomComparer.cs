namespace System
{
    using Collections.Generic;

    /// <summary>
    /// Provides custom implementations of <see cref="IComparer{T}"/> through <see cref="Func{T, T, int}"/> instances.
    /// </summary>
    public static class CustomComparer
    {
        /// <summary>
        /// Provides a new instance of an <see cref="IComparer{T}"/> that invokes the specified <see cref="Func{T, T, int}"/> <paramref name="comparer"/>.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <param name="comparer">The specified <see cref="Func{T, T, int}"/> to invoke for comparison.</param>
        /// <returns></returns>
        public static IComparer<T> Create<T>(Func<T, T, int> comparer)
        {
            return new InternalCustomComparer<T>(comparer);
        }
        private class InternalCustomComparer<T> : IComparer<T>
        {
            private readonly Func<T, T, int> _comparer;

            public InternalCustomComparer(Func<T, T, int> comparer)
            {
                _comparer = comparer;
            }

            public int Compare(T x, T y)
            {
                return _comparer(x, y);
            }
        }
    }
}