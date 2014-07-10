using System.Collections.Generic;

namespace Sugar
{
    /// <summary>
    /// Provides fluent conditional expressions for enumerable types.
    /// </summary>
    /// <typeparam name="TItem">The type of item in the wrapped collection.</typeparam>
    /// <typeparam name="TCollection">The type of collection being wrapped for fluent evaluation.</typeparam>
    public class EnumerableConditionalExpression<TItem, TCollection> : ConditionalExpression<TCollection>
        where TCollection : IEnumerable<TItem>
    {
        /// <summary>
        /// Wraps a specified collection with an optional offset for evaluation.
        /// </summary>
        /// <param name="handle">The target collection wrapped for evaluation.</param>
        /// <param name="offset">The specified offset for evaluation.</param>
        internal EnumerableConditionalExpression(TCollection handle, bool? offset = null) 
            : base(handle, offset)
        {
        }
    }

    /// <summary>
    /// Provides fluent conditional expressions for enumerable types.
    /// </summary>
    /// <typeparam name="T">The type of item in the wrapped collection.</typeparam>
    public class EnumerableConditionalExpression<T> : ConditionalExpression<IEnumerable<T>>
    {
        /// <summary>
        /// Wraps a specified collection with an optional offset for evaluation.
        /// </summary>
        /// <param name="handle">The target collection wrapped for evaluation.</param>
        /// <param name="offset">The specified offset for evaluation.</param>
        internal EnumerableConditionalExpression(IEnumerable<T> handle, bool? offset = null) 
            : base(handle, offset)
        {
        }
    }
}