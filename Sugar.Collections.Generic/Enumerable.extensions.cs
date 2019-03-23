namespace System.Collections.Generic
{
    using System;

    /// <summary>
    /// Provides common operations with generic Enumerables as extension methods.
    /// </summary>
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
    }
}
