// ReSharper disable InconsistentNaming
namespace System.Security
{
    /// <summary>
    /// An enumeration detailing the default supported hash algorithms provided by .NET
    /// </summary>
    public enum HashAlgorithmTypes
    {
        /// <summary>
        /// Used to Generate a new instance of an SHA1 <see cref="System.Security.Cryptography.HashAlgorithm"/>
        /// </summary>
        MD5,

        /// <summary>
        /// Used to Generate a new instance of an MD5 <see cref="System.Security.Cryptography.HashAlgorithm"/>
        /// </summary>
        SHA1,

        /// <summary>
        /// Used to Generate a new instance of an SHA256 <see cref="System.Security.Cryptography.HashAlgorithm"/>
        /// </summary>
        SHA256,

        /// <summary>
        /// Used to Generate a new instance of an SHA384 <see cref="System.Security.Cryptography.HashAlgorithm"/>
        /// </summary>
        SHA384,

        /// <summary>
        /// Used to Generate a new instance of an SHA512 <see cref="System.Security.Cryptography.HashAlgorithm"/>
        /// </summary>
        SHA512,
    }
}
// ReSharper restore InconsistentNaming
