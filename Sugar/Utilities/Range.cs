namespace System.Utilities
{
    using Collections.Generic;

    /// <summary>
    /// Provides a start and end index of a specified type.
    /// </summary>
    internal class Range<T> : IRange<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> _comparer = Comparer<T>.Default;
        /// <summary>
        /// The start index.
        /// </summary>
        public T Start { get; private set; }

        /// <summary>
        /// The end index.
        /// </summary>
        public T End { get; private set; }

        /// <summary>
        /// Assumes a default value for the start age.
        /// </summary>
        /// <param name="end">A specified value required to be greater than the start.</param>
        /// <param name="comparer">Uses <see cref="Comparer{T}"/>.Default if left null.</param>
        protected internal Range(T end, IComparer<T> comparer = null)
            : this(default(T), end, comparer) { }

        /// <summary>
        /// Assumes a default value for the start age.
        /// </summary>
        /// <param name="start">The required minimum index in a range.</param>
        /// <param name="end">A specified value required to be greater than the start.</param>
        /// <param name="comparer">Uses <see cref="Comparer{T}"/>.Default if left null.</param>
        protected internal Range(T start, T end, IComparer<T> comparer = null)
        {
            Require.That(start.IsLessThan(end));
            _comparer = comparer ?? Comparer<T>.Default;
            Start = start; 
            End = end;
        }

        /// <summary>
        /// Determines if a value is within a specified range given a comparer.
        /// </summary>
        public bool Contains(T value, IComparer<T> comparer = null)
        {
            comparer = comparer ?? _comparer;

            return value.IsAtLeast(Start, comparer)
                && value.IsLessThan(End, comparer);
        }

        /// <summary>
        /// Iterates through steps using a factory method until the generated value is greater than or equal the maximum value of the specified range.
        /// </summary>
        public IEnumerable<T> AsEnumerable(Func<T, T> factoryMethod)
        {
            var current = Start;
            while (current.IsLessThan(End))
            {
                yield return current;
                current = factoryMethod(current);
            }
        }
    }

    /// <summary>
    /// Provides static methods to simplify construction of a <see cref="Range{T}"/> object.
    /// </summary>
    public static class Range
    {
        /// <summary>
        /// Creates a new instance of a <see cref="Range{T}"/>
        /// </summary>
        /// <param name="start">The minimum index of the range.</param>
        /// <param name="end">The length of the range.</param>
        /// <param name="comparer">Defaults to <see cref="Comparer{T}"/>.Default if null.</param>
        public static IRange<T> From<T>(T start, T end, IComparer<T> comparer = null)
            where T : IComparable<T>
        {
            return new Range<T>(start, end, comparer);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="Range{T}"/>
        /// </summary>
        /// <param name="end">The length of the range.</param>
        /// <param name="comparer">Defaults to <see cref="Comparer{T}"/>.Default if null.</param>
        public static IRange<T> From<T>(T end, IComparer<T> comparer = null)
            where T : IComparable<T>
        {
            return new Range<T>(end, comparer);
        }
    }
}