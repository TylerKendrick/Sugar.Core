
namespace System
{
    /// <summary>
    /// Provides conversion operations on the specified operator types.
    /// </summary>
    public static partial class OperatorsExtensions
    {
        /// <summary>
        /// Converts a <see cref="Func{TOut}"/> to an <see cref="Operators.Nullary{TOut}"/> of the same signature. 
        /// </summary>
        public static Operators.Nullary<TOut> ToNullary<TOut>(this Func<TOut> func)
        {
            return () => func();
        }

        /// <summary>
        /// Converts an <see cref="Operators.Unary{TIn, TOut}"/> to an <see cref="Operators.Nullary{TOut}"/>.
        /// Similar to calling <see cref="OperatorsExtensions.Apply{TIn, TOut}"/>. 
        /// </summary>
        public static Operators.Nullary<TOut> ToNullary<TIn, TOut>(this Operators.Unary<TIn, TOut> unaryOperator,
            TIn value)
        {
            return () => unaryOperator(value);
        }


        /// <summary>
        /// Converts an <see cref="Operators.Binary{TLeft, TRight, TResult}"/> to an <see cref="Operators.Nullary{TResult}"/>.
        /// Similar to calling <see cref="OperatorsExtensions.Apply{TLeft, TRight, TResult}"/>. 
        /// </summary>
        public static Operators.Nullary<TResult> ToNullary<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator, TLeft left, TRight right)
        {
            return () => binaryOperator(left, right);
        }


        /// <summary>
        /// Converts a <see cref="Func{TIn, TOut}"/> to an <see cref="Operators.Unary{TIn, TOut}"/> of the same signature. 
        /// </summary>
        public static Operators.Unary<TIn, TOut> ToUnary<TIn, TOut>(this Func<TIn, TOut> func)
        {
            return x => func(x);
        }

        /// <summary>
        /// Converts an <see cref="Operators.Binary{TLeft, TRight, TResult}"/> to an <see cref="Operators.Unary{TRight, TResult}"/>.
        /// Similar to calling <see cref="OperatorsExtensions.ApplyLeft{TLeft, TRight, TResult}"/>. 
        /// </summary>
        public static Operators.Unary<TRight, TResult> ToUnary<TLeft, TRight, TResult>(
            this Operators.Binary<TLeft, TRight, TResult> binaryOperator, TLeft left)
        {
            return right => binaryOperator(left, right);
        }


        /// <summary>
        /// Converts a <see cref="Func{TLeft, TRight, TResult}"/> to an <see cref="Operators.Binary{TLeft, TRight, TResult}"/> of the same signature. 
        /// </summary>
        public static Operators.Binary<TLeft, TRight, TResult> ToBinary<TLeft, TRight, TResult>(
            this Func<TLeft, TRight, TResult> func)
        {
            return (left, right) => func(left, right);
        }
    }
}