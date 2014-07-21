using System.Collections.Generic;
using System.Linq;

namespace System.Collections
{
    public static class HashTableExtensions
    {
        public static Hashtable ToHashTable(this IDictionary dictionary)
        {
            return new Hashtable(dictionary);
        }
        public static Hashtable ToHashTable<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new Hashtable().Pipe(x => dictionary.ForEach(y => x.Add(y.Key, y.Value)));
        }
    }
}
