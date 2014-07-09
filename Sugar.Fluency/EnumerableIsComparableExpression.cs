using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Provides fluent comparable expressions for evaluation on a wrapped collection.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <typeparam name="TCollection">The type of wrapped collection for evaluation.</typeparam>
    public class EnumerableIsComparableExpression<TItem, TCollection> :
        EnumerableIsComparableExpression<TItem, TCollection, EnumerableConditionalExpression<TItem, TCollection>> 
        where TCollection : IEnumerable<TItem>
    {
        /// <summary>
        /// Wraps the collection in a comparable expression.
        /// </summary>
        public EnumerableIsComparableExpression(TCollection context) 
            : base(context)
        {
        }

        protected override EnumerableConditionalExpression<TItem, TCollection> GetDefaultExpression()
        {
            return new EnumerableConditionalExpression<TItem, TCollection>(Context, Context.Equals(default(TCollection)));
        }

        protected override EnumerableConditionalExpression<TItem, TCollection> GetConditionalExpression(bool predicate)
        {
            return new EnumerableConditionalExpression<TItem, TCollection>(Context, predicate);
        }
    }

    /// <summary>
    /// Provides fluent comparable expressions for evaluation on a wrapped collection.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    /// <typeparam name="TCollection">The type of wrapped collection for evaluation.</typeparam>
    /// <typeparam name="TConditional">The type of conditional expression returned from preceeding expressions.</typeparam>
    public abstract class EnumerableIsComparableExpression<TItem, TCollection, TConditional> : 
        IsComparableExpression<TCollection, TConditional>, 
        IEnumerableComparableExpression<TItem, TCollection, TConditional> 
        where TCollection : IEnumerable<TItem> 
        where TConditional : IConditionalExpression<TCollection>
    {
        private readonly Lazy<EnumerableConditionalExpression<TItem, TCollection>> _empty;

        /// <summary>
        /// Provides a fluent comparison to determine if the wrapped collection is empty.
        /// </summary>
        public EnumerableConditionalExpression<TItem, TCollection> Empty { get { return _empty.Value; } }

        /// <summary>
        /// Wraps the collection in a comparable expression.
        /// </summary>
        protected internal EnumerableIsComparableExpression(TCollection context) 
            : base(context)
        {
            _empty = new Lazy<EnumerableConditionalExpression<TItem, TCollection>>(() =>
                new EnumerableConditionalExpression<TItem, TCollection>(context, !context.Any()));
        }
    }
}