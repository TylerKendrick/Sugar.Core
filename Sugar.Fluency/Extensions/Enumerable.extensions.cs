using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class EnumerableComparableExtensions
    {
        /// <summary>
        /// Provides a fluent comparison to determine if the wrapped collection is empty.
        /// </summary>
        public static FluentPredicate<IEnumerable<TItem>> Empty<TItem>(this IEnumerableFluentExpression<TItem> self)
        {
            return self.Generate(x => !x.Any());
        }
    }
}