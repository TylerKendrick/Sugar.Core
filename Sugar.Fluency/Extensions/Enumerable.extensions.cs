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
        public static FluentPredicate<TCollection> Empty<TItem, TCollection>(this IEnumerableFluentExpression<TItem, TCollection> self)
            where TCollection : IEnumerable<TItem>
        {
            return self.Generate<TItem, TCollection>(x => !x.Any());
        }

        private static FluentPredicate<TCollection> Generate<TItem, TCollection>(this IFluentExpression<TCollection, FluentPredicate<TCollection>> self,
            Func<TCollection, bool> predicate)
            where TCollection : IEnumerable<TItem>
        {
            return new FluentPredicate<TCollection>(self.Context, predicate(self.Context));
        }
    }
}