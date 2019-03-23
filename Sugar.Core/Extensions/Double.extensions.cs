namespace System
{
    /// <summary>
    /// Provides extensions to common operations with <see cref="Double"/> numbers.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Checks to see if the value <paramref name="self"/> is greater than or equal to zero.
        /// </summary>
        public static bool IsPositive(this double self) => self >= 0;

        /// <summary>
        /// Checks to see if the value <paramref name="self"/> is less than zero.
        /// </summary>
        public static bool IsNegative(this double self) => self < 0;

        /// <summary>
        /// Exposes double.IsPositiveInfinity as an extension to <see cref="Double"/> instances.
        /// </summary>
        public static bool IsPositiveInfinity(this double self)
            => double.IsPositiveInfinity(self);

        /// <summary>
        /// Exposes double.IsNegativeInfinity as an extension to <see cref="Double"/> instances.
        /// </summary>
        public static bool IsNegativeInfinity(this double self)
            => double.IsNegativeInfinity(self);

        /// <summary>
        /// Exposes double.IsInfinity as an extension to <see cref="Double"/> instances.
        /// </summary>
        public static bool IsInfinity(this double self)
            => double.IsInfinity(self);

        /// <summary>
        /// Exposes double.IsInfinity as an extension to <see cref="Double"/> instances.
        /// </summary>
        public static bool IsNaN(this double self)
            => double.IsNaN(self);

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