using System.Security.Cryptography;

namespace Sugar.Security
{
    public static class ByteArrayExtensions
    {
        public static byte[] Encrypt(this byte[] self, SymmetricAlgorithmTypes cryptoTypes,
            byte[] key, byte[] iv)
        {
            var crypto = cryptoTypes.Create(key, iv);
            return Encrypt(self, crypto);
        }

        public static byte[] Encrypt(this byte[] self, SymmetricAlgorithm symmetricAlgorithm)
        {
            var encryptor = symmetricAlgorithm.CreateEncryptor();
            return encryptor.TransformFinalBlock(self, 0, self.Length);
        }

        public static byte[] Decrypt(this byte[] self, SymmetricAlgorithmTypes cryptoTypes,
            byte[] key, byte[] iv)
        {
            var crypto = cryptoTypes.Create(key, iv);
            var decryptor = crypto.CreateDecryptor();
            return decryptor.TransformFinalBlock(self, 0, self.Length);
        }

        public static byte[] Decrypt(this byte[] self, SymmetricAlgorithm symmetricAlgorithm)
        {
            var decryptor = symmetricAlgorithm.CreateDecryptor();
            return decryptor.TransformFinalBlock(self, 0, self.Length);
        }
    }
}
