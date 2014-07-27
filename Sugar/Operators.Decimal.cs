public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Decimal"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Decimal
    {
        #region Arithmatic Operators

        /// <summary>
        /// Exposes the numeric Add operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, decimal> Add = (left, right) => left + right;

        /// <summary>
        /// Exposes the numeric Subtract operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, decimal> Subtract = (left, right) => left - right;

        /// <summary>
        /// Exposes the numeric Multiply operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, decimal> Multiply = (left, right) => left * right;

        /// <summary>
        /// Exposes the numeric Divide operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, decimal> Divide = (left, right) => left / right;

        /// <summary>
        /// Exposes the numeric Modulo operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, decimal> Modulo = (left, right) => left % right;

        /// <summary>
        /// Exposes the numeric Negate operator of Decimal as a delegate
        /// </summary>
        public static readonly Unary<decimal, decimal> Negate = target => -target;

        /// <summary>
        /// Exposes the numeric Increment operator of Decimal as a delegate
        /// </summary>
        public static readonly Unary<decimal, decimal> Increment = target => target + 1;

        /// <summary>
        /// Exposes the numeric Decrement operator of Decimal as a delegate
        /// </summary>
        public static readonly Unary<decimal, decimal> Decrement = target => target - 1;

        #endregion Arithmatic Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> GreaterThan = (left, right) => left > right;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> GreaterThanOrEqual = (left, right) => left >= right;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> LessThan = (left, right) => left < right;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> LessThanOrEqual = (left, right) => left <= right;

        #endregion Comparison Operators

        #region Equality Operators

        /// <summary>
        /// Exposes the Comparison Equality operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> Equality = (left, right) => left == right;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> Inequality = (left, right) => left != right;

        #endregion Equality Operators
    }
}