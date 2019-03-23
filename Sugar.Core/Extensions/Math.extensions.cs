namespace System
{
    /// <summary>
    /// Exposes the static methods of System.Math as instance extension methods.
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// Rounds a decimal value to a specified number of fractional digits.
        /// </summary>
        /// 
        /// <returns>
        /// The number nearest to <paramref name="self"/> that contains a number of fractional digits equal to <paramref name="precision"/>.
        /// </returns>
        public static decimal Round(this decimal self, ushort precision)
            => Math.Round(self, precision);

        /// <summary>
        /// Rounds a decimal value to a specified number of fractional digits.
        /// </summary>
        /// 
        /// <returns>
        /// The number nearest to <paramref name="self"/> that contains a number of fractional digits equal to <paramref name="precision"/>.
        /// </returns>
        public static double Round(this double self, ushort precision)
            => Math.Round(self, precision);

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static decimal ToAbs(this decimal self) => Math.Abs(self);

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static double ToAbs(this double self) => Math.Abs(self);

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static float ToAbs(this float self) => Math.Abs(self);

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static int ToAbs(this int self) => Math.Abs(self);

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static long ToAbs(this long self) => Math.Abs(self);

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static sbyte ToAbs(this sbyte self) => Math.Abs(self);

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static short ToAbs(this short self) => Math.Abs(self);

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// 
        /// <returns>
        /// The smallest integer that is greater than or equal to <paramref name="self"/>. 
        /// </returns>
        public static decimal ToCeiling(this decimal self) => Math.Ceiling(self);

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// 
        /// <returns>
        /// The smallest integer that is greater than or equal to <paramref name="self"/>. 
        /// </returns>
        public static double ToCeiling(this double self) => Math.Ceiling(self);

        /// <summary>
        /// Returns the largest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// 
        /// <returns>
        /// The smallest largest that is greater than or equal to <paramref name="self"/>. 
        /// </returns>
        public static decimal ToFloor(this decimal self) => Math.Floor(self);

        /// <summary>
        /// Returns the largest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// 
        /// <returns>
        /// The smallest largest that is greater than or equal to <paramref name="self"/>. 
        /// </returns>
        public static double ToFloor(this double self) => Math.Floor(self);

        /// <summary>
        /// Returns the logarithm of a specified number in a specified base.
        /// </summary>
        public static double ToLog(this double self, ushort @base = 10) => Math.Log(self, @base);

        /// <summary>
        /// Returns the logarithm of a specified number in a specified base.
        /// </summary>
        public static double ToPow(this double self, int power) => Math.Pow(self, power);

        /// <summary>
        /// Returns a value indicating the sign of a 32-bit signed integer.
        /// </summary>
        public static int Sign(this int self) => Math.Sign(self);

        /// <summary>
        /// Returns a value indicating the sign of a decimal number.
        /// </summary>
        public static int Sign(this decimal self) => Math.Sign(self);

        /// <summary>
        /// Returns a value indicating the sign of a double-precision floating-point number.
        /// </summary>
        public static int Sign(this double self) => Math.Sign(self);

        /// <summary>
        /// Returns a value indicating the sign of a single-precision floating-point number.
        /// </summary>
        public static int Sign(this float self) => Math.Sign(self);

        /// <summary>
        /// Returns a value indicating the sign of a 64-bit signed integer.
        /// </summary>
        public static int Sign(this long self) => Math.Sign(self);
    }
}