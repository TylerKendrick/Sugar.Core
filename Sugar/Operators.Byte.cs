public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Byte"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Byte
    {
        #region Bitwise Operators

        /// <summary>
        /// Exposes the left shift operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, int, int> ShiftLeft = (left, right) => left << right;

        /// <summary>
        /// Exposes the left shift operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, int, int> ShiftRight = (left, right) => left >> right;

        /// <summary>
        /// Exposes the bitwise and operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, int> And = (left, right) => left & right;

        /// <summary>
        /// Exposes the bitwise inclusive-or operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, int> Or = (left, right) => left | right;

        /// <summary>
        /// Exposes the bitwise exclusive-or operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, int> XOr = (left, right) => left ^ right;

        /// <summary>
        /// Exposes the bitwise Not operator of Byte as a delegate
        /// </summary>
        public static readonly Unary<byte, int> Not = target => ~target;

        #endregion Bitwise Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> GreaterThan = (left, right) => left > right;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> GreaterThanOrEqual = (left, right) => left >= right;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> LessThan = (left, right) => left < right;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> LessThanOrEqual = (left, right) => left <= right;

        #endregion Comparison Operators

        #region Equality Operators
        
        /// <summary>
        /// Exposes the Comparison Equality operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> Equality = (left, right) => left == right;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> Inequality = (left, right) => left != right;

        #endregion Equality Operators
    }
}