using System;

namespace Sugar
{
    /// <summary>
    /// Provides extension methods that simplify common operations with a System.Buffer
    /// </summary>
    public static class BufferExtensions
    {
        /// <summary>
        /// Copies a specified number of bytes from a source array starting at a particular
        /// offset to a destination array starting at a particular offset.
        /// </summary>
        public static void BlockCopy(this Array src, int srcOffset, Array dst, int dstOffset, int count)
        {
            Buffer.BlockCopy(src, srcOffset, dst, dstOffset, count);
        }

        /// <summary>
        /// Returns the number of bytes in the specified array.
        /// </summary>
        public static int ByteLength(this Array self)
        {
            return Buffer.ByteLength(self);
        }

        /// <summary>
        /// Retrieves the byte at a specified location in a specified array.
        /// </summary>
        public static byte GetByte(this Array self, int index)
        {
            return Buffer.GetByte(self, index);
        }

        /// <summary>
        /// Assigns a specified value to a byte at a particular location in a specified array.
        /// </summary>
        public static void SetByte(this Array self, int index, byte value)
        {
            Buffer.SetByte(self, index, value);
        }
    }
}