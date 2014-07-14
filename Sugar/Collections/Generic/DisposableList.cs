using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sugar.Observables;

namespace Sugar.Collections.Generic
{
    /// <summary>
    /// Creates an instance of <see cref="IDisposableList{T}"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public class DisposableList<T> : IDisposableList<T>
    {
        private readonly IList<T> _handle = new List<T>(); 

        public IEnumerator<T> GetEnumerator()
        {
            return _handle.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add to the end of the collection.</param>
        /// <returns>Returns a <see cref="Disposable{T}"/> object that removes itself from the collection once Dispose is called.</returns>
        /// <remarks>
        /// <example>
        /// <code>var disposable = list.Add(new T());</code>
        /// <code>disposable.Dispose();</code>
        /// </example>
        /// </remarks>
        public IDisposable Add(T item)
        {
            _handle.Add(item);
            return new Disposable<T>(item, x => _handle.Remove(x.Value));
        }

        /// <summary>
        /// Adds items to the collection.
        /// </summary>
        /// <param name="items">The items to add to the end of the collection.</param>
        /// <returns>Returns an <see cref="IEnumerable{Disposable{T}}"/> object that removes themselves from the collection once Dispose is called.</returns>
        public IDictionary<T, IDisposable> Add(params T[] items)
        {
            return items.ToDictionary(x => x, Add);
        }
    }
}
