using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sugar
{
    /// <summary>
    /// Provides fluent comparable expressions for enumerable types.
    /// </summary>
    /// <typeparam name="TItem">The type of item in the enumerable collection.</typeparam>
    public class EnumerableFluentExpression<TItem> : FluentExpression<IEnumerable<TItem>, 
        FluentPredicate<IEnumerable<TItem>>>, IEnumerableFluentExpression<TItem>
    {
        /// <summary>
        /// Provides a fluent comparison to determine if the wrapped collection is empty.
        /// </summary>
        public FluentPredicate<IEnumerable<TItem>> Empty()
        {
            return new FluentPredicate<IEnumerable<TItem>>(Context, !Context.Any());
        }

        /// <summary>
        /// Wraps the collection in a comparable expression.
        /// </summary>
        internal EnumerableFluentExpression(IEnumerable<TItem> context) 
            : base(context)
        {
        }

        /// <summary>
        /// Generates a new instance of <see cref="FluentPredicate{T}"/> for use by subsequent expressions.
        /// </summary>
        protected override FluentPredicate<IEnumerable<TItem>> GetDefaultExpression()
        {
            return new FluentPredicate<IEnumerable<TItem>>(Context, HandleIsDefault());
        }

        /// <summary>
        /// Generates a new instance of <see cref="FluentPredicate{T}"/> for use by subsequent expressions.
        /// </summary>
        protected override FluentPredicate<IEnumerable<TItem>> GetConditionalExpression(bool predicate)
        {
            return new FluentPredicate<IEnumerable<TItem>>(Context, predicate);
        }

        private bool HandleIsDefault()
        {
            var isEqual = RuntimeHelpers.Equals(Context, default(IEnumerable<TItem>));
            return Evaluate(isEqual);
        }
    }
}