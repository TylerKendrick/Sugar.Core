using System.Collections.Generic;

namespace Sugar
{
    /// <summary>
    /// Provides fluent comparable expressions for enumerable types.
    /// </summary>
    /// <typeparam name="TItem">The type of item in the enumerable collection.</typeparam>
    /// <typeparam name="TCollection">The type of the collection.</typeparam>
    public interface IEnumerableComparableExpression<TItem, TCollection> : IComparableExpression<TCollection, EnumerableConditionalExpression<TItem, TCollection>>
        where TCollection : IEnumerable<TItem>
    {
        /// <summary>
        /// Provides a fluent comparison to determine if the wrapped collection is empty.
        /// </summary>
        EnumerableConditionalExpression<TItem, TCollection> Empty();
    }
}