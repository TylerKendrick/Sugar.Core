public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Int32"/> 
    /// data-type as delegates for use as first-class objects.
    /// </summary>
    public static class Int32
    {
        #region Bitwise Operators

        /// <summary>
        /// Exposes the left shift operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> ShiftLeft = (left, right) => left << right;

        /// <summary>
        /// Exposes the right shift operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> ShiftRight = (left, right) => left >> right;

        /// <summary>
        /// Exposes the bitwise AND operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> And = (left, right) => left & right;

        /// <summary>
        /// Exposes the bitwise Inclusive-OR operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Or = (left, right) => left | right;

        /// <summary>
        /// Exposes the bitwise Exclusive-Or operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> XOr = (left, right) => left ^ right;

        /// <summary>
        /// Exposes the bitwise NOT operator of Int32 as a delegate
        /// </summary>
        public static readonly Unary<int, int> Not = target => ~target;

        #endregion Bitwise Operators

        #region Arithmetic Operators

        /// <summary>
        /// Exposes the numeric Add operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Add = (left, right) => left + right;

        /// <summary>
        /// Exposes the numeric Subtract operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Subtract = (left, right) => left - right;

        /// <summary>
        /// Exposes the numeric Multiply operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Multiply = (left, right) => left * right;

        /// <summary>
        /// Exposes the numeric Divide operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Divide = (left, right) => left / right;

        /// <summary>
        /// Exposes the numeric Modulo operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, int> Modulo = (left, right) => left % right;

        /// <summary>
        /// Exposes the numeric Negation operator of Int32 as a delegate
        /// </summary>
        public static readonly Unary<int, int> Negate = target => -target;

        /// <summary>
        /// Exposes the numeric Increment operator of Int32 as a delegate
        /// </summary>
        public static readonly Unary<int, int> Increment = target => target + 1;

        /// <summary>
        /// Exposes the numeric Decrement operator of Int32 as a delegate
        /// </summary>
        public static readonly Unary<int, int> Decrement = target => target - 1;

        #endregion Arithmetic Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> GreaterThan = (left, right) => left > right;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> GreaterThanOrEqual = (left, right) => left >= right;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> LessThan = (left, right) => left < right;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> LessThanOrEqual = (left, right) => left <= right;

        #endregion Comparison Operators

        #region Equality Operators

        /// <summary>
        /// Exposes the Equality operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> Equality = (left, right) => left == right;

        /// <summary>
        /// Exposes the Inequality operator of Int32 as a delegate
        /// </summary>
        public static readonly Binary<int, int, bool> Inequality = (left, right) => left != right;

        #endregion Equality Operators
    }
}