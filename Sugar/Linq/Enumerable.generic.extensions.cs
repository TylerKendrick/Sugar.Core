namespace System.Linq
{
    using Collections.Generic;

    /// <summary>
    /// Provides extension methods to perform common operations with enumerables.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Join two collections by a specified selector per matching index.
        /// </summary>
        /// <typeparam name="TFirst">The type of item in the original collection.</typeparam>
        /// <typeparam name="TSecond">The type of item in the target collection.</typeparam>
        /// <typeparam name="TResult">The type of item in the returned collection.</typeparam>
        /// <param name="self">The original collection.</param>
        /// <param name="other">The target collection</param>
        /// <param name="selector">The selector used against matching indices.</param>
        /// <returns>Returns an aggregated enumerable 
        /// from the join result of the two specified collections.</returns>
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> self,
            IEnumerable<TSecond> other, Func<TFirst, TSecond, TResult> selector) => self
                .Select((x, i) => new { i, data = x })
                .Join(other.Select((y, i) => new { i, data = y }),
                    x => x.i, y => y.i,
                    (x, y) => selector(x.data, y.data));

        /// <summary>
        /// Splits the target collection into multiple enumerables based
        /// on a specified selector.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Split<T, TKey>(this IEnumerable<T> self, Func<T, int, TKey> keySelector) => self
            .Select((x, i) => new { i, data = x })
            .GroupBy(x => keySelector(x.data, x.i))
            .Select(x => x.Select(y => y.data));

        /// <summary>
        /// Splits the target collection into multiple enumerables based
        /// on a specified selector.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> self, int count)
            => self.Split((_, i) => i / count);

        /// <summary>
        /// Uses a <see cref="Func{TIn, TOut}"/> as a predicate for Enumerable.Intersect operations.
        /// </summary>
        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> self, IEnumerable<T> other,
            Func<T, T, bool> equalityComparer)
            => self.Intersect(other, EqualityComparer.Create(equalityComparer));

        /// <summary>
        /// Uses a <see cref="Func{TIn, TOut}"/> as a predicate for Enumerable.Union operations.
        /// </summary>
        public static IEnumerable<T> Union<T>(this IEnumerable<T> self, IEnumerable<T> other,
            Func<T, T, bool> equalityComparer)
            => self.Union(other, EqualityComparer.Create(equalityComparer));

        /// <summary>
        /// Uses a <see cref="Func{TIn, TOut}"/> as a predicate for Enumerable.Except operations.
        /// </summary>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> self, IEnumerable<T> other,
            Func<T, T, bool> equalityComparer)
            => self.Except(other, EqualityComparer.Create(equalityComparer));

        /// <summary>
        /// Applies a predicate selection clause to the Enumerable.Distinct method.
        /// </summary>
        /// <typeparam name="T">The type of an item in the target collection.</typeparam>
        /// <param name="self">The target collection being filtered.</param>
        /// <param name="predicate">The predicate filter being applied before distinct is called.</param>
        /// <returns>The filtered collection.</returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> self, Func<T, bool> predicate)
            => self.Where(predicate).Distinct();

        /// <summary>
        /// Returns all non-distinct elements from a sequence 
        /// by using <paramref name="predicate"/> to compare values.
        /// </summary>
        /// <typeparam name="T">The type of an item in the target collection.</typeparam>
        /// <param name="self">The target collection being filtered.</param>
        /// <param name="predicate">The predicate filter being applied before distinct is called.</param>
        /// <returns>The filtered collection.</returns>
        public static IEnumerable<T> Indistinct<T>(this IEnumerable<T> self, Func<T, bool> predicate)
            => self.Where(predicate).Indistinct();

        /// <summary>
        /// Returns all non-distinct elements from a sequence 
        /// by using the default comparer to compare values.
        /// </summary>
        /// <typeparam name="T">The type of an item in the target collection.</typeparam>
        /// <param name="self">The target collection being filtered.</param>
        /// <returns>The filtered collection.</returns>
        public static IEnumerable<T> Indistinct<T>(this IEnumerable<T> self)
            => self.GroupBy(Lambda.Identity).SelectMany(x => x.Skip(1));

        /// <summary>
        /// Provides the logical compliment of Enumerable.Any.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="self">The target collection.</param>
        /// <param name="predicate">The filter condition.</param>
        /// <returns>Returns true if all items return false against the predicate.</returns>
        public static bool None<T>(this IEnumerable<T> self, Func<T, bool> predicate)
            => self.All(x => !predicate(x));

        /// <summary>
        /// Provides the logical compliment of Enumerable.Any.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="self">The target collection.</param>
        /// <returns>Returns true if all items return false against the predicate.</returns>
        public static bool None<T>(this IEnumerable<T> self) => !self.Any();

        /// <summary>
        /// Determines if any item from one collection are comparable to any items within another.
        /// </summary>
        /// <typeparam name="TIn">The target type of the items in the collection.</typeparam>
        /// <typeparam name="TOut">The expected type for the return result of the predicate.</typeparam>
        /// <param name="self">The initial collection.</param>
        /// <param name="target">The comparable collection.</param>
        /// <param name="predicate">The method for comparison.</param>
        /// <returns>Returns false if the predicate returns false against all matches.</returns>
        public static bool MatchAny<TIn, TOut>(this IEnumerable<TIn> self,
            IEnumerable<TIn> target, Func<TIn, TOut> predicate)
            => self.Any(x => target.Any(y => predicate(x).Equals(predicate(y))));

        /// <summary>
        /// Determines if any item from one collection is contained within another.
        /// </summary>
        /// <typeparam name="T">The target type of the items in the collection.</typeparam>
        /// <param name="self">The initial collection.</param>
        /// <param name="items">The comparable collection.</param>
        /// <returns>Returns false if the predicate returns false against all matches.</returns>
        public static bool MatchesAny<T>(this IEnumerable<T> self, params T[] items)
            => items.Any(self.Contains);

        /// <summary>
        /// Determines if all items from one collection are comparable to any items within another.
        /// </summary>
        /// <typeparam name="TIn">The target type of the collection.</typeparam>
        /// <typeparam name="TOut">The expected type for the return result of the predicate.</typeparam>
        /// <param name="self">The initial collection.</param>
        /// <param name="target">The comparable collection.</param>
        /// <param name="predicate">The method for comparison.</param>
        /// <returns>Returns false if the predicate returns false against any matches.</returns>
        public static bool MatchAll<TIn, TOut>(this IEnumerable<TIn> self,
            IEnumerable<TIn> target, Func<TIn, TOut> predicate)
            => self.All(x => target.Any(y => predicate(x).Equals(predicate(y))));

        /// <summary>
        /// Determines if all items from one collection are contained within another.
        /// </summary>
        /// <typeparam name="T">The target type of the items in the collection.</typeparam>
        /// <param name="self">The initial collection.</param>
        /// <param name="items">The comparable collection.</param>
        /// <returns>Returns false if the predicate returns false against any matches.</returns>
        public static bool MatchesAll<T>(this IEnumerable<T> self, params T[] items)
            => items.All(self.Contains);

        /// <summary>
        /// Provides the inverse of TakeWhile with a predicate.  
        /// Filters while the predicate evaluates as false.
        /// </summary>
        /// <typeparam name="T">The type of item in the collection.</typeparam>
        /// <param name="self">The collection being filtered.</param>
        /// <param name="predicate">The predicate to filter against.</param>
        /// <returns>The filtered collection.</returns>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> self, Func<T, bool> predicate)
            => self.TakeWhile(x => !predicate(x));

        /// <summary>
        /// Provides the inverse of TakeWhile with a predicate.  
        /// Filters while the predicate evaluates as false.
        /// </summary>
        /// <typeparam name="T">The type of item in the collection.</typeparam>
        /// <param name="self">The collection being filtered.</param>
        /// <param name="predicate">The predicate to filter against.</param>
        /// <returns>The filtered collection.</returns>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> self, Func<T, int, bool> predicate)
            => self.TakeWhile((x, i) => !predicate(x, i));

        /// <summary>
        /// Provides the inverse of SkipWhile with a predicate.  
        /// Filters while the predicate evaluates as false.
        /// </summary>
        /// <typeparam name="T">The type of item in the collection.</typeparam>
        /// <param name="self">The collection being filtered.</param>
        /// <param name="predicate">The predicate to filter against.</param>
        /// <returns>The filtered collection.</returns>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> self, Func<T, bool> predicate)
            => self.SkipWhile(x => !predicate(x));

        /// <summary>
        /// Provides the inverse of SkipWhile with a predicate.  
        /// Filters while the predicate evaluates as false.
        /// </summary>
        /// <typeparam name="T">The type of item in the collection.</typeparam>
        /// <param name="self">The collection being filtered.</param>
        /// <param name="predicate">The predicate to filter against.</param>
        /// <returns>The filtered collection.</returns>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> self, Func<T, int, bool> predicate)
            => self.SkipWhile((x, i) => !predicate(x, i));

        /// <summary>
        /// Provides the greatest value in a collection using a comparer.
        /// </summary>
        /// <typeparam name="TItem">The type of item in the collection.</typeparam>
        /// <typeparam name="TValue">The selected return value.</typeparam>
        /// <param name="items">The target collection.</param>
        /// <param name="selector">Applies a selection to aggregated items.</param>
        /// <returns>The greatest value in the filtered selection.</returns>
        public static TItem Max<TItem, TValue>(this IEnumerable<TItem> items,
            Func<TItem, TValue> selector)
            where TItem : class
            where TValue : IComparable
            => Max(items, selector, Comparer<TValue>.Default);

        /// <summary>
        /// Provides the greatest value in a collection using a comparer.
        /// </summary>
        /// <typeparam name="TItem">The type of item in the collection.</typeparam>
        /// <typeparam name="TValue">The selected return value.</typeparam>
        /// <param name="items">The target collection.</param>
        /// <param name="selector">Applies a selection to aggregated items.</param>
        /// <param name="comparer">An optional custom comparer.</param>
        /// <returns>The greatest value in the filtered selection.</returns>
        public static TItem Max<TItem, TValue>(this IEnumerable<TItem> items,
            Func<TItem, TValue> selector, IComparer<TValue> comparer)
            where TItem : class
            where TValue : IComparable
            => items.Maybe().Aggregate(AggregateMax(selector, comparer));

        private static Func<TItem, TItem, TItem> AggregateMax<TItem, TValue>(
            Func<TItem, TValue> selector,
            IComparer<TValue> comparer)
            where TItem : class where TValue : IComparable
            => (x, y) => FindMaxItem(selector, comparer, x, y);

        private static TItem FindMaxItem<TItem, TValue>(Func<TItem, TValue> selector,
            IComparer<TValue> comparer, TItem x, TItem y)
            where TItem : class
            where TValue : IComparable
        {
            var xValue = selector(x);
            var yValue = selector(y);

            return yValue.IsGreaterThan(xValue, comparer) ? y : x;
        }

        /// <summary>
        /// Provides the smallest value in a collection using a comparer.
        /// </summary>
        /// <typeparam name="TItem">The type of item in the collection.</typeparam>
        /// <typeparam name="TValue">The selected return value.</typeparam>
        /// <param name="items">The target collection.</param>
        /// <param name="selector">Applies a selection to aggregated items.</param>
        /// <returns>The smallest value in the filtered selection.</returns>
        public static TItem Min<TItem, TValue>(this IEnumerable<TItem> items,
            Func<TItem, TValue> selector)
            where TItem : class
            where TValue : IComparable
            => Min(items, selector, Comparer<TValue>.Default);

        /// <summary>
        /// Provides the smallest value in a collection using a comparer.
        /// </summary>
        /// <typeparam name="TItem">The type of item in the collection.</typeparam>
        /// <typeparam name="TValue">The selected return value.</typeparam>
        /// <param name="items">The target collection.</param>
        /// <param name="selector">Applies a selection to aggregated items.</param>
        /// <param name="comparer">An optional custom comparer.</param>
        /// <returns>The smallest value in the filtered selection.</returns>
        public static TItem Min<TItem, TValue>(this IEnumerable<TItem> items,
            Func<TItem, TValue> selector, IComparer<TValue> comparer)
            where TItem : class
            where TValue : IComparable
        {
            return items.Maybe().Aggregate(AggregateMin(selector, comparer));
        }

        private static Func<TItem, TItem, TItem> AggregateMin<TItem, TValue>(
            Func<TItem, TValue> selector, IComparer<TValue> comparer)
            where TItem : class where TValue : IComparable
        {
            return (x, y) => FindMinItem(selector, x, y, comparer);
        }

        private static TItem FindMinItem<TItem, TValue>(
            Func<TItem, TValue> selector, TItem x, TItem y, IComparer<TValue> comparer)
            where TItem : class
            where TValue : IComparable
        {
            var xValue = selector(x);
            var yValue = selector(y);

            return yValue.IsLessThan(xValue, comparer) ? y : x;
        }

        /// <summary>
        /// Order by a selection in ascending order using a custom comparison.
        /// </summary>
        /// <typeparam name="TIn">The type of item in the source collection.</typeparam>
        /// <typeparam name="TOut">The type being selected for ordering.</typeparam>
        /// <param name="self">The source collection.</param>
        /// <param name="selector">The selection expression.</param>
        /// <param name="comparison">A custom comparison expression.</param>
        /// <returns>The ordered collection.</returns>
        public static IOrderedEnumerable<TIn> OrderBy<TIn, TOut>(this IEnumerable<TIn> self,
            Func<TIn, TOut> selector, Func<TOut, TOut, int> comparison)
        {
            var comparer = CustomComparer.Create(comparison);
            return self.OrderBy(selector, comparer);
        }

        /// <summary>
        /// Order by a selection in ascending order using a custom comparison.
        /// </summary>
        /// <typeparam name="TIn">The type of item in the source collection.</typeparam>
        /// <typeparam name="TOut">The type being selected for ordering.</typeparam>
        /// <param name="self">The source collection.</param>
        /// <param name="selector">The selection expression.</param>
        /// <param name="comparison">A custom comparison expression.</param>
        /// <returns>The ordered collection.</returns>
        public static IOrderedEnumerable<TIn> OrderByDescending<TIn, TOut>(this IEnumerable<TIn> self,
            Func<TIn, TOut> selector, Func<TOut, TOut, int> comparison)
        {
            var comparer = CustomComparer.Create(comparison);
            return self.OrderByDescending(selector, comparer);
        }

        /// <summary>
        /// Applies a selector to the source collection to filter by all non-null entries.
        /// </summary>
        /// <typeparam name="TIn">The type in the source collection.</typeparam>
        /// <typeparam name="TOut">The type for selection.</typeparam>
        /// <param name="self">The source collection.</param>
        /// <param name="selector">The selection expression.</param>
        /// <returns>All selected non-null entries.</returns>
        public static IEnumerable<TOut> Maybe<TIn, TOut>(this IEnumerable<TIn> self, Func<TIn, TOut> selector)
            where TIn : class
            where TOut : class
            => self.Where(x => x != null).Select(selector);

        /// <summary>
        /// Applies a selector to the source collection to filter by all non-null entries.
        /// </summary>
        /// <typeparam name="TIn">The type in the source collection.</typeparam>
        /// <param name="self">The source collection.</param>
        /// <returns>All selected non-null entries.</returns>
        public static IEnumerable<TIn> Maybe<TIn>(this IEnumerable<TIn> self)
            where TIn : class => self.Where(x => x != null);

        /// <summary>
        /// Returns the first element of a sequence, or a fallback value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="self"/>.</typeparam>
        /// <param name="self">The <see cref="IEnumerable{T}"/> to return the first element of.</param>
        /// <param name="fallback">The value to provide if the collection is empty.</param>
        /// <returns>
        /// <paramref name="fallback"/> if <paramref name="self"/> is empty; otherwise, the first element in <paramref name="self"/>.
        /// </returns>
        public static T FirstOrFallback<T>(this IEnumerable<T> self, T fallback)
        {
            var enumerable = self as T[] ?? self.ToArray();
            return enumerable.Any() ? enumerable.First() : fallback;
        }

        /// <summary>
        /// Returns the first element of a sequence, or a fallback value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="self"/>.</typeparam>
        /// <param name="self">The <see cref="IEnumerable{T}"/> to return the first element of.</param>
        /// <param name="selector">A function to test each element for a condition.</param>
        /// <param name="fallback">The value to provide if the collection is empty.</param>
        /// <returns>
        /// <paramref name="fallback"/> if <paramref name="self"/> is empty; otherwise, the first element in <paramref name="self"/>.
        /// </returns>
        public static T FirstOrFallback<T>(this IEnumerable<T> self, Func<T, bool> selector, T fallback)
        {
            var enumerable = self as T[] ?? self.ToArray();
            return enumerable.Any(selector) ? enumerable.First(selector) : fallback;
        }

        /// <summary>
        /// Returns the last element of a sequence, or a fallback value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="self"/>.</typeparam>
        /// <param name="self">The <see cref="IEnumerable{T}"/> to return the last element of.</param>
        /// <param name="fallback">The value to provide if the collection is empty.</param>
        /// <returns>
        /// <paramref name="fallback"/> if <paramref name="self"/> is empty; otherwise, the last element in <paramref name="self"/>.
        /// </returns>
        public static T LastOrFallback<T>(this IEnumerable<T> self, T fallback)
        {
            var enumerable = self as T[] ?? self.ToArray();
            return enumerable.Any() ? enumerable.Last() : fallback;
        }

        /// <summary>
        /// Returns the last element of a sequence, or a fallback value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="self"/>.</typeparam>
        /// <param name="self">The <see cref="IEnumerable{T}"/> to return the last element of.</param>
        /// <param name="selector">A function to test each element for a condition.</param>
        /// <param name="fallback">The value to provide if the collection is empty.</param>
        /// <returns>
        /// <paramref name="fallback"/> if <paramref name="self"/> is empty; otherwise, the last element in <paramref name="self"/>.
        /// </returns>
        public static T LastOrFallback<T>(this IEnumerable<T> self, Func<T, bool> selector, T fallback)
        {
            var enumerable = self as T[] ?? self.ToArray();
            return enumerable.Any(selector) ? enumerable.Last(selector) : fallback;
        }

        /// <summary>
        /// Returns the only element of a sequence, or a fallback value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="self"/>.</typeparam>
        /// <param name="self">The <see cref="IEnumerable{T}"/> to return the only element of.</param>
        /// <param name="fallback">The value to provide if the collection is empty.</param>
        /// <returns>
        /// <paramref name="fallback"/> if <paramref name="self"/> is empty; otherwise, the only element in <paramref name="self"/>.
        /// </returns>
        public static T SingleOrFallback<T>(this IEnumerable<T> self, T fallback)
        {
            var enumerable = self as T[] ?? self.ToArray();
            return enumerable.Any() ? enumerable.Single() : fallback;
        }

        /// <summary>
        /// Returns the only element of a sequence, or a fallback value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="self"/>.</typeparam>
        /// <param name="self">The <see cref="IEnumerable{T}"/> to return the only element of.</param>
        /// <param name="selector">A function to test each element for a condition.</param>
        /// <param name="fallback">The value to provide if the collection is empty.</param>
        /// <returns>
        /// <paramref name="fallback"/> if <paramref name="self"/> is empty; otherwise, the only element in <paramref name="self"/>.
        /// </returns>
        public static T SingleOrFallback<T>(this IEnumerable<T> self, Func<T, bool> selector, T fallback)
        {
            var enumerable = self as T[] ?? self.ToArray();
            return enumerable.Any(selector) ? enumerable.Single(selector) : fallback;
        }
    }
}