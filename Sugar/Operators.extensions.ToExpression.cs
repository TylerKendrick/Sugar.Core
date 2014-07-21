using System.Linq.Expressions;

namespace System
{
    public static partial class OperatorsExtensions
    {
        /// <summary>
        /// Converts a Nullary operation into an <see cref="Expression"/> without side-effects.
        /// </summary>
        public static Expression<Func<T>> ToExpression<T>(this Operators.Nullary<T> nullaryOperator)
        {
            return () => nullaryOperator();
        }
        /// <summary>
        /// Converts a Unary operation into an <see cref="Expression"/> without side-effects.
        /// </summary>
        public static Expression<Func<TIn, TOut>> ToExpression<TIn, TOut>(this Operators.Unary<TIn, TOut> unaryOperator)
        {
            return x => unaryOperator(x);
        }

        /// <summary>
        /// Converts a Binary operation into an <see cref="Expression"/> without side-effects.
        /// </summary>
        public static Expression<Func<TLeft, TRight, TResult>> ToExpression<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator)
        {
            return (left, right) => binaryOperator(left, right);
        }
    }
}