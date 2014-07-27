public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Delegate"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Delegate
    {
        #region Equality Operators

        /// <summary>
        /// Exposes the Comparison Equality operator of Delegate as a delegate
        /// </summary>
        public static readonly Binary<System.Delegate, System.Delegate, bool> Equality = (left, right) => left == right;

        /// <summary>
        /// Exposes the Comparison Inequality operator of Delegate as a delegate
        /// </summary>
        public static readonly Binary<System.Delegate, System.Delegate, bool> Inequality = (left, right) => left != right;
        
        #endregion Equality Operators

        #region Functional Operators
        
        /// <summary>
        /// Exposes the Functional Combine operator of Delegate as a delegate
        /// </summary>
        public static readonly Binary<System.Delegate, System.Delegate, System.Delegate> Combine =
            (left, right) => System.Delegate.Combine(left, right);

        #endregion Functional Operators
    }
}