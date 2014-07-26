public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Double"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Double
    {
        #region Numeric Operators

        /// <summary>
        /// Exposes the numeric Add operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, double> Add = Operations.Double.OnAdd;

        /// <summary>
        /// Exposes the numeric Subtract operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, double> Subtract = Operations.Double.OnSubtract;

        /// <summary>
        /// Exposes the numeric Multiply operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, double> Multiply = Operations.Double.OnMultiply;

        /// <summary>
        /// Exposes the numeric Divide operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, double> Divide = Operations.Double.OnDivide;

        /// <summary>
        /// Exposes the numeric Modulo operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, double> Modulo = Operations.Double.OnModulo;

        /// <summary>
        /// Exposes the numeric Negate operator of Double as a delegate
        /// </summary>
        public static readonly Unary<double, double> Negate = Operations.Double.OnNegate;

        /// <summary>
        /// Exposes the numeric Increment operator of Double as a delegate
        /// </summary>
        public static readonly Unary<double, double> Increment = Operations.Double.OnIncrement;

        /// <summary>
        /// Exposes the numeric Decrement operator of Double as a delegate
        /// </summary>
        public static readonly Unary<double, double> Decrement = Operations.Double.OnDecrement;

        #endregion Numeric Operators
        
        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> GreaterThan = Operations.Double.OnGreaterThan;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> GreaterThanOrEqual = Operations.Double.OnGreaterThanOrEqual;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> LessThan = Operations.Double.OnLessThan;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> LessThanOrEqual = Operations.Double.OnLessThanOrEqual;

        /// <summary>
        /// Exposes the Comparison Equality operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> Equality = Operations.Double.OnEquality;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> Inequality = Operations.Double.OnInequality;
        
        #endregion
    }
}