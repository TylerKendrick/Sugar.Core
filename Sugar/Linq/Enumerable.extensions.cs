﻿namespace System.Linq
{
    using Collections;
    using Collections.Generic;

    /// <summary>
    /// Provides common operations with enumerables not present in Linq for the non-generic IEnumerable.
    /// </summary>
    public static partial class EnumerableExtensions
    {
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

        /// <summary>
        /// Provides Enumerable.Cast as an extension method to the non-generic IEnumerable.
        /// </summary>
        /// <param name="self">The target for casting.</param>
        /// <returns>The target collection as an IEnumerable{object}</returns>
        public static IEnumerable<object> AsEnumerable(this IEnumerable self)
        {
            return self.Cast<object>();
        }

        /// <summary>
        /// Determines if a provided int is within the range of the collection's length.
        /// </summary>
        /// <param name="self">The target collection.</param>
        /// <param name="index">The index to check.</param>
        /// <returns>Returns true if the value is between 0..Count()</returns>
        public static bool HasIndex(this IEnumerable self, int index)
        {
            return index > 0 && index < self.AsEnumerable().Count();
        }

        /// <summary>
        /// Applies actions to filtered items in a collection.
        /// </summary>
        /// <typeparam name="T">The type of items to select as inputs to the provided action.</typeparam>
        /// <param name="self">The target collection of items.</param>
        /// <param name="action">The action to apply only to filtered items.</param>
        public static void ForEach<T>(this IEnumerable self, Action<T> action)
        {
            foreach (var item in self.OfType<T>())
            {
                action(item);
            }
        }
    }
}