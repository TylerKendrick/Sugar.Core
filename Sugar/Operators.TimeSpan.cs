public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="TimeSpan"/> 
    /// data-type as delegates for use as first-class objects.
    /// </summary>
    public static class TimeSpan
    {
        #region Arithmetic Operators

        /// <summary>
        /// Exposes the Add operator of TimeSpan as a delegate
        /// </summary>
        public static readonly Binary<System.TimeSpan, System.TimeSpan, System.TimeSpan> Add = (left, right) => left + right;

        /// <summary>
        /// Exposes the Subtract operator of TimeSpan as a delegate
        /// </summary>
        public static readonly Binary<System.TimeSpan, System.TimeSpan, System.TimeSpan> Subtract = (left, right) => left - right;

        /// <summary>
        /// Exposes the Negate operator of TimeSpan as a delegate
        /// </summary>
        public static readonly Unary<System.TimeSpan, System.TimeSpan> Negate = target => -target;

        #endregion Arithmetic Operators

        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of TimeSpan as a delegate
        /// </summary>
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> GreaterThan = (left, right) => left > right;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of TimeSpan as a delegate
        /// </summary>
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> GreaterThanOrEqual = (left, right) => left >= right;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of TimeSpan as a delegate
        /// </summary>
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> LessThan = (left, right) => left < right;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of TimeSpan as a delegate
        /// </summary>
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> LessThanOrEqual = (left, right) => left <= right;

        #endregion Comparison Operators

        #region Equality Operators

        /// <summary>
        /// Exposes the Comparison Equality operator of TimeSpan as a delegate
        /// </summary>
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> Equality = (left, right) => left == right;

        /// <summary>
        /// Exposes the Comparison Inequality operator of TimeSpan as a delegate
        /// </summary>
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> Inequality = (left, right) => left != right;

        #endregion Equality Operators
    }
}