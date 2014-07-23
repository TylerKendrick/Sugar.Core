namespace System.Collections
{
    using Generic;
    /// <summary>
    /// Provides common operations with <see cref="Hashtable"/> instances as extension methods.
    /// </summary>
    public static class HashTableExtensions
    {
        /// <summary>
        /// Converts a target dictionary into an instance of <see cref="Hashtable"/>.
        /// </summary>
        /// <param name="dictionary">The target dictionary for conversion.</param>
        public static Hashtable ToHashTable(this IDictionary dictionary)
        {
            return new Hashtable(dictionary);
        }

        /// <summary>
        /// Converts a target dictionary into an instance of <see cref="Hashtable"/>.
        /// </summary>
        /// <param name="dictionary">The target dictionary for conversion.</param>
        public static Hashtable ToHashTable<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new Hashtable().Pipe(x => dictionary.ForEach(y => x.Add(y.Key, y.Value)));
        }
    }
}
