using System;
using System.ComponentModel;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using Sugar.Linq;

namespace Sugar.Security
{
    /// <summary>
    /// Provides simplified invocations for boilerplate construction of common crypto operations with strings.
    /// </summary>
    public static class StringExtensions
    {
        private static SymmetricAlgorithm GetSymmetricAlgorithmType(SymmetricAlgorithmTypes cryptoType)
        {
            SymmetricAlgorithm provider;
            switch (cryptoType)
            {
                case SymmetricAlgorithmTypes.Aes:
                    provider = new AesCryptoServiceProvider();
                    break;
                case SymmetricAlgorithmTypes.DES:
                    provider = new DESCryptoServiceProvider();
                    break;
                case SymmetricAlgorithmTypes.RC2:
                    provider = new RC2CryptoServiceProvider();
                    break;
                case SymmetricAlgorithmTypes.TripleDES:
                    provider = new TripleDESCryptoServiceProvider();
                    break;
                default:
                    throw new InvalidEnumArgumentException("cryptoType", (int)cryptoType, typeof(SymmetricAlgorithmTypes));
            }
            return provider;
        }
        private static HashAlgorithm GetHashAlgorithmType(HashAlgorithmTypes cryptoType)
        {
            HashAlgorithm result;
            switch (cryptoType)
            {
                case HashAlgorithmTypes.MD5:
                    result = new MD5CryptoServiceProvider();
                    break;
                case HashAlgorithmTypes.SHA1:
                    result = new SHA1CryptoServiceProvider();
                    break;
                case HashAlgorithmTypes.SHA256:
                    result = new SHA256CryptoServiceProvider();
                    break;
                case HashAlgorithmTypes.SHA384:
                    result = new SHA384CryptoServiceProvider();
                    break;
                case HashAlgorithmTypes.SHA512:
                    result = new SHA512CryptoServiceProvider();
                    break;
                default:
                    throw new InvalidEnumArgumentException("cryptoType", (int)cryptoType, typeof(HashAlgorithmTypes));
            }

            return result;
        }

        /// <summary>
        /// Simplifies application of a hash algorithm with a string.
        /// </summary>
        /// <param name="self">The string targetted for hashing</param>
        /// <param name="hashAlgorithm">The provided algorithm.</param>
        /// <param name="encoding">Defaults to Encoding.Default is left null.</param>
        /// <returns>Returns the result of the hash algorithm applied to the string.</returns>
        public static string Encrypt(this string self, HashAlgorithm hashAlgorithm, Encoding encoding = null)
        {
            var bytes = self.ToBytes(encoding);
            return hashAlgorithm.ComputeHash(bytes)
                .ToString(0)
                .Replace("-", "")
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
            var crypto = GetHashAlgorithmType(cryptoType);
            return Encrypt(self, crypto);
        }

        public static string Encrypt(this string self, SymmetricAlgorithmTypes cryptoType, 
            string password, string iv, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var crypto = GetSymmetricAlgorithmType(cryptoType);
            crypto.Key = password.ToBytes(encoding);
            crypto.IV = iv.ToBytes(encoding);
            return Encrypt(self, crypto, encoding);
        }

        public static string Encrypt(this string self, SymmetricAlgorithm hashAlgorithm, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var encryptor = hashAlgorithm.CreateEncryptor();
            var input = self.ToBytes(encoding);
            var output = encryptor.TransformFinalBlock(input, 0, input.Length);
            return Convert.ToBase64String(output);
        }

        public static string Decrypt(this string self, SymmetricAlgorithmTypes cryptoType,
            string password, string iv, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var crypto = GetSymmetricAlgorithmType(cryptoType);
            crypto.Key = password.ToBytes(encoding);
            crypto.IV = iv.ToBytes(encoding);
            return Decrypt(self, crypto, encoding);
        }

        public static string Decrypt(string self, SymmetricAlgorithm symmetricAlgorithm, 
            Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var decryptor = symmetricAlgorithm.CreateDecryptor();
            var input = Convert.FromBase64String(self);
            var output = decryptor.TransformFinalBlock(input, 0, input.Length);
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