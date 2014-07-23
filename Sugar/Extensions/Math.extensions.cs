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
        {
            return Math.Round(self, precision);
        }

        /// <summary>
        /// Rounds a decimal value to a specified number of fractional digits.
        /// </summary>
        /// 
        /// <returns>
        /// The number nearest to <paramref name="self"/> that contains a number of fractional digits equal to <paramref name="precision"/>.
        /// </returns>
        public static double Round(this double self, ushort precision)
        {
            return Math.Round(self, precision);
        }


        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static decimal ToAbs(this decimal self)
        {
            return Math.Abs(self);
        }

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static double ToAbs(this double self)
        {
            return Math.Abs(self);
        }

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static float ToAbs(this float self)
        {
            return Math.Abs(self);
        }

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static int ToAbs(this int self)
        {
            return Math.Abs(self);
        }

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static long ToAbs(this long self)
        {
            return Math.Abs(self);
        }

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static sbyte ToAbs(this sbyte self)
        {
            return Math.Abs(self);
        }

        /// <summary>
        /// Returns the absolute value of a <see cref="T:System.Decimal"/> number.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Decimal"/>, x, such that 0 ≤ x ≤<see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        public static short ToAbs(this short self)
        {
            return Math.Abs(self);
        }


        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// 
        /// <returns>
        /// The smallest integer that is greater than or equal to <paramref name="self"/>. 
        /// </returns>
        public static decimal ToCeiling(this decimal self)
        {
            return Math.Ceiling(self);
        }

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// 
        /// <returns>
        /// The smallest integer that is greater than or equal to <paramref name="self"/>. 
        /// </returns>
        public static double ToCeiling(this double self)
        {
            return Math.Ceiling(self);
        }


        /// <summary>
        /// Returns the largest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// 
        /// <returns>
        /// The smallest largest that is greater than or equal to <paramref name="self"/>. 
        /// </returns>
        public static decimal ToFloor(this decimal self)
        {
            return Math.Floor(self);
        }

        /// <summary>
        /// Returns the largest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// 
        /// <returns>
        /// The smallest largest that is greater than or equal to <paramref name="self"/>. 
        /// </returns>
        public static double ToFloor(this double self)
        {
            return Math.Floor(self);
        }


        /// <summary>
        /// Returns the logarithm of a specified number in a specified base.
        /// </summary>
        public static double ToLog(this double self, ushort @base = 10)
        {
            return Math.Log(self, @base);
        }

        /// <summary>
        /// Returns the logarithm of a specified number in a specified base.
        /// </summary>
        public static double ToPow(this double self, int power)
        {
            return Math.Pow(self, power);
        }

        /// <summary>
        /// Returns a value indicating the sign of a 32-bit signed integer.
        /// </summary>
        public static int Sign(this int self)
        {
            return Math.Sign(self);
        }

        /// <summary>
        /// Returns a value indicating the sign of a decimal number.
        /// </summary>
        public static int Sign(this decimal self)
        {
            return Math.Sign(self);
        }

        /// <summary>
        /// Returns a value indicating the sign of a double-precision floating-point number.
        /// </summary>
        public static int Sign(this double self)
        {
            return Math.Sign(self);
        }

        /// <summary>
        /// Returns a value indicating the sign of a single-precision floating-point number.
        /// </summary>
        public static int Sign(this float self)
        {
            return Math.Sign(self);
        }

        /// <summary>
        /// Returns a value indicating the sign of a 64-bit signed integer.
        /// </summary>
        public static int Sign(this long self)
        {
            return Math.Sign(self);
        }
    }
}