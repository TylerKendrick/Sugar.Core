public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Long"/> 
    /// data-type as delegates for use as first-class objects.
    /// </summary>
    public static class Long
    {
        #region Bitwise Operators

        /// <summary>
        /// Exposes the left shift operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, int, long> ShiftRight = (left, right) => left >> right;

        /// <summary>
        /// Exposes the right shift operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, int, long> ShiftLeft = (left, right) => left << right;

        /// <summary>
        /// Exposes the bitwise And operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> And = (left, right) => left & right;

        /// <summary>
        /// Exposes the bitwise Or operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Or = (left, right) => left | right;

        /// <summary>
        /// Exposes the bitwise XOr operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> XOr = (left, right) => left ^ right;

        /// <summary>
        /// Exposes the bitwise Not operator of Long as a delegate
        /// </summary>
        public static readonly Unary<long, long> Not = target => ~target;

        #endregion Bitwise Operators

        #region Arithmetic Operators

        /// <summary>
        /// Exposes the numeric Add operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Add = (left, right) => left + right;

        /// <summary>
        /// Exposes the numeric Subtract operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Subtract = (left, right) => left - right;

        /// <summary>
        /// Exposes the numeric Multiply operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Multiply = (left, right) => left * right;

        /// <summary>
        /// Exposes the numeric Divide operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Divide = (left, right) => left / right;

        /// <summary>
        /// Exposes the numeric Modulo operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, long> Modulo = (left, right) => left % right;

        /// <summary>
        /// Exposes the numeric Negate operator of Long as a delegate
        /// </summary>
        public static readonly Unary<long, long> Negate = target => -target;

        /// <summary>
        /// Exposes the numeric Increment operator of Long as a delegate
        /// </summary>
        public static readonly Unary<long, long> Increment = target => target + 1;

        /// <summary>
        /// Exposes the numeric Decrement operator of Long as a delegate
        /// </summary>
        public static readonly Unary<long, long> Decrement = target => target - 1;

        #endregion Arithmetic Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> GreaterThan = (left, right) => left > right;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> GreaterThanOrEqual = (left, right) => left >= right;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> LessThan = (left, right) => left < right;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> LessThanOrEqual = (left, right) => left <= right;

        #endregion Comparison Operators

        #region Equality Operators

        /// <summary>
        /// Exposes the Comparison Equality operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> Equality = (left, right) => left == right;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Long as a delegate
        /// </summary>
        public static readonly Binary<long, long, bool> Inequality = (left, right) => left != right;

        #endregion Equality Operators
    }
}