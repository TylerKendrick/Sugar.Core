using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar.Linq
{
    /// <summary>
    /// Exposes additional add and remove overloaded methods to collections.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Allows parameterized array addition for collections.
        /// </summary>
        /// <typeparam name="T">The type of item in the collection.</typeparam>
        /// <param name="self">The target collection.</param>
        /// <param name="args">The list of arguments to add.</param>
        public static void Add<T>(this ICollection<T> self, params T[] args)
        {
            self.ForEach(self.Add);
        }

        /// <summary>
        /// Uses a predicate to remove matching items from the target collection.
        /// </summary>
        /// <typeparam name="T">The type of item in the collection.</typeparam>
        /// <param name="self">The target collection.</param>
        /// <param name="predicate">The predicate to find matches in the target collection.</param>
        /// <returns></returns>
        public static bool Remove<T>(this ICollection<T> self, Func<T, bool> predicate)
        {
            return self.Where(predicate).All(self.Remove);
        }
    }
}