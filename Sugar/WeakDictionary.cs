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
        public WeakDictionary()
        {
            _weakReferences = new Dictionary<TKey, WeakReference<TValue>>();
        }

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
        {
            get { return _weakReferences.Where(x => !x.Value.IsAlive()); }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            Purge();
            return References.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _weakReferences.Add(item.Key, item.Value.ToWeak());
        }

        public void Clear()
        {
            _weakReferences.Clear();
        }

        /// <summary>
        /// Removes all entries where a value had a dead weak reference.
        /// </summary>
        /// <returns></returns>
        public bool Purge()
        {
            return DeadReferences.Aggregate(false,
                (current, deadReference) =>
                    current || _weakReferences.Remove(deadReference));
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return References.Any(x => x.Key.Equals(item.Key) && x.Value.Equals(item.Value));
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            var items = References.ToArray();
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var result = _weakReferences.Any(x => x.Key.Equals(item.Key) && x.Value.Equals(item.Value));
            if (result)
            {
                result = _weakReferences.Remove(item.Key);
            }
            return result;
        }

        public int Count { get { return References.Count(); } }
        public bool IsReadOnly { get { return false; } }

        public bool ContainsKey(TKey key)
        {
            return _weakReferences.ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            _weakReferences.Add(key, value.ToWeak());
        }

        public bool Remove(TKey key)
        {
            return _weakReferences.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (_weakReferences.TryGetValue(key, out WeakReference<TValue> weakReference) && weakReference.TryGetTarget(out value))
            {
                return true;
            }
            value = default;
            return false;
        }

        public TValue this[TKey key]
        {
            get { return References.ToDictionary()[key]; }
            set { _weakReferences[key] = value.ToWeak(); }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return References.ToDictionary().Keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                return References.ToDictionary().Values;
            }
        }
    }
}