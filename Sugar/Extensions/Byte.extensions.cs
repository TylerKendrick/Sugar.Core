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
        {
            return BitConverter.ToBoolean(self, startIndex);
        }

        /// <summary>
        /// Uses a <see cref="BitConverter"/> to convert the provided byte array into a hex string representation.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToHex(this byte[] self)
        {
            return BitConverter.ToString(self).Replace("-", "");
        }

        /// <summary>
        /// Returns a Unicode character converted from two bytes at a specified position in a byte array.
        /// </summary>
        public static char ToChar(this byte[] self, int startIndex = 0)
        {
            return BitConverter.ToChar(self, startIndex);
        }

        /// <summary>
        /// Returns a single-precision floating point number converted from four bytes at a specified position in a byte array.
        /// </summary>
        public static Single ToSingle(this byte[] self, int startIndex = 0)
        {
            return BitConverter.ToSingle(self, startIndex);
        }    
        
        /// <summary>
        /// Returns a double-precision floating point number converted from eight bytes at a specified position in a byte array.
        /// </summary>
        public static double ToDouble(this byte[] self, int startIndex = 0)
        {
            return BitConverter.ToDouble(self, startIndex);
        }

        /// <summary>
        /// Returns a 16-bit signed integer converted from two bytes at a specified position in a byte array.
        /// </summary>
        public static Int16 ToInt16(this byte[] self, int startIndex = 0)
        {
            return BitConverter.ToInt16(self, startIndex);
        }

        /// <summary>
        /// Returns a 32-bit signed integer converted from four bytes at a specified position in a byte array.
        /// </summary>
        public static Int32 ToInt32(this byte[] self, int startIndex = 0)
        {
            return BitConverter.ToInt32(self, startIndex);
        }

        /// <summary>
        /// Returns a 64-bit signed integer converted from eight bytes at a specified position in a byte array.
        /// </summary>
        public static Int64 ToInt64(this byte[] self, int startIndex = 0)
        {
            return BitConverter.ToInt64(self, startIndex);
        }

        /// <summary>
        /// Returns a 16-bit unsigned integer converted from two bytes at a specified position in a byte array.
        /// </summary>
        public static UInt16 ToUInt16(this byte[] self, int startIndex = 0)
        {
            return BitConverter.ToUInt16(self, startIndex);
        }

        /// <summary>
        /// Returns a 32-bit unsigned integer converted from four bytes at a specified position in a byte array.
        /// </summary>
        public static UInt32 ToUInt32(this byte[] self, int startIndex = 0)
        {
            return BitConverter.ToUInt32(self, startIndex);
        }

        /// <summary>
        /// Returns a 64-bit unsigned integer converted from eight bytes at a specified position in a byte array.
        /// </summary>
        public static UInt64 ToUInt64(this byte[] self, int startIndex = 0)
        {
            return BitConverter.ToUInt64(self, startIndex);
        }

        /// <summary>
        /// Indicates the byte order ("endianness") in which data is stored in this computer architecture.
        /// </summary>
        public static bool IsLittleEndian(this byte[] self)
        {
            return BitConverter.IsLittleEndian;
        }

        /// <summary>
        /// Indicates the byte order ("endianness") in which data is stored in this computer architecture.
        /// </summary>
        public static bool IsBigEndian(this byte[] self)
        {
            return BitConverter.IsLittleEndian == false;
        }

        /// <summary>
        /// Converts the numeric value of each element of a specified subarray of bytes to its equivalent hexadecimal string representation.
        /// </summary>
        public static string ToString(this byte[] self, int startIndex = 0)
        {
            return BitConverter.ToString(self, startIndex);
        }

        /// <summary>
        /// Converts the numeric value of each element of a specified subarray of bytes to its equivalent hexadecimal string representation.
        /// </summary>
        public static string ToString(this byte[] self, int startIndex, int length)
        {
            return BitConverter.ToString(self, startIndex, length);
        }

        /// <summary>
        /// Returns the specified Boolean value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this bool self)
        {
            return BitConverter.GetBytes(self);
        }

        /// <summary>
        /// Returns the specified Unicode character value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this char self)
        {
            return BitConverter.GetBytes(self);
        }
        
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
        {
            return BitConverter.GetBytes(self);
        }

        /// <summary>
        /// Returns the specified 64-bit signed integer value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this long self)
        {
            return BitConverter.GetBytes(self);
        }

        /// <summary>
        /// Returns the specified double-precision floating point value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this double self)
        {
            return BitConverter.GetBytes(self);
        }

        /// <summary>
        /// Returns the specified single-precision floating point value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this float self)
        {
            return BitConverter.GetBytes(self);
        }

        /// <summary>
        /// Returns the specified 32-bit unsigned integer value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this uint self)
        {
            return BitConverter.GetBytes(self);
        }

        /// <summary>
        /// Returns the specified 16-bit unsigned integer value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this ushort self)
        {
            return BitConverter.GetBytes(self);
        }

        /// <summary>
        /// Returns the specified 64-bit unsigned integer value as an array of bytes.
        /// </summary>
        public static byte[] GetBytes(this ulong self)
        {
            return BitConverter.GetBytes(self);
        }

        /// <summary>
        /// Converts the provided string into a base 64 encoded format with the default <see cref="Base64FormattingOptions"/>.
        /// </summary>
        public static string ToBase64String(this byte[] self)
        {
            return Convert.ToBase64String(self);
        }
        /// <summary>
        /// Converts the provided string into a base 64 encoded format with the specified <see cref="Base64FormattingOptions"/>.
        /// </summary>
        public static string ToBase64String(this byte[] self, Base64FormattingOptions formattingOptions)
        {
            return Convert.ToBase64String(self, formattingOptions);
        }
    }
}