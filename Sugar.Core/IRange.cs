using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// Provides a start and end index.
    /// </summary>
    /// <typeparam name="T">The type of objects in the range.</typeparam>
    public interface IRange<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// The start index.
        /// </summary>
        T Start { get; }

        /// <summary>
        /// The end index.
        /// </summary>
        T End { get; }

        /// <summary>
        /// Uses a comparer to ensure a value is between the min and max provided values.
        /// </summary>
        /// <param name="value">The object for comparison.</param>
        /// <param name="comparer">Uses Comparer.Default if no value has been provided.</param>
        /// <returns>The boolean result representing if the value is in range.</returns>
        bool Contains(T value, IComparer<T> comparer = null);

        /// <summary>
        /// Uses a factory method to generate the values between the mind and max values.
        /// Contains the minimum value and all steps until the max value.
        /// </summary>
        /// <param name="factoryMethod">The required method for generating values in the range.</param>
        /// <returns></returns>
        IEnumerable<T> AsEnumerable(Func<T, T> factoryMethod);
    }
}