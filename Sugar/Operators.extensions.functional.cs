
namespace System
{
    public static partial class OperatorsExtensions
    {
        /// <summary>
        /// Returns a parameterless function that applies the specified <paramref name="value"/> 
        /// to the specified <paramref name="unaryOperator"/>.
        /// </summary>
        public static Func<TOut> Apply<TIn, TOut>(this Operators.Unary<TIn, TOut> unaryOperator, TIn value)
        {
            return () => unaryOperator(value);
        }


        /// <summary>
        /// Returns a parameterless function that applies the specified <paramref name="left"/>
        /// and <paramref name="right"/> values to the specified <paramref name="binaryOperator"/>.
        /// </summary>
        public static Func<TResult> Apply<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator, TLeft left, TRight right)
        {
            return () => binaryOperator(left, right);
        }

        /// <summary>
        /// Returns a parameterless function that applies the specified <paramref name="left"/> 
        /// to the specified <paramref name="binaryOperator"/>.
        /// </summary>
        public static Func<TRight, TResult> ApplyLeft<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator, TLeft left)
        {
            return right => binaryOperator(left, right);
        }

        /// <summary>
        /// Returns a parameterless function that applies the specified <paramref name="right"/> 
        /// to the specified <paramref name="binaryOperator"/>.
        /// </summary>
        public static Func<TLeft, TResult> ApplyRight<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator, TRight right)
        {
            return left => binaryOperator(left, right);
        }

        /// <summary>
        /// Returns a curried function of the form g x y = x -> y -> f(x,y)
        /// from a specified delegate instance <paramref name="binaryOperator"/> 
        /// of type <see cref="Operators.Binary{TLeft, TRight, TResult}"/>.
        /// </summary>
        public static Func<TLeft, Func<TRight, TResult>> Curry<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator)
        {
            return left => right => binaryOperator(left, right);
        }
    }
}