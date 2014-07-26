public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Int32"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Int32
    {
        #region Bitwise Operators
        
        /// <summary>
        /// Exposes the left shift operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> ShiftLeft = Operations.Int32.ShiftLeftOperation;

        /// <summary>
        /// Exposes the right shift operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> ShiftRight = Operations.Int32.ShiftRightOperation;

        /// <summary>
        /// Exposes the bitwise AND operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> And = Operations.Int32.AndOperation;

        /// <summary>
        /// Exposes the bitwise Inclusive-OR operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Or = Operations.Int32.OrOperation;

        /// <summary>
        /// Exposes the bitwise Exclusive-Or operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> XOr = Operations.Int32.XOrOperation;

        /// <summary>
        /// Exposes the bitwise NOT operator of Int32 as a delegate
        /// </summary>
        public static readonly Unary<int, int> Not = Operations.Int32.NotOperation;

        #endregion Bitwise Operators

        #region Numeric Operators

        /// <summary>
        /// Exposes the numeric Add operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Add = Operations.Int32.AddOperation;

        /// <summary>
        /// Exposes the numeric Subtract operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Subtract = Operations.Int32.SubtractOperation;

        /// <summary>
        /// Exposes the numeric Multiply operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Multiply = Operations.Int32.MultiplyOperation;
        
        /// <summary>
        /// Exposes the numeric Divide operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Divide = Operations.Int32.DivideOperation;
        
        /// <summary>
        /// Exposes the numeric Modulo operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Modulo = Operations.Int32.ModuloOperation;

        /// <summary>
        /// Exposes the numeric Negatation operator of Int32 as a delegate
        /// </summary>
        public static readonly Unary<int, int> Negate = Operations.Int32.NegateOperation;

        /// <summary>
        /// Exposes the numeric Increment operator of Int32 as a delegate
        /// </summary>
        public static readonly Unary<int, int> Increment = Operations.Int32.IncrementOperation;
        
        /// <summary>
        /// Exposes the numeric Decrement operator of Int32 as a delegate
        /// </summary>
        public static readonly Unary<int, int> Decrement = Operations.Int32.DecrementOperation;
        
        #endregion Numeric Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> GreaterThan = Operations.Int32.GreaterThanOperation;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> GreaterThanOrEqual = Operations.Int32.GreaterThanOrEqualOperation;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> LessThan = Operations.Int32.LessThanOperation;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> LessThanOrEqual = Operations.Int32.LessThanOrEqualToOperation;
        
        /// <summary>
        /// Exposes the Equality operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> Equality = Operations.Int32.EqualityOperation;
        
        /// <summary>
        /// Exposes the Inequality operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> Inequality = Operations.Int32.InequalityOperation;

        #endregion Comparison Operators        
    }
}