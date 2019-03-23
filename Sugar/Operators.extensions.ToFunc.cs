namespace System
{
    /// <summary>
    /// Provides conversion operations on the specified operator types.
    /// </summary>
    public static partial class OperatorsExtensions
    {
        /// <summary>
        /// Converts a <see cref="Operators.Nullary{T}"/> operation into a <see cref="Func{T}"/> without side-effects.
        /// </summary>
        public static Func<T> ToFunc<T>(this Operators.Nullary<T> nullaryOperator)
            => () => nullaryOperator();

        /// <summary>
        /// Converts a Unary operation into a <see cref="Func{T}"/> without side-effects.
        /// </summary>
        public static Func<TIn, TOut> ToFunc<TIn, TOut>(this Operators.Unary<TIn, TOut> unaryOperator)
            => x => unaryOperator(x);

        /// <summary>
        /// Converts a Binary operation into a <see cref="Func{T}"/> without side-effects.
        /// </summary>
        public static Func<TLeft, TRight, TResult> ToFunc<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator)
            => (left, right) => binaryOperator(left, right);
    }
}