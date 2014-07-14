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
        /// <remarks>
        /// <example>
        /// <code>var disposable = list.Add(new T());</code>
        /// <code>disposable.Dispose();</code>
        /// </example>
        /// </remarks>
        IDisposable Add(T item);

        /// <summary>
        /// Adds items to the collection.
        /// </summary>
        /// <param name="items">The items to add to the end of the collection.</param>
        /// <returns>Returns a collection of disposable wrappers that remove themselves from the collection once Dispose is called.</returns>
        IDictionary<T, IDisposable> Add(params T[] items);
    }
}