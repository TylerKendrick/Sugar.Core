using System;

namespace Sugar.Observables
{
    /// <summary>
    /// Defines a method to release allocated resources on a wrapped object.
    /// </summary>
    /// <typeparam name="T">The wrapped object type.</typeparam>
    public interface IDisposable<out T> : IDisposable
    {
        /// <summary>
        /// The wrapped object.
        /// </summary>
        T Value { get; }
    }
}