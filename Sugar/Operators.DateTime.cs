public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="DateTime"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class DateTime
    {
        #region Arithmatic Operators

        /// <summary>
        /// Exposes the numeric Add operator of DateTime as a delegate
        /// </summary>
        public static readonly Binary<System.DateTime, System.TimeSpan, System.DateTime> Add = (left, right) => left + right;

        /// <summary>
        /// Exposes the numeric Subtract operator of DateTime as a delegate
        /// </summary>
        public static readonly Binary<System.DateTime, System.TimeSpan, System.DateTime> Subtract = (left, right) => left - right;
        
        #endregion Arithmatic Operators
        
        #region Comparison Operators

        /// <summary>
        /// Exposes the Comparison Greater-Than operator of DateTime as a delegate
        /// </summary>
        public static readonly Binary<System.DateTime, System.DateTime, bool> GreaterThan = (left, right) => left > right;

        /// <summary>
        /// Exposes the Comparison Greater-Than-Or-Equal operator of DateTime as a delegate
        /// </summary>
        public static readonly Binary<System.DateTime, System.DateTime, bool> GreaterThanOrEqual = (left, right) => left >= right;

        /// <summary>
        /// Exposes the Comparison Less-Than operator of DateTime as a delegate
        /// </summary>
        public static readonly Binary<System.DateTime, System.DateTime, bool> LessThan = (left, right) => left < right;

        /// <summary>
        /// Exposes the Comparison Less-Than-Or-Equal operator of DateTime as a delegate
        /// </summary>
        public static readonly Binary<System.DateTime, System.DateTime, bool> LessThanOrEqual = (left, right) => left <= right;
        
        #endregion Comparison Operators
        
        #region Equality Operators

        /// <summary>
        /// Exposes the Comparison Equality operator of DateTime as a delegate
        /// </summary>
        public static readonly Binary<System.DateTime, System.DateTime, bool> Equality = (left, right) => left == right;

        /// <summary>
        /// Exposes the Comparison Inequality operator of DateTime as a delegate
        /// </summary>
        public static readonly Binary<System.DateTime, System.DateTime, bool> Inequality = (left, right) => left != right;
        
        #endregion Equality Operators
    }
}