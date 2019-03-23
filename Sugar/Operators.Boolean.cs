public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Boolean"/> 
    /// data-type as delegates for use as first-class objects.
    /// </summary>
    public static class Boolean
    {
        #region Logical Operators

        /// <summary>
        /// Exposes the Logical AND operator of Boolean as a delegate
        /// </summary>
        public static readonly Binary<bool, bool, bool> And = (left, right) => left && right;

        /// <summary>
        /// Exposes the Logical OR operator of Boolean as a delegate
        /// </summary>
        public static readonly Binary<bool, bool, bool> Or = (left, right) => left || right;

        /// <summary>
        /// Exposes the Logical Negation operator of Boolean as a delegate
        /// </summary>
        public static readonly Unary<bool, bool> Not = target => !target;

        #endregion Logical Operators

        #region Equality Operators

        /// <summary>
        /// Exposes the Comparison Equality operator of Boolean as a delegate
        /// </summary>
        public static readonly Binary<bool, bool, bool> Equality = (left, right) => left == right;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Boolean as a delegate
        /// </summary>
        public static readonly Binary<bool, bool, bool> Inequality = (left, right) => left != right;

        #endregion Equality Operators
    }
}