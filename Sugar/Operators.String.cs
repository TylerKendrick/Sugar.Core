public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="String"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class String
    {
        #region Arithmatic Operators

        /// <summary>
        /// Exposes the Concatenation operator for <see cref="String"/> instances as a delegate.
        /// </summary>
        public static readonly Binary<string, string, string> Add = (left, right) => left + right;

        #endregion Arithmatic Operators

        #region Equality Operators

        /// <summary>
        /// Exposes the Comparison Equality operator of String as a delegate
        /// </summary>
        public static readonly Binary<string, string, bool> Equality = (left, right) => left == right;

        /// <summary>
        /// Exposes the Comparison Inequality operator of String as a delegate
        /// </summary>
        public static readonly Binary<string, string, bool> Inequality = (left, right) => left != right;

        #endregion Equality Operators
    }
}