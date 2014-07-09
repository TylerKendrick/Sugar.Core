namespace Sugar.Security
{
    /// <summary>
    /// An enumeration detailing the default supported hash algorithms provided by .NET
    /// </summary>
    public enum HashAlgorithmTypes
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512,
    }

    public enum SymmetricAlgorithmTypes
    {
        Aes,
        DES,
        RC2,
        TripleDES
    }
}
