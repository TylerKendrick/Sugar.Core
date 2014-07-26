public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Long"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Long
    {
        #region Bitwise Operators

        /// <summary>
        /// Exposes the left shift operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, int, long> ShiftRight = Operations.Long.OnShiftRight;

        /// <summary>
        /// Exposes the right shift operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, int, long> ShiftLeft = Operations.Long.ShiftLeftOperation;

        /// <summary>
        /// Exposes the bitwise And operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> And = Operations.Long.OnAnd;

        /// <summary>
        /// Exposes the bitwise Or operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Or = Operations.Long.OnOr;

        /// <summary>
        /// Exposes the bitwise XOr operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> XOr = Operations.Long.OnXOr;

        /// <summary>
        /// Exposes the bitwise Not operator of Long as a delegate
        /// </summary>
        public static readonly Unary<long, long> Not = Operations.Long.OnNot;

        #endregion Bitwise Operators

        #region Numeric Operators

        /// <summary>
        /// Exposes the numeric Add operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Add = Operations.Long.OnAdd;

        /// <summary>
        /// Exposes the numeric Subtract operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Subtract = Operations.Long.OnSubtract;

        /// <summary>
        /// Exposes the numeric Multiply operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Multiply = Operations.Long.OnMultiply;

        /// <summary>
        /// Exposes the numeric Divide operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Divide = Operations.Long.OnDivide;

        /// <summary>
        /// Exposes the numeric Modulo operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Modulo = Operations.Long.OnModulo;

        /// <summary>
        /// Exposes the numeric Negate operator of Long as a delegate
        /// </summary>
        public static readonly Unary<long, long> Negate = Operations.Long.OnNegate;

        /// <summary>
        /// Exposes the numeric Increment operator of Long as a delegate
        /// </summary>
        public static readonly Unary<long, long> Increment = Operations.Long.OnIncrement;

        /// <summary>
        /// Exposes the numeric Decrement operator of Long as a delegate
        /// </summary>
        public static readonly Unary<long, long> Decrement = Operations.Long.OnDecrement;

        #endregion Numeric Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> GreaterThan = Operations.Long.OnGreaterThan;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> GreaterThanOrEqual = Operations.Long.OnGreaterThanOrEqual;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> LessThan = Operations.Long.OnLessThan;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> LessThanOrEqual = Operations.Long.OnLessThanOrEqual;

        /// <summary>
        /// Exposes the Comparison Equality operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> Equality = Operations.Long.OnEquality;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> Inequality = Operations.Long.OnInequality;

        #endregion Comparison Operators
    }
}