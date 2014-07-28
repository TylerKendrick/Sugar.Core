namespace System
{
    using Collections.Generic;

    /// <summary>
    /// Provides custom implementations of <see cref="IEqualityComparer{T}"/> through <see cref="Func{T, T, TOut}"/> instances.
    /// </summary>
    public class EqualityComparer
    {
        /// <summary>
        /// Provides a new instance of an <see cref="IEqualityComparer{T}"/> 
        /// that invokes the specified <see cref="Func{T, T, TOut}"/> <paramref name="equalityComparer"/>.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <param name="equalityComparer">The specified <see cref="Func{T, T, TOut}"/> to invoke for comparison.</param>
        public static IEqualityComparer<T> Create<T>(Func<T, T, bool> equalityComparer)
        {
            return new InternalEqualityComparer<T>(equalityComparer, x => x.GetHashCode());
        }

        /// <summary>
        /// Provides a new instance of an <see cref="IEqualityComparer{T}"/> 
        /// that invokes the specified <see cref="Func{T, T, TOut}"/> <paramref name="equalityComparer"/>.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <param name="equalityComparer">The specified <see cref="Func{T, T, TOut}"/> to invoke for comparison.</param>
        /// <param name="hashGenerator">The specified <see cref="Func{T, TOut}"/> for generating a hash for the objects being converted.</param>
        public static IEqualityComparer<T> Create<T>(Func<T, T, bool> equalityComparer,
            Func<T, int> hashGenerator)
        {
            return new InternalEqualityComparer<T>(equalityComparer, hashGenerator);
        }
        internal class InternalEqualityComparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _equalityComparer;
            private readonly Func<T, int> _hashGenerator;

            internal InternalEqualityComparer(Func<T, T, bool> equalityComparer,
                Func<T, int> hashGenerator)
            {
                _equalityComparer = equalityComparer;
                _hashGenerator = hashGenerator;
            }

            public bool Equals(T x, T y)
            {
                return _equalityComparer(x, y);
            }

            public int GetHashCode(T arg)
            {
                return _hashGenerator(arg);
            }
        }
    }
}