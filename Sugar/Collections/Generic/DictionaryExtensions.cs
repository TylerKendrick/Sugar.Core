using System.Collections.Specialized;
using System.Linq;

namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public static IDictionary<string, string> ToDictionary(this NameValueCollection nameValueCollection)
        {
            return nameValueCollection.AllKeys.ToDictionary(x => x, x => nameValueCollection[(string) x]);
        }
        public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> dictionary)
        {
            return new NameValueCollection().Pipe(x => dictionary.ForEach(y => x.Add(y.Key, y.Value)));
        }
    }
}