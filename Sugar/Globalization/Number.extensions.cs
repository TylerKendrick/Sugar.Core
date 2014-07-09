using System;
using System.Globalization;

namespace Sugar.Globalization
{
    /// <summary>
    /// Provides extensions to simplify precision number formatting.
    /// </summary>
    public static class NumberExtensions
    {
        private static NumberFormatInfo ToPrecisionFormatter(int length)
        {
            var numberFormatInfo = new NumberFormatInfo { NumberDecimalDigits = length };
            return numberFormatInfo;
        }
        private static string ToPrecisionFormat(int length, Func<string, NumberFormatInfo, string> toString)
        {
            return toString("N", ToPrecisionFormatter(length));
        }
        private static T FromPrecisionString<T>(int length, Func<string, NumberFormatInfo, string> toString, Func<string, T> parse)
        {
            var formatted = ToPrecisionFormat(length, toString);
            return parse(formatted);
        }

        /// <summary>
        /// Simplifies invocation of Precision formatting.
        /// </summary>
        /// <param name="self">The target number to format.</param>
        /// <param name="length">The precision length.</param>
        public static double ToPrecision(this double self, int length)
        {
            return FromPrecisionString(length, self.ToString, double.Parse);
        }

        /// <summary>
        /// Simplifies invocation of Precision formatting.
        /// </summary>
        /// <param name="self">The target number to format.</param>
        /// <param name="length">The precision length.</param>
        public static decimal ToPrecision(this decimal self, int length)
        {
            return FromPrecisionString(length, self.ToString, decimal.Parse);
        }
        
        /// <summary>
        /// Simplifies invocation of Precision formatting.
        /// </summary>
        /// <param name="self">The target number to format.</param>
        /// <param name="length">The precision length.</param>
        public static float ToPrecision(this float self, ushort length)
        {
            return FromPrecisionString(length, self.ToString, float.Parse);
        }
    }
}