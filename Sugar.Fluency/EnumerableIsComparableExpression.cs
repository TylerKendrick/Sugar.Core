using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar
{
    public static class EnumerableComparableExtensions
    {
        /// <summary>
        /// Provides a fluent comparison to determine if the wrapped collection is empty.
        /// </summary>
        public static EnumerableConditionalExpression<TItem, TCollection> Empty<TItem, TCollection>(this IEnumerableComparableExpression<TItem, TCollection> self)
            where TCollection : IEnumerable<TItem>
        {
            return self.Generate(x => !x.Any());
        }

        private static EnumerableConditionalExpression<TItem, TCollection> Generate<TItem, TCollection>(this IComparableExpression<TCollection, EnumerableConditionalExpression<TItem, TCollection>> self,
            Func<TCollection, bool> predicate)
            where TCollection : IEnumerable<TItem>
        {
            return new EnumerableConditionalExpression<TItem, TCollection>(self.Context, predicate(self.Context));
        }
    }
}