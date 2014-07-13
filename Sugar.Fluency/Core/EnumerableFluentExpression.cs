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
    public class EnumerableFluentExpression<TItem, TCollection> : FluentExpression<TCollection, FluentPredicate<TCollection>>, IEnumerableFluentExpression<TItem, TCollection> 
        where TCollection : IEnumerable<TItem>
    {
        /// <summary>
        /// Provides a fluent comparison to determine if the wrapped collection is empty.
        /// </summary>
        public FluentPredicate<TCollection> Empty()
        {
            return new FluentPredicate<TCollection>(Context, !Context.Any());
        }

        /// <summary>
        /// Wraps the collection in a comparable expression.
        /// </summary>
        internal EnumerableFluentExpression(TCollection context) 
            : base(context)
        {
        }

        /// <summary>
        /// Generates a new instance of <see cref="FluentPredicate{T}"/> for use by subsequent expressions.
        /// </summary>
        protected override FluentPredicate<TCollection> GetDefaultExpression()
        {
            return new FluentPredicate<TCollection>(Context, HandleIsDefault());
        }

        /// <summary>
        /// Generates a new instance of <see cref="FluentPredicate{T}"/> for use by subsequent expressions.
        /// </summary>
        protected override FluentPredicate<TCollection> GetConditionalExpression(bool predicate)
        {
            return new FluentPredicate<TCollection>(Context, predicate);
        }

        private bool HandleIsDefault()
        {
            var isEqual = RuntimeHelpers.Equals(Context, default(TCollection));
            return Evaluate(isEqual);
        }
    }
}