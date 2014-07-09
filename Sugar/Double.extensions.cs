using System;
using Sugar.Math;

namespace Sugar
{
    /// <summary>
    /// Provides extensions to common operations with <see cref="Double"/> numbers.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Returns true if the number is greater than or equal to zero.
        /// </summary>
        public static bool IsPositive(this double number)
        {
            return number >= 0;
        }

        /// <summary>
        /// Returns true if the number is less than zero.
        /// </summary>
        public static bool IsNegative(this double number)
        {
            return number < 0;
        }

        /// <summary>
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
        public static double ToPercentOf(this double position, int total)
        {
            Require.That(position.Sign(), Is.SameAs(total.Sign()));
            return (position / total) * 100;
        }

        /// <summary>
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
        public static double ToPercentOf(this double position, float total)
        {
            Require.That(position.Sign(), Is.SameAs(total.Sign()));
            return (position / total) * 100;
        }

        /// <summary>
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
        public static double ToPercentOf(this double position, double total)
        {
            Require.That(position.Sign(), Is.SameAs(total.Sign()));
            return (position / total) * 100;
        }

        /// <summary>
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
        public static double ToPercentOf(this double position, long total)
        {
            Require.That(position.Sign(), Is.SameAs(total.Sign()));
            return (position / total) * 100;
        }
    }
}