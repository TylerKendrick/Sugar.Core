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
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
        public static double ToPercentOf(this double position, int total)
        {
            Require.That(position.Sign() == total.Sign());
            return (position / total) * 100;
        }

        /// <summary>
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
        public static double ToPercentOf(this double position, float total)
        {
            Require.That(position.Sign() == total.Sign());
            return (position / total) * 100;
        }

        /// <summary>
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
        public static double ToPercentOf(this double position, double total)
        {
            Require.That(position.Sign() == total.Sign());
            return (position / total) * 100;
        }

        /// <summary>
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
        public static double ToPercentOf(this double position, long total)
        {
            Require.That(position.Sign() == total.Sign());
            return (position / total) * 100;
        }
    }
}