namespace System.Security
{
    using Cryptography;

    /// <summary>
    /// Provides supported operations for encryption through the .NET framework as instance extension methods.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Creates a new instance of a <see cref="SymmetricAlgorithm"/> 
        /// to apply to the specified target as an extension method.
        /// </summary>
        public static byte[] Encrypt(this byte[] self, SymmetricAlgorithmTypes cryptoTypes,
            byte[] key, byte[] iv)
        {
            var crypto = cryptoTypes.Create(key, iv);
            return Encrypt(self, crypto);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="SymmetricAlgorithm"/> 
        /// to apply to the specified target as an extension method.
        /// </summary>
        public static byte[] Encrypt(this byte[] self, SymmetricAlgorithm symmetricAlgorithm)
        {
            var encryptor = symmetricAlgorithm.CreateEncryptor();
            return encryptor.TransformFinalBlock(self, 0, self.Length);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="SymmetricAlgorithm"/> 
        /// to apply to the specified target as an extension method.
        /// </summary>
        public static byte[] Decrypt(this byte[] self, SymmetricAlgorithmTypes cryptoTypes,
            byte[] key, byte[] iv)
        {
            var crypto = cryptoTypes.Create(key, iv);
            var decryptor = crypto.CreateDecryptor();
            return decryptor.TransformFinalBlock(self, 0, self.Length);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="SymmetricAlgorithm"/> 
        /// to apply to the specified target as an extension method.
        /// </summary>
        public static byte[] Decrypt(this byte[] self, SymmetricAlgorithm symmetricAlgorithm)
        {
            var decryptor = symmetricAlgorithm.CreateDecryptor();
            return decryptor.TransformFinalBlock(self, 0, self.Length);
        }
    }
}
