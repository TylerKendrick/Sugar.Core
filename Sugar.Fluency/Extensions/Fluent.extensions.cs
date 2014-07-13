using System;
using System.Collections.Generic;

namespace Sugar.Extensions
{
    internal static class FluentExpressionExtensions
    {
        internal static FluentPredicate<T> Generate<T>(this IFluentExpression<T> self,
            Func<T, bool> predicate)
        {
            return new FluentPredicate<T>(self.Context, predicate(self.Context));
        }

        internal static FluentPredicate<TCollection> Generate<TItem, TCollection>(this 
            IFluentExpression<TCollection> self,
            Func<TCollection, bool> predicate)
            where TCollection : IEnumerable<TItem>
        {
            return new FluentPredicate<TCollection>(self.Context, predicate(self.Context));
        }
    }
}