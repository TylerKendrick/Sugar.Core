using System;
using Sugar.Math;

namespace Sugar
{
    /// <summary>
    /// Provides extensions to common operations with decimal numbers.
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
		public static decimal ToPercentOf(this decimal position, int total)
        {
            Require.That(position.Sign(), Is.SameAs(total.Sign()));
            return (position / total) * 100;
		}

        /// <summary>
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
		public static decimal ToPercentOf(this decimal position, decimal total)
		{
            Require.That(position.Sign(), Is.SameAs(total.Sign()));
            return (position / total) * 100;
		}

        /// <summary>
        /// Returns <paramref name="position"/> as a percentage of <paramref name="total"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">Throw a new exception if specified numeric parameters aren't matching signs.</exception>
		public static decimal ToPercentOf(this decimal position, long total)
        {
            Require.That(position.Sign(), Is.SameAs(total.Sign()));
            return (position / total) * 100;
		}
    }
}