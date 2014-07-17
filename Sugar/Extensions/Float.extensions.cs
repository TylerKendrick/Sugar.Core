namespace System
{
    /// <summary>
    /// Provides extensions to common operations with <see cref="float"/> numbers.
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Checks to see if the value <paramref name="self"/> is greater than or equal to zero.
        /// </summary>
        public static bool IsPositive(this float self)
        {
            return self >= 0;
        }

        /// <summary>
        /// Checks to see if the value <paramref name="self"/> is less than zero.
        /// </summary>
        public static bool IsNegative(this float self)
        {
            return self < 0;
        }

        /// <summary>
        /// Exposes float.IsPositiveInfinity as an extension to <see cref="float"/> instances.
        /// </summary>
        public static bool IsPositiveInfinity(this float self)
        {
            return float.IsPositiveInfinity(self);
        }

        /// <summary>
        /// Exposes float.IsNegativeInfinity as an extension to <see cref="float"/> instances.
        /// </summary>
        public static bool IsNegativeInfinity(this float self)
        {
            return float.IsNegativeInfinity(self);
        }

        /// <summary>
        /// Exposes float.IsInfinity as an extension to <see cref="float"/> instances.
        /// </summary>
        public static bool IsInfinity(this float self)
        {
            return float.IsInfinity(self);
        }

        /// <summary>
        /// Exposes float.IsInfinity as an extension to <see cref="float"/> instances.
        /// </summary>
        public static bool IsNaN(this float self)
        {
            return float.IsNaN(self);
        }
    }
}
