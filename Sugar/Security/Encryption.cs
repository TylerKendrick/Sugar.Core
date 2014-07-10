using System.ComponentModel;
using System.Security.Cryptography;

namespace Sugar.Security
{
    public static class Encryption
    {
        public static SymmetricAlgorithm Create(this SymmetricAlgorithmTypes cryptoType, byte[] key, byte[] iv)
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
            provider.Key = key;
            provider.IV = iv;
            return provider;
        }

        public static HashAlgorithm Create(this HashAlgorithmTypes cryptoType)
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
    }
}