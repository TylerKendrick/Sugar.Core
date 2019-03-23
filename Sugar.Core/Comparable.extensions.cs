namespace System
{
    using Collections.Generic;

    /// <summary>
    /// Provides non-fluent comparison operations against generic types.
    /// </summary>
    public static class Comparable
    {
        /// <summary>
        /// Compares two <typeparamref name="T"/> values by sort order.  
        /// </summary>
        /// <returns>Returns true if <paramref name="self"/> is less than or equal to <paramref name="other"/>.</returns>
        public static bool IsAtMost<T>(this T self, T other) => IsAtMost(self, other, null);

        /// <summary>
        /// Compares two <typeparamref name="T"/> values by sort order.  
        /// </summary>
        /// <returns>Returns true if <paramref name="self"/> is less than or equal to <paramref name="other"/>.</returns>
        public static bool IsAtMost<T>(this T self, T other, IComparer<T> comparer)
        {
            comparer = comparer ?? Comparer<T>.Default;
            return comparer.Compare(self, other) <= 0;
        }

        /// <summary>
        /// Compares two <typeparamref name="T"/> values by sort order.  
        /// </summary>
        /// <returns>Returns true if <paramref name="self"/> is greater than or equal to <paramref name="other"/>.</returns>
        public static bool IsAtLeast<T>(this T self, T other) => IsAtLeast(self, other, null);

        /// <summary>
        /// Compares two <typeparamref name="T"/> values by sort order.  
        /// </summary>
        /// <returns>Returns true if <paramref name="self"/> is greater than or equal to <paramref name="other"/>.</returns>
        public static bool IsAtLeast<T>(this T self, T other, IComparer<T> comparer)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(self, other);
            return result >= 0;
        }

        /// <summary>
        /// Compares two <typeparamref name="T"/> values by sort order.  
        /// </summary>
        /// <returns>Returns true if <paramref name="self"/> is greater than or equal to <paramref name="other"/>.</returns>
        public static bool IsLessThan<T>(this T self, T other) => IsLessThan(self, other, null);

        /// <summary>
        /// Compares two <typeparamref name="T"/> values by sort order.  
        /// </summary>
        /// <returns>Returns true if <paramref name="self"/> is greater than or equal to <paramref name="other"/>.</returns>
        public static bool IsLessThan<T>(this T self, T other, IComparer<T> comparer)
        {
            comparer = comparer ?? Comparer<T>.Default;
            return comparer.Compare(self, other) < 0;
        }

        /// <summary>
        /// Compares two <typeparamref name="T"/> values by sort order.  
        /// </summary>
        /// <returns>Returns true if <paramref name="self"/> is greater than <paramref name="other"/>.</returns>
        public static bool IsGreaterThan<T>(this T self, T other) => IsGreaterThan(self, other, null);

        /// <summary>
        /// Compares two <typeparamref name="T"/> values by sort order.  
        /// </summary>
        /// <returns>Returns true if <paramref name="self"/> is greater than <paramref name="other"/>.</returns>
        public static bool IsGreaterThan<T>(this T self, T other, IComparer<T> comparer)
        {
            comparer = comparer ?? Comparer<T>.Default;
            return comparer.Compare(self, other) > 0;
        }

        /// <summary>
        /// Compares two <typeparamref name="T"/> values by sort order.  
        /// </summary>
        /// <returns>Returns true if <paramref name="self"/> is equal to <paramref name="other"/>.</returns>
        public static bool IsSameAs<T>(this T self, T other) => IsSameAs(self, other, null);

        /// <summary>
        /// Compares two <typeparamref name="T"/> values by sort order.  
        /// </summary>
        /// <returns>Returns true if <paramref name="self"/> 
        /// is equal to <paramref name="other"/>.</returns>
        public static bool IsSameAs<T>(this T self, T other, IComparer<T> comparer)
        {
            comparer = comparer ?? Comparer<T>.Default;
            return comparer.Compare(self, other) == 0;
        }

        /// <summary>
        /// Limits the value by a comparable maximum value.
        /// </summary>
        /// <param name="value">The value being compared.</param>
        /// <param name="max">The maximum value for comparison.</param>
        /// <param name="comparer">Optional comparer.</param>
        /// <returns>Returns the current value unless the maximum value is exceeded; 
        /// Otherwise, it returns the maximum value.</returns>
        public static T Limit<T>(this T value, T max, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            return value.IsAtMost(max, comparer) ? value : max;
        }

        /// <summary>
        /// Limits the value by a comparable minimum and maximum value.
        /// </summary>
        /// <param name="value">The value being compared.</param>
        /// <param name="min">The minimum value for comparison.</param>
        /// <param name="max">The maximum value for comparison.</param>
        /// <param name="comparer">Optional comparer. Uses Comparer.Default if no value is provided.</param>
        /// <returns>Returns the current value unless the maximum value is exceeded; 
        /// Otherwise, it returns the maximum value.</returns>
        public static T Limit<T>(this T value, T min, T max, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            Require.That(min.IsLessThan(max, comparer));

            return value.IsAtLeast(min, comparer)
                ? value.IsAtMost(max, comparer)
                    ? value
                    : max
                : value.IsAtMost(max, comparer)
                    ? min
                    : max;
        }

        /// <summary>
        /// Limits the value by a comparable minimum and maximum value.
        /// </summary>
        /// <param name="value">The value being compared.</param>
        /// <param name="range">The minimum and maximum values for comparison.</param>
        /// <param name="comparer">Optional comparer. Uses Comparer.Default if no value is provided.</param>
        /// <returns>Returns the current value unless the maximum value is exceeded; 
        /// Otherwise, it returns the maximum value.</returns>
        public static T Limit<T>(this T value, IRange<T> range, IComparer<T> comparer = null)
            where T : IComparable<T>
        {
            comparer = comparer ?? Comparer<T>.Default;
            Require.That(range.Start.IsLessThan(range.End, comparer));

            return value.IsAtLeast(range.Start, comparer)
                ? value.IsAtMost(range.End, comparer)
                    ? value
                    : range.End
                : value.IsAtMost(range.End, comparer)
                    ? range.Start
                    : range.End;
        }
    }
}