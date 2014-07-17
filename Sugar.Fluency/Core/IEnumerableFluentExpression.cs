using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// Provides fluent comparable expressions for enumerable types.
    /// </summary>
    /// <typeparam name="TItem">The type of item in the enumerable collection.</typeparam>
    public interface IEnumerableFluentExpression<TItem> : IFluentExpression<IEnumerable<TItem>>
    {
        /// <summary>
        /// Provides a fluent comparison to determine if the wrapped collection is empty.
        /// </summary>
        FluentPredicate<IEnumerable<TItem>> Empty();
    }
}