using System.Collections.Specialized;
using System.Linq;

namespace System.Collections.Generic
{
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
        {
            return self.ToDictionary(x => x.Key, x => x.Value);
        }

        public static IDictionary<string, string> ToDictionary(this NameValueCollection nameValueCollection)
        {
            return nameValueCollection.AllKeys.ToDictionary(x => x, x => nameValueCollection[x]);
        }
        public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> dictionary)
        {
            return new NameValueCollection().Pipe(x => dictionary.ForEach(y => x.Add(y.Key, y.Value)));
        }
    }
}