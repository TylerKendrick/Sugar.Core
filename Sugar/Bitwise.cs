using System;
using System.Linq;

namespace Sugar
{
    public static class Bitwise
    {
        /// <summary>
        /// Returns the bitwise and operation result between self and other.
        /// </summary>
        public static byte And(byte self, byte other)
        {
            return (self & other).Cast<byte>();
        }

        public static byte And(byte self, Func<byte, byte, byte> aggregator, params byte[] others)
        {
            return others
                .Select(x => And(self, (byte) x))
                .Aggregate(aggregator);
        }

        /// <summary>
        /// Returns the bitwise or operation result between self and other.
        /// </summary>
        public static byte Or(byte self, byte other)
        {
            return (self | other).Cast<byte>();
        }
        public static byte Or(byte self, Func<byte, byte, byte> aggregator, params byte[] others)
        {
            return others
                .Select(x => Or(self, x))
                .Aggregate(aggregator);
        }

        /// <summary>
        /// Returns the bitwise xor operation result between self and other.
        /// </summary>
        public static byte XOr(byte self, byte other)
        {
            return (self ^ other).Cast<byte>();
        }
        public static byte XOr(byte self, Func<byte, byte, byte> aggregator, params byte[] others)
        {
            return others
                .Select(x => XOr(self, x))
                .Aggregate(aggregator);
        }


        /// <summary>
        /// Returns the bitwise not operation result between self and other.
        /// </summary>
        public static byte Not(byte self)
        {
            return (~self).Cast<byte>();
        }
    }
}