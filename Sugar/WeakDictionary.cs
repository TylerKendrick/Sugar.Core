using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    /// <summary>
    /// Provides a dictionary with weak references to the values.
    /// </summary>
    public class WeakDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        where TValue : class
    {
        private readonly IDictionary<TKey, WeakReference<TValue>> _weakReferences;

        /// <summary>
        /// Creates a new instances of a dictionary with weak references for values.
        /// </summary>
        public WeakDictionary() => _weakReferences = new Dictionary<TKey, WeakReference<TValue>>();

        private IEnumerable<KeyValuePair<TKey, TValue>> References
        {
            get
            {
                foreach (var weakReference in _weakReferences.Where(x => x.Value.IsAlive()))
                {
                    if (weakReference.Value.TryGetTarget(out TValue value))
                    {
                        yield return new KeyValuePair<TKey, TValue>(weakReference.Key, value);
                    }
                }
            }
        }

        private IEnumerable<KeyValuePair<TKey, WeakReference<TValue>>> DeadReferences
            => _weakReferences.Where(x => !x.Value.IsAlive());

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            Purge();
            return References.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(KeyValuePair<TKey, TValue> item) => _weakReferences.Add(item.Key, item.Value.ToWeak());

        public void Clear() => _weakReferences.Clear();

        /// <summary>
        /// Removes all entries where a value had a dead weak reference.
        /// </summary>
        /// <returns>Returns true if all members of the collection could successfully be removed.</returns>
        public bool Purge() => DeadReferences.Aggregate(true,
            (current, deadReference) =>
                current && _weakReferences.Remove(deadReference));

        public bool Contains(KeyValuePair<TKey, TValue> item)
            => References.Any(x => x.Key.Equals(item.Key) && x.Value.Equals(item.Value));

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            var items = References.ToArray();
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var result = _weakReferences.Any(x => x.Key.Equals(item.Key) && x.Value.Equals(item.Value));
            return result ? _weakReferences.Remove(item.Key) : result;
        }

        public int Count => References.Count();
        public bool IsReadOnly => false;

        public bool ContainsKey(TKey key) => _weakReferences.ContainsKey(key);

        public void Add(TKey key, TValue value) => _weakReferences.Add(key, value.ToWeak());

        public bool Remove(TKey key) => _weakReferences.Remove(key);

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (_weakReferences.TryGetValue(key, out WeakReference<TValue> weakReference) && weakReference.TryGetTarget(out value))
            {
                return true;
            }
            value = default;
            return false;
        }

        private IDictionary<TKey, TValue> Dictionary
            => References.ToDictionary(x => x.Key, x => x.Value);

        public TValue this[TKey key]
        {
            get => Dictionary[key];
            set => _weakReferences[key] = value.ToWeak();
        }

        public ICollection<TKey> Keys => Dictionary.Keys;

        public ICollection<TValue> Values => Dictionary.Values;
    }
}