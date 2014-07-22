namespace System.Collections
{
    using Linq;

    public static class EnumerableExtensions
    {
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
