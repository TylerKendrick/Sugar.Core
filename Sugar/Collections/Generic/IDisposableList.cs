using System;
using System.Collections.Generic;
using Sugar.Observables;

namespace Sugar.Collections.Generic
{
    /// <summary>
    /// Provides a list of items that remove themselves from the collection once disposed.
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public interface IDisposableList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add to the end of the collection.</param>
        /// <returns>Returns a <see cref="Disposable{T}"/> object that removes itself from the collection once Dispose is called.</returns>
        IDisposable Add(T item);

        /// <summary>
        /// Adds items to the collection.
        /// </summary>
        /// <param name="items">The items to add to the end of the collection.</param>
        /// <returns>Returns an <see cref="IEnumerable{Disposable{T}}"/> object that removes themselves from the collection once Dispose is called.</returns>
        IEnumerable<IDisposable> Add(params T[] items);
    }
}