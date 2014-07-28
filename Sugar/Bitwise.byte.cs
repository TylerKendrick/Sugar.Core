using System.Linq;

namespace System
{
    /// <summary>
    /// Exposes bitwise operators as methods to allow them to be passed as first class functions.
    /// </summary>
    public static partial class Bitwise
    {
        /// <summary>
        /// Returns the bitwise and operation result between self and other.
        /// </summary>
        public static byte And(this byte self, byte other)
        {
            return Operators.Byte
                .And(self, other)
                .Cast<byte>();
        }

        /// <summary>
        /// Applies an aggregator function to the results of <paramref name="self"/> 
        /// applied against each item in <paramref name="others"/>
        /// with the bitwise AND operator.
        /// </summary>
        /// <param name="self">The target byte operand.</param>
        /// <param name="aggregator">The aggregation applied to each result.</param>
        /// <param name="others">A collection of bytes to apply against <paramref name="self"/>.</param>
        /// <returns>A single byte value representing </returns>
        public static byte And(this byte self, Func<byte, byte, byte> aggregator, params byte[] others)
        {
            return others
                .Select(x => self.And(x))
                .Aggregate(aggregator);
        }

        /// <summary>
        /// Returns the bitwise or operation result between self and other.
        /// </summary>
        public static byte Or(this byte self, byte other)
        {
            return Operators.Byte
                .Or(self, other)
                .Cast<byte>();
        }

        /// <summary>
        /// Applies an aggregator function to the results of <paramref name="self"/> 
        /// applied against each item in <paramref name="others"/>
        /// with the bitwise | operator.
        /// </summary>
        /// <param name="self">The target byte operand.</param>
        /// <param name="aggregator">The aggregation applied to each result.</param>
        /// <param name="others">A collection of bytes to apply against <paramref name="self"/>.</param>
        /// <returns>A single byte value representing </returns>
        public static byte Or(this byte self, Func<byte, byte, byte> aggregator, params byte[] others)
        {
            return others
                .Select(x => self.Or(x))
                .Aggregate(aggregator);
        }

        /// <summary>
        /// Returns the bitwise xor operation result between self and other.
        /// </summary>
        public static byte XOr(this byte self, byte other)
        {
            return Operators.Byte
                .XOr(self, other)
                .Cast<byte>();
        }

        /// <summary>
        /// Applies an aggregator function to the results of <paramref name="self"/> 
        /// applied against each item in <paramref name="others"/>
        /// with the bitwise ^ operator.
        /// </summary>
        /// <param name="self">The target byte operand.</param>
        /// <param name="aggregator">The aggregation applied to each result.</param>
        /// <param name="others">A collection of bytes to apply against <paramref name="self"/>.</param>
        /// <returns>A single byte value representing </returns>
        public static byte XOr(this byte self, Func<byte, byte, byte> aggregator, params byte[] others)
        {
            return others
                .Select(x => self.XOr(x))
                .Aggregate(aggregator);
        }


        /// <summary>
        /// Returns the bitwise not operation result between self and other.
        /// </summary>
        public static byte Not(this byte self)
        {
            return Operators.Byte
                .Not(self)
                .Cast<byte>();
        }
    }
}