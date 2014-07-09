using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar.Linq
{
    /// <summary>
    /// Provides extension methods to perform common operations with enumerables.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Provides a parameterless conversion for KeyValuePair collections to a dictionary.
        /// </summary>
        /// <typeparam name="TKey">The Key of a dictionary item.</typeparam>
        /// <typeparam name="TValue">The Value of a dictionary item.</typeparam>
        /// <param name="self">The target collection to convert into a Dictionary.</param>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> self)
        {
            return self.ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Enumerates over a collection and performs an action on each item.
        /// </summary>
        /// <typeparam name="T">The type of an item in the collection.</typeparam>
        /// <param name="self">The target collection.</param>
        /// <param name="action">The action to be applied to each item in the collection.</param>
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self)
            {
                action(item);
            }
        }

        /// <summary>
        /// Applies a predicate selection clause to the Linq Distinct method.
        /// </summary>
        /// <typeparam name="T">The type of an item in the target collection.</typeparam>
        /// <param name="self">The target collection being filtered.</param>
        /// <param name="predicate">The predicate filter being applied before distinct is called.</param>
        /// <returns>The filtered collection.</returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> self, Func<T, bool> predicate)
        {
            return self.Where(predicate).Distinct();
        }

        /// <summary>
        /// Provides the logical compliment of Enumerable.Any.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="self">The target collection.</param>
        /// <param name="predicate">The filter condition.</param>
        /// <returns>Returns true if all items return false against the predicate.</returns>
        public static bool None<T>(this IEnumerable<T> self, Func<T, bool> predicate)
        {
            return self.All(x => !predicate(x));
        }

        /// <summary>
        /// Provides the logical compliment of Enumerable.Any.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="self">The target collection.</param>
        /// <returns>Returns true if all items return false against the predicate.</returns>
        public static bool None<T>(this IEnumerable<T> self)
        {
            return !self.Any();
        }

        /// <summary>
        /// Determines if any item from one collection are comparable to any items within another.
        /// </summary>
        /// <typeparam name="TIn">The target type of the items in the collection.</typeparam>
        /// <typeparam name="TOut">The expected type for the return result of the predicate.</typeparam>
        /// <param name="self">The initial collection.</param>
        /// <param name="target">The comparable collection.</param>
        /// <param name="predicate">The method for comparison.</param>
        /// <returns>Returns false if the predicate returns false against all matches.</returns>
        public static bool MatchAny<TIn, TOut>(this IEnumerable<TIn> self, IEnumerable<TIn> target, Func<TIn, TOut> predicate)
        {
            return self.Any(x => target.Any(y => predicate(x).Equals(predicate(y))));
        }

        /// <summary>
        /// Determines if any item from one collection is contained within another.
        /// </summary>
        /// <typeparam name="T">The target type of the items in the collection.</typeparam>
        /// <param name="self">The initial collection.</param>
        /// <param name="items">The comparable collection.</param>
        /// <returns>Returns false if the predicate returns false against all matches.</returns>
        public static bool MatchesAny<T>(this IEnumerable<T> self, params T[] items)
        {
            return items.Any(self.Contains);
        }

        /// <summary>
        /// Determines if all items from one collection are comparable to any items within another.
        /// </summary>
        /// <typeparam name="TIn">The target type of the collection.</typeparam>
        /// <typeparam name="TOut">The expected type for the return result of the predicate.</typeparam>
        /// <param name="self">The initial collection.</param>
        /// <param name="target">The comparable collection.</param>
        /// <param name="predicate">The method for comparison.</param>
        /// <returns>Returns false if the predicate returns false against any matches.</returns>
        public static bool MatchAll<TIn, TOut>(this IEnumerable<TIn> self, IEnumerable<TIn> target, Func<TIn, TOut> predicate)
        {
            return self.All(x => target.Any(y => predicate(x).Equals(predicate(y))));
        }

        /// <summary>
        /// Determines if all items from one collection are contained within another.
        /// </summary>
        /// <typeparam name="T">The target type of the items in the collection.</typeparam>
        /// <param name="self">The initial collection.</param>
        /// <param name="items">The comparable collection.</param>
        /// <returns>Returns false if the predicate returns false against any matches.</returns>
        public static bool MatchesAll<T>(this IEnumerable<T> self, params T[] items)
        {
            return items.All(self.Contains);
        }

        /// <summary>
        /// Provides the inverse of TakeWhile with a predicate.  Filters while the predicate evaluates as false.
        /// </summary>
        /// <typeparam name="T">The type of item in the collection.</typeparam>
        /// <param name="self">The collection being filtered.</param>
        /// <param name="predicate">The predicate to filter against.</param>
        /// <returns>The filtered collection.</returns>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> self, Func<T, bool> predicate)
        {
            return self.TakeWhile(x => predicate(x).IsFalse());
        }

        /// <summary>
        /// Provides the greatest value in a collection using a comparer.
        /// </summary>
        /// <typeparam name="TItem">The type of item in the collection.</typeparam>
        /// <typeparam name="TValue">The selected return value.</typeparam>
        /// <param name="items">The target collection.</param>
        /// <param name="selector">Applies a selection to aggregated items.</param>
        /// <param name="comparer">An optional custom comparer.</param>
        /// <returns>The greatest value in the filtered selection.</returns>
        public static TItem Max<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> selector, IComparer<TValue> comparer = null)
            where TItem : class
            where TValue : IComparable
        {
            comparer = comparer ?? Comparer<TValue>.Default;

            return items.Where(Is.Not.Null).Aggregate((x, y) =>
            {
                var xValue = selector(x);
                var yValue = selector(y);

                return Fluent.It(yValue, Is.GreaterThan(xValue, comparer)) ? y : x;
            });
        }

        /// <summary>
        /// Provides the smalles value in a collection using a comparer.
        /// </summary>
        /// <typeparam name="TItem">The type of item in the collection.</typeparam>
        /// <typeparam name="TValue">The selected return value.</typeparam>
        /// <param name="items">The target collection.</param>
        /// <param name="selector">Applies a selection to aggregated items.</param>
        /// <param name="comparer">An optional custom comparer.</param>
        /// <returns>The smallest value in the filtered selection.</returns>
        public static TItem Min<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> selector, IComparer<TValue> comparer = null)
            where TItem : class
            where TValue : IComparable
        {
            return items.Where(Is.Not.Null).Aggregate((x, y) =>
            {
                var xValue = selector(x);
                var yValue = selector(y);

                return Fluent.It(yValue, Is.LessThan(xValue)) ? y : x;
            });
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
            var comparer = comparison.AsComparer();
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
            var comparer = comparison.AsComparer();
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
        {
            return self.Where(Is.Not.Null).Select(selector);
        }
    }
}