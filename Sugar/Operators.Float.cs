public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Float"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Float
    {
        #region Arithmatic Operators

        /// <summary>
        /// Exposes the numeric Add operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, float> Add = (left, right) => left + right;

        /// <summary>
        /// Exposes the numeric Subtract operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, float> Subtract = (left, right) => left - right;

        /// <summary>
        /// Exposes the numeric Multiply operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, float> Multiply = (left, right) => left * right;

        /// <summary>
        /// Exposes the numeric Divide operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, float> Divide = (left, right) => left / right;

        /// <summary>
        /// Exposes the numeric Modulo operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, float> Modulo = (left, right) => left % right;

        /// <summary>
        /// Exposes the numeric Negate operator of Float as a delegate
        /// </summary>
        public static readonly Unary<float, float> Negate = target => -target;

        /// <summary>
        /// Exposes the numeric Increment operator of Float as a delegate
        /// </summary>
        public static readonly Unary<float, float> Increment = target => target + 1;

        /// <summary>
        /// Exposes the numeric Decrement operator of Float as a delegate
        /// </summary>
        public static readonly Unary<float, float> Decrement = target => target - 1;

        #endregion Arithmatic Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, bool> GreaterThan = (left, right) => left > right;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, bool> GreaterThanOrEqual = (left, right) => left >= right;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, bool> LessThan = (left, right) => left < right;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, bool> LessThanOrEqual = (left, right) => left <= right;

        #endregion Comparison Operators

        #region Equality Operators

        /// <summary>
        /// Exposes the Comparison Equality operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, bool> Equality = (left, right) => System.Math.Abs(left - right) < float.Epsilon;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Float as a delegate
        /// </summary>
        public static readonly Binary<float, float, bool> Inequality = (left, right) => System.Math.Abs(left - right) > float.Epsilon;

        #endregion Equality Operators
    }
}