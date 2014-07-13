using System.Collections.Generic;

namespace Sugar
{
    /// <summary>
    /// Provides a new instance of a <see cref="FluentPredicate{T}"/> for expressions common to all object types.
    /// </summary>
    public interface IFluentExpression<T>
    {
        /// <summary>
        /// Returns an expression that evaluates as true if the context provided for the condition is equal to <code>default(T)</code>.
        /// </summary>
        FluentPredicate<T> Default();

        /// <summary>
        /// Uses an <see cref="IEqualityComparer{T}"/> to compare object values.
        /// </summary>
        FluentPredicate<T> EqualTo(T comparable, IEqualityComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if <paramref name="comparable"/> is equivalent to the wrapped object.
        /// </summary>
        FluentPredicate<T> SameAs(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than <paramref name="comparable"/>.
        /// </summary>
        FluentPredicate<T> GreaterThan(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than <paramref name="comparable"/>.
        /// </summary>
        FluentPredicate<T> LessThan(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is within a specified range.
        /// </summary>
        FluentPredicate<T> Between(T start, T end, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than or equal to <paramref name="comparable"/>.
        /// </summary>
        FluentPredicate<T> AtLeast(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than or equal to <paramref name="comparable"/>.
        /// </summary>
        FluentPredicate<T> AtMost(T comparable, IComparer<T> comparer = null);

        T Context { get; }
    }
}