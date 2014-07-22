namespace System.Collections.Generic
{
    using System;

    public static class EnumerableExtensions
    {
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

        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> self)
        {
            Require.That(self != null);
            while (true)
            {
                foreach (var item in self)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> self, Func<bool> predicate)
        {
            Require.That(self != null);
            while (predicate())
            {
                foreach (var item in self)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> self, Func<T, bool> predicate)
        {
            Require.That(self != null);
            var @continue = true;
            while (@continue)
            {
                foreach (var item in self)
                {
                    var result = predicate(item);
                    @continue = result;
                    if (@continue == false)
                    {
                        break;
                    }
                    yield return item;
                }
            }
        }
    }
}
