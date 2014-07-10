using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sugar
{
    /// <summary>
    /// Provides fluent comparable expressions for enumerable types.
    /// </summary>
    /// <typeparam name="TItem">The type of item in the enumerable collection.</typeparam>
    /// <typeparam name="TCollection">The type of the collection.</typeparam>
    public class EnumerableComparableExpression<TItem, TCollection> : ComparableExpression<TCollection, EnumerableConditionalExpression<TItem, TCollection>>, IEnumerableComparableExpression<TItem, TCollection> 
        where TCollection : IEnumerable<TItem>
    {
        /// <summary>
        /// Provides a fluent comparison to determine if the wrapped collection is empty.
        /// </summary>
        public EnumerableConditionalExpression<TItem, TCollection> Empty()
        {
            return new EnumerableConditionalExpression<TItem, TCollection>(Context, !Context.Any());
        }

        /// <summary>
        /// Wraps the collection in a comparable expression.
        /// </summary>
        internal EnumerableComparableExpression(TCollection context) 
            : base(context)
        {
        }

        /// <summary>
        /// Generates a new instance of <see cref="ConditionalExpression{T}"/> for use by subsequent expressions.
        /// </summary>
        protected override EnumerableConditionalExpression<TItem, TCollection> GetDefaultExpression()
        {
            return new EnumerableConditionalExpression<TItem, TCollection>(Context, HandleIsDefault());
        }

        /// <summary>
        /// Generates a new instance of <see cref="ConditionalExpression{T}"/> for use by subsequent expressions.
        /// </summary>
        protected override EnumerableConditionalExpression<TItem, TCollection> GetConditionalExpression(bool predicate)
        {
            return new EnumerableConditionalExpression<TItem, TCollection>(Context, predicate);
        }

        private bool HandleIsDefault()
        {
            var isEqual = RuntimeHelpers.Equals(Context, default(TCollection));
            return Evaluate(isEqual);
        }
    }
}