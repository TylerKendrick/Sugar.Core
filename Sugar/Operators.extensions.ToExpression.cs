using System.Linq.Expressions;

namespace System
{
    public static partial class OperatorsExtensions
    {
        /// <summary>
        /// Converts a <see cref="Operators.Nullary{T}"/> operation into an <see cref="Expression"/> without side-effects.
        /// </summary>
        public static Expression<Func<T>> ToExpression<T>(this Operators.Nullary<T> nullaryOperator)
            => () => nullaryOperator();

        /// <summary>
        /// Converts a Unary operation into an <see cref="Expression"/> without side-effects.
        /// </summary>
        public static Expression<Func<TIn, TOut>> ToExpression<TIn, TOut>(this Operators.Unary<TIn, TOut> unaryOperator)
            => x => unaryOperator(x);

        /// <summary>
        /// Converts a Binary operation into an <see cref="Expression"/> without side-effects.
        /// </summary>
        public static Expression<Func<TLeft, TRight, TResult>> ToExpression<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator)
            => (left, right) => binaryOperator(left, right);
    }
}