namespace System
{
    using Collections.Generic;
    using Linq;

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
        public static void AddMany<T>(this ICollection<T> self, params T[] args)
            => Array.ForEach(args, self.Add);

        /// <summary>
        /// Uses a predicate to remove matching items from the target collection.
        /// </summary>
        /// <typeparam name="T">The type of item in the collection.</typeparam>
        /// <param name="self">The target collection.</param>
        /// <param name="predicate">The predicate to find matches in the target collection.</param>
        public static bool Remove<T>(this ICollection<T> self, Func<T, bool> predicate)
            => self.Where(predicate).All(self.Remove);
    }
}