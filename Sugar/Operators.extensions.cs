using System.Linq.Expressions;

namespace System
{
    public static class OperatorsExtensions
    {
        public static Func<TLeft, TRight, TResult> ToFunc<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator)
        {
            return (left, right) => binaryOperator(left, right);
        }

        public static Expression<Func<TLeft, TRight, TResult>> ToExpression<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator)
        {
            return (left, right) => binaryOperator(left, right);
        }

        public static Func<TRight, TResult> Apply<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator, TLeft left)
        {
            return right => binaryOperator(left, right);
        }

        public static Func<TLeft, TResult> Apply<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator, TRight right)
        {
            return left => binaryOperator(left, right);
        }

        public static Func<TLeft, Func<TRight, TResult>> Curry<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator)
        {
            return left => right => binaryOperator(left, right);
        }
    }
}