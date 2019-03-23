namespace System
{
    using Text;

    /// <summary>
    /// Provides extension methods to simplify common operations with a System.BitConverter.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Returns a Boolean value converted from one byte at a specified position in a specified array.
        /// </summary>
        public static bool ToBoolean(this byte[] self, int startIndex = 0)
            => BitConverter.ToBoolean(self, startIndex);

        /// <summary>
        /// Uses a <see cref="BitConverter"/> to convert the provided byte array into a hex string representation.
        /// </summary>
        /// <param name="self"></param>
        public static string ToHex(this byte[] self)
            => BitConverter.ToString(self).Replace("-", "");

        /// <summary>
        /// Returns a Unicode character converted from two bytes at a specified position in a byte array.
        /// </summary>
        public static char ToChar(this byte[] self, int startIndex = 0)
            => BitConverter.ToChar(self, startIndex);

        /// <summary>
        /// Returns a single-precision floating point number converted from four bytes at a specified position in a byte array.
        /// </summary>
        public static float ToSingle(this byte[] self, int startIndex = 0)
            => BitConverter.ToSingle(self, startIndex);

        /// <summary>
        /// Returns a double-precision floating point number converted from eight bytes at a specified position in a byte array.
        /// </summary>
        public static double ToDouble(this byte[] self, int startIndex = 0)
            => BitConverter.ToDouble(self, startIndex);

        /// <summary>
        /// Returns a 16-bit signed integer converted from two bytes at a specified position in a byte array.
        /// </summary>
        public static short ToInt16(this byte[] self, int startIndex = 0)
            => BitConverter.ToInt16(self, startIndex);

        /// <summary>
        /// Returns a 32-bit signed integer converted from four bytes at a specified position in a byte array.
        /// </summary>
        public static int ToInt32(this byte[] self, int startIndex = 0)
            => BitConverter.ToInt32(self, startIndex);

        /// <summary>
        /// Returns a 64-bit signed integer converted from eight bytes at a specified position in a byte array.
        /// </summary>
        public static long ToInt64(this byte[] self, int startIndex = 0)
            => BitConverter.ToInt64(self, startIndex);

        /// <summary>
        /// Returns a 16-bit unsigned integer converted from two bytes at a specified position in a byte array.
        /// </summary>
        public static ushort ToUInt16(this byte[] self, int startIndex = 0)
            => BitConverter.ToUInt16(self, startIndex);

        /// <summary>
        /// Returns a 32-bit unsigned integer converted from four bytes at a specified position in a byte array.
        /// </summary>
        public static uint ToUInt32(this byte[] self, int startIndex = 0)
            => BitConverter.ToUInt32(self, startIndex);

        /// <summary>
        /// Returns a 64-bit unsigned integer converted from eight bytes at a specified position in a byte array.
        /// </summary>
        public static ulong ToUInt64(this byte[] self, int startIndex = 0)
            => BitConverter.ToUInt64(self, startIndex);

        /// <summary>
        /// Indicates the byte order ("endianness") in which data is stored in this computer architecture.
        /// </summary>
        public static bool IsLittleEndian(this byte[] self) => BitConverter.IsLittleEndian;

        /// <summary>
        /// Indicates the byte order ("endianness") in which data is stored in this computer architecture.
        /// </summary>
        public static bool IsBigEndian(this byte[] self) => !BitConverter.IsLittleEndian;

        /// <summary>
        /// Converts the numeric value of each element of a specified sub-array of bytes to its equivalent hexadecimal string representation.
        /// </summary>
        public static string ToString(this byte[] self, int startIndex = 0)
            => BitConverter.ToString(self, startIndex);

        /// <summary>
        /// Converts the numeric value of each element of a specified sub-array of bytes to its equivalent hexadecimal string representation.
        /// </summary>
        public static string ToString(this byte[] self, int startIndex, int length)
            => BitConverter.ToString(self, startIndex, length);

        /// <summary>
        /// Returns the specified Boolean value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this bool self)
            => BitConverter.GetBytes(self);

        /// <summary>
        /// Returns the specified Unicode character value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this char self)
            => BitConverter.GetBytes(self);

        /// <summary>
        /// Returns the specified string value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this string self, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.Default;
            return encoding.GetBytes(self);
        }

        /// <summary>
        /// Returns the specified 32-bit signed integer value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this int self)
            => BitConverter.GetBytes(self);

        /// <summary>
        /// Returns the specified 64-bit signed integer value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this long self)
            => BitConverter.GetBytes(self);

        /// <summary>
        /// Returns the specified double-precision floating point value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this double self)
            => BitConverter.GetBytes(self);

        /// <summary>
        /// Returns the specified single-precision floating point value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this float self)
            => BitConverter.GetBytes(self);

        /// <summary>
        /// Returns the specified 32-bit unsigned integer value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this uint self)
            => BitConverter.GetBytes(self);

        /// <summary>
        /// Returns the specified 16-bit unsigned integer value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this ushort self)
            => BitConverter.GetBytes(self);

        /// <summary>
        /// Returns the specified 64-bit unsigned integer value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this ulong self)
            => BitConverter.GetBytes(self);

        /// <summary>
        /// Converts the provided string into a base 64 encoded format with the default <see cref="Base64FormattingOptions"/>.
        /// </summary>
        public static string ToBase64String(this byte[] self)
            => Convert.ToBase64String(self);

        /// <summary>
        /// Converts the provided string into a base 64 encoded format with the specified <see cref="Base64FormattingOptions"/>.
        /// </summary>
        public static string ToBase64String(this byte[] self, Base64FormattingOptions formattingOptions)
            => Convert.ToBase64String(self, formattingOptions);
    }
}