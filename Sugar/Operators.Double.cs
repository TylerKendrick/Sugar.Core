public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Double"/> 
    /// data-type as delegates for use as first-class objects.
    /// </summary>
    public static class Double
    {
        #region Arithmetic Operators

        /// <summary>
        /// Exposes the numeric Add operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, double> Add = (left, right) => left + right;

        /// <summary>
        /// Exposes the numeric Subtract operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, double> Subtract = (left, right) => left - right;

        /// <summary>
        /// Exposes the numeric Multiply operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, double> Multiply = (left, right) => left * right;

        /// <summary>
        /// Exposes the numeric Divide operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, double> Divide = (left, right) => left / right;

        /// <summary>
        /// Exposes the numeric Modulo operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, double> Modulo = (left, right) => left % right;

        /// <summary>
        /// Exposes the numeric Negate operator of Double as a delegate
        /// </summary>
        public static readonly Unary<double, double> Negate = target => -target;

        /// <summary>
        /// Exposes the numeric Increment operator of Double as a delegate
        /// </summary>
        public static readonly Unary<double, double> Increment = target => target + 1;

        /// <summary>
        /// Exposes the numeric Decrement operator of Double as a delegate
        /// </summary>
        public static readonly Unary<double, double> Decrement = target => target - 1;

        #endregion Arithmetic Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> GreaterThan = (left, right) => left > right;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> GreaterThanOrEqual = (left, right) => left >= right;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> LessThan = (left, right) => left < right;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> LessThanOrEqual = (left, right) => left <= right;

        #endregion

        #region Equality Operators

        /// <summary>
        /// Exposes the Comparison Equality operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> Equality = (left, right) => System.Math.Abs(left - right) < double.Epsilon;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Double as a delegate
        /// </summary>
        public static readonly Binary<double, double, bool> Inequality = (left, right) => System.Math.Abs(left - right) > double.Epsilon;

        #endregion Equality Operators
    }
}