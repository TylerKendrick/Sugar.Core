namespace System.Collections.Generic
{
    using Specialized;
    using Linq;
    /// <summary>
    /// Provides extensions allowing for simple conversion to and from the generic <see cref="IDictionary"/> type.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Provides a parameterless conversion for KeyValuePair collections to a dictionary.
        /// </summary>
        /// <typeparam name="TKey">The Key of a dictionary item.</typeparam>
        /// <typeparam name="TValue">The Value of a dictionary item.</typeparam>
        /// <param name="self">The target collection to convert into a Dictionary.</param>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> self)
            => self.ToDictionary(x => x.Key, x => x.Value);

        /// <summary>
        /// Converts a <see cref="NameValueCollection"/> instance into an instance of a <see cref="IDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <param name="nameValueCollection">The target collection for conversion.</param>
        public static IDictionary<string, string> ToDictionary(this NameValueCollection nameValueCollection)
            => nameValueCollection.AllKeys.ToDictionary(Lambda.Identity, x => nameValueCollection[x]);

        /// <summary>
        /// Converts a specified string dictionary into an instance of a <see cref="NameValueCollection"/>.
        /// </summary>
        /// <param name="dictionary">The specified dictionary for conversion.</param>
        public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> dictionary)
            => new NameValueCollection().Pipe(x => dictionary.ForEach(y => x.Add(y.Key, y.Value)));

        /// <summary>
        /// Simplifies working with dictionaries when adding a type of <see cref="KeyValuePair{TKey, TValue}"/>.
        /// </summary>
        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            KeyValuePair<TKey, TValue> keyValuePair) => dictionary.Add(keyValuePair.Key, keyValuePair.Value);
    }
}