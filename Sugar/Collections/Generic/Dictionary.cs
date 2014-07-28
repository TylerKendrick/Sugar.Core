namespace System.Collections.Generic
{
    /// <summary>
    /// Provides safe navigation and manipulation of dictionary entries.
    /// </summary>
    public static class Dictionary
    {
        /// <summary>
        /// Provides a simple method for wrapping construction of a <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        public static IDictionary<TKey, TValue> Create<TKey, TValue>()
        {
            return new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// Adds a specified key if it is not found in current instance.
        /// </summary>
        /// <param name="collection">The target dictionary.</param>
        /// <param name="key">The key to check against the dictionary KeyCollection.</param>
        /// <param name="generator">The factory method for creating the specified TValue.</param>
        /// <returns>Returns the result of <paramref name="generator"/>.</returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> collection, TKey key, Func<TValue> generator)
        {
            TValue result;
            if (collection.ContainsKey(key))
            {
                result = collection[key];
            }
            else
            {
                result = generator();
                collection.Add(key, result);
            }
            return result;
        }

        /// <summary>
        /// Inserts a new value into the dictionary if not present.
        /// Otherwise, it updates the current value under the specified key.
        /// </summary>
        /// <param name="collection">The target dictionary</param>
        /// <param name="key">The specified key the check against the target dictionary.</param>
        /// <param name="value">The specified value to add or update.</param>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> collection, TKey key, TValue value)
        {
            if (collection.ContainsKey(key))
            {
                collection[key] = value;
            }
            else
            {
                collection.Add(key, value);
            }
        }
    }
}