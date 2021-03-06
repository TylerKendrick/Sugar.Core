﻿namespace System.Security
{
    using Collections.Generic;
    using Cryptography;
    using Text;

    /// <summary>
    /// Provides simplified invocations for boilerplate construction of common crypto operations with strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Simplifies application of a hash algorithm with a string.
        /// </summary>
        /// <param name="self">The string targetted for hashing</param>
        /// <param name="hashAlgorithm">The provided algorithm.</param>
        /// <param name="encoding">Defaults to Encoding.Default is left null.</param>
        /// <returns>Returns the result of the hash algorithm applied to the string.</returns>
        public static string Encrypt(this string self, HashAlgorithm hashAlgorithm, Encoding encoding = null)
        {
            var bytes = self.GetBytes(encoding);
            return hashAlgorithm.ComputeHash(bytes)
                .ToHex()
                .ToLower();
        }

        /// <summary>
        /// Simplifies application of a hash algorithm with a string.
        /// </summary>
        /// <param name="self">The string targetted for hashing</param>
        /// <param name="cryptoType">The provided algorithm.  Defaults to HasAlgorithmTypes.SHA256</param>
        /// <returns>Returns the result of the hash algorithm applied to the string.</returns>
        public static string Encrypt(this string self, HashAlgorithmTypes cryptoType = HashAlgorithmTypes.SHA256)
        {
            var crypto = cryptoType.Create();
            return Encrypt(self, crypto);
        }

        /// <summary>
        /// Simplifies application of a symmetric algorithm with a string.
        /// </summary>
        public static string Encrypt(this string self, SymmetricAlgorithmTypes cryptoType, 
            string password, string iv, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var crypto = cryptoType.Create(password.GetBytes(encoding), iv.GetBytes(encoding));
            return Encrypt(self, crypto, encoding);
        }

        /// <summary>
        /// Simplifies application of a symmetric algorithm with a string.
        /// </summary>
        public static string Encrypt(this string self, SymmetricAlgorithm symmetricAlgorithm, 
            Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var input = self.GetBytes(encoding);
            var output = input.Encrypt(symmetricAlgorithm);
            return Convert.ToBase64String(output);
        }

        /// <summary>
        /// Simplifies application of a symmetric algorithm with a string.
        /// </summary>
        public static string Decrypt(this string self, SymmetricAlgorithmTypes cryptoType,
            string password, string iv, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var crypto = cryptoType.Create(password.GetBytes(encoding), iv.GetBytes(encoding));
            return Decrypt(self, crypto, encoding);
        }

        /// <summary>
        /// Simplifies application of a symmetric algorithm with a string.
        /// </summary>
        public static string Decrypt(string self, SymmetricAlgorithm symmetricAlgorithm, 
            Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var input = Convert.FromBase64String(self);
            var output = input.Decrypt(symmetricAlgorithm);
            return encoding.GetString(output);
        }

        /// <summary>
        /// Copies the value of a <see cref="string"/> into a <see cref="SecureString"/>.
        /// </summary>
        /// <param name="self">The target string to copy.</param>
        /// <returns>A new instance of a <see cref="SecureString"/>.</returns>
        public static SecureString Secure(this string self)
        {
            var result = new SecureString();
            self.ForEach(result.AppendChar);
            return result;
        }
    }
}