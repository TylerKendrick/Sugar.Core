public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Decimal"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Decimal
    {
        #region Numeric Operators

        /// <summary>
        /// Exposes the numeric Add operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, decimal> Add = Operations.Decimal.OnAdd;

        /// <summary>
        /// Exposes the numeric Subtract operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, decimal> Subtract = Operations.Decimal.OnSubtract;

        /// <summary>
        /// Exposes the numeric Multiply operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, decimal> Multiply = Operations.Decimal.OnMultiply;

        /// <summary>
        /// Exposes the numeric Divide operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, decimal> Divide = Operations.Decimal.OnDivide;

        /// <summary>
        /// Exposes the numeric Modulo operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, decimal> Modulo = Operations.Decimal.OnModulo;

        /// <summary>
        /// Exposes the numeric Negate operator of Decimal as a delegate
        /// </summary>
        public static readonly Unary<decimal, decimal> Negate = Operations.Decimal.OnNegate;

        /// <summary>
        /// Exposes the numeric Increment operator of Decimal as a delegate
        /// </summary>
        public static readonly Unary<decimal, decimal> Increment = Operations.Decimal.OnIncrement;

        /// <summary>
        /// Exposes the numeric Decrement operator of Decimal as a delegate
        /// </summary>
        public static readonly Unary<decimal, decimal> Decrement = Operations.Decimal.OnDecrement;

        #endregion Numeric Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> GreaterThan = Operations.Decimal.OnGreaterThan;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> GreaterThanOrEqual = Operations.Decimal.OnGreaterThanOrEqual;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> LessThan = Operations.Decimal.OnLessThan;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> LessThanOrEqual = Operations.Decimal.OnLessThanOrEqual;

        /// <summary>
        /// Exposes the Comparison Equality operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> Equality = Operations.Decimal.OnEquality;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Decimal as a delegate
        /// </summary>
        public static readonly Binary<decimal, decimal, bool> Inequality = Operations.Decimal.OnInequality;

        #endregion Comparison Operators
    }
}