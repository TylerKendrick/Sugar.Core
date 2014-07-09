using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Provides fluent comparable expressions for enumerable types.
    /// </summary>
    /// <typeparam name="TItem">The type of item in the enumerable collection.</typeparam>
    /// <typeparam name="TCollection">The type of the collection.</typeparam>
    public class EnumerableComparableExpression<TItem, TCollection> : ComparableExpression<TCollection>, 
        IEnumerableComparableExpression<TItem, TCollection> 
        where TCollection : IEnumerable<TItem>
    {
        private readonly Lazy<EnumerableConditionalExpression<TItem, TCollection>> _empty;

        /// <summary>
        /// Provides a fluent comparison to determine if the wrapped collection is empty.
        /// </summary>
        public EnumerableConditionalExpression<TItem, TCollection> Empty { get { return _empty.Value; } }
        
        /// <summary>
        /// Wraps the collection in a comparable expression.
        /// </summary>
        public EnumerableComparableExpression(TCollection context) : base(context)
        {
            _empty = new Lazy<EnumerableConditionalExpression<TItem, TCollection>>(() =>
                new EnumerableConditionalExpression<TItem, TCollection>(context, !context.Any()));
        }
    }

    /// <summary>
    /// Provides fluent comparable expressions for enumerable types.
    /// </summary>
    /// <typeparam name="T">The type of item in the enumerable collection.</typeparam>
    public class EnumerableComparableExpression<T> : EnumerableComparableExpression<T, IEnumerable<T>>
    {
        /// <summary>
        /// Wraps the collection in a comparable expression.
        /// </summary>
        public EnumerableComparableExpression(IEnumerable<T> context) 
            : base(context)
        {
        }
    }
}