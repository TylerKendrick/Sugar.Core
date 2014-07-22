namespace System.Collections.Generic
{
    public static class Dictionary
    {
        public static IDictionary<TKey, TValue> Create<TKey, TValue>()
        {
            return new Dictionary<TKey, TValue>();
        }

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