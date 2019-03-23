using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    /// <summary>
    /// Provides a list of items that remove themselves from the collection once disposed.
    /// </summary>
    public class WeakList<T> : IList<T>
        where T : class
    {
        private readonly IList<WeakReference<T>> _weakReferences;

        private IEnumerable<T> References
        {
            get
            {
                foreach (var weakReference in _weakReferences.Where(x => x.IsAlive()))
                {
                    if (weakReference.TryGetTarget(out T reference))
                    {
                        yield return reference;
                    }
                }
            }
        }

        private IEnumerable<WeakReference<T>> DeadReferences
        {
            get
            {
                return _weakReferences.Where(x => !x.IsAlive());
            }
        }

        /// <summary>
        /// Initializes an empty collection of weak references.
        /// </summary>
        public WeakList()
        {
            _weakReferences = new List<WeakReference<T>>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Clean();
            return References.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds a specified item to the collection as a weak reference.
        /// </summary>
        public void Add(T item)
        {
            _weakReferences.Add(item.ToWeak());
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            _weakReferences.Clear();
        }

        /// <summary>
        /// Removes all dead references from the collection.
        /// Called every time an enumerator is requested.
        /// </summary>
        public void Clean()
        {
            foreach (var deadReference in DeadReferences)
            {
                _weakReferences.Remove(deadReference);
            }
        }

        /// <summary>
        /// Determines whether a sequence contains a specified element 
        /// by using the default equality comparer.
        /// </summary>
        public bool Contains(T item)
        {
            return References.Contains(item);
        }

        /// <summary>
        /// Copies all the elements of the current 
        /// one-dimensional <see cref="Array"/> to the specified 
        /// one-dimensional <see cref="Array"/> starting at the specified 
        /// destination <see cref="Array"/> index. 
        /// The index is specified as a 32-bit integer.
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex)
        {
            References.ToArray().CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes a specified item from the collection
        /// if it exists.
        /// </summary>
        /// <param name="item">The specified item to remove.</param>
        /// <returns>Indicates if removing the item was successful.</returns>
        public bool Remove(T item)
        {
            var index = IndexOf(item);
            var result = index != -1;

            if (result)
            {
                RemoveAt(index);
            }

            return result;
        }

        /// <summary>
        /// Returns the count of all references that are alive.
        /// </summary>
        public int Count { get { return References.Count(); } }

        /// <summary>
        /// Returns false for lists.
        /// </summary>
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Indicates an index of the specified item in the collection if it exists.
        /// </summary>
        /// <param name="item">The specified item to find in the collection.</param>
        /// <returns>Returns -1 if no match is found, otherwise, finds the index of the specified item.</returns>
        public int IndexOf(T item)
        {
            return References.ToList().IndexOf(item);
        }

        /// <summary>
        /// Inserts a specified item into the specified index as a weak reference.
        /// </summary>
        /// <param name="index">The specified index.</param>
        /// <param name="item">The specified item.</param>
        public void Insert(int index, T item)
        {
            _weakReferences.Insert(index, item.ToWeak());
        }

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">The specified index.</param>
        public void RemoveAt(int index)
        {
            _weakReferences.RemoveAt(index);
        }

        /// <summary>
        /// Provides accessibility to instance members of the collection.
        /// </summary>
        public T this[int index]
        {
            get { return References.ToArray().ElementAt(index); }
            set { _weakReferences[index] = value.ToWeak(); }
        }
    }
}