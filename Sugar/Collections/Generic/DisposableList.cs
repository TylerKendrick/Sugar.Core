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

        public IDisposable Add(T item)
        {
            _handle.Add(item);
            return new Disposable<T>(item, x => _handle.Remove(x.Value));
        }

        public IEnumerable<IDisposable> Add(params T[] items)
        {
            return items.Select(Add);
        }
    }
}
