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
        public static readonly Binary<byte, int, int> ShiftLeft = Operations.Byte.OnShiftLeft;

        /// <summary>
        /// Exposes the left shift operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, int, int> ShiftRight = Operations.Byte.OnShiftRight;

        /// <summary>
        /// Exposes the bitwise and operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, int> And = Operations.Byte.OnAnd;

        /// <summary>
        /// Exposes the bitwise inclusive-or operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, int> Or = Operations.Byte.OnOr;

        /// <summary>
        /// Exposes the bitwise exclusive-or operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, int> XOr = Operations.Byte.OnXOr;

        /// <summary>
        /// Exposes the bitwise Not operator of Byte as a delegate
        /// </summary>
        public static readonly Unary<byte, int> Not = Operations.Byte.OnNot;

        #endregion Bitwise Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> GreaterThan = Operations.Byte.OnGreaterThan;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> GreaterThanOrEqual = Operations.Byte.OnGreaterThanOrEqual;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> LessThan = Operations.Byte.OnLessThan;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> LessThanOrEqual = Operations.Byte.OnLessThanOrEqual;

        /// <summary>
        /// Exposes the Comparison Equality operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> Equality = Operations.Byte.OnEquality;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Byte as a delegate
        /// </summary>
        public static readonly Binary<byte, byte, bool> Inequality = Operations.Byte.OnInequality;
        
        #endregion Comparison Operators
    }
}