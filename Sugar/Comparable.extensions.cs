using System;
using System.Collections.Generic;

namespace Sugar
{
    /// <summary>
    /// Provides non-fluent comparison operations against generic types.
    /// </summary>
    public static class Comparable
    {
        /// <summary>
        /// Limits the value by a comparable maximum value.
        /// </summary>
        /// <param name="value">The value being compared.</param>
        /// <param name="max">The maximum value for comparison.</param>
        /// <param name="comparer">Optional comparer.</param>
        /// <returns>Returns the current value unless the maximum value is exceeded; Otherwise, it returns the maximum value.</returns>
        public static T Limit<T>(this T value, T max, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            return Fluent.It(value, Is.AtMost(max, comparer)) ? value : max;
        }

        /// <summary>
        /// Limits the value by a comparable minimum and maximum value.
        /// </summary>
        /// <param name="value">The value being compared.</param>
        /// <param name="min">The minimum value for comparison.</param>
        /// <param name="max">The maximum value for comparison.</param>
        /// <param name="comparer">Optional comparer. Uses Comparer.Default if no value is provided.</param>
        /// <returns>Returns the current value unless the maximum value is exceeded; Otherwise, it returns the maximum value.</returns>
        public static T Limit<T>(this T value, T min, T max, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            Require.That(min, Is.LessThan(max, comparer));

            var it = Fluent.It(value);
            return it.Is.AtLeast(min, comparer)
                ? it.Is.AtMost(max, comparer)
                    ? value
                    : max
                : it.Is.AtMost(max, comparer)
                    ? min
                    : max;
        }

        /// <summary>
        /// Limits the value by a comparable minimum and maximum value.
        /// </summary>
        /// <param name="value">The value being compared.</param>
        /// <param name="range">The minimum and maximum values for comparison.</param>
        /// <param name="comparer">Optional comparer. Uses Comparer.Default if no value is provided.</param>
        /// <returns>Returns the current value unless the maximum value is exceeded; Otherwise, it returns the maximum value.</returns>
        public static T Limit<T>(this T value, IRange<T> range, IComparer<T> comparer = null) 
            where T : IComparable<T>
        {
            comparer = comparer ?? Comparer<T>.Default;
            Require.That(range.Start, Is.LessThan(range.End, comparer));

            var it = Fluent.It(value);
            return it.Is.AtLeast(range.Start, comparer)
                ? it.Is.AtMost(range.End, comparer)
                    ? value
                    : range.End
                : it.Is.AtMost(range.End, comparer)
                    ? range.Start
                    : range.End;
        }
    }
}