using System.Collections.Generic;

namespace Sugar
{
    /// <summary>
    /// Provides a new instance of a <see cref="FluentPredicate{T}"/> for expressions common to all object types.
    /// </summary>
    public interface IFluentExpression<T, out TPredicate>
        where TPredicate : IFluentPredicate<T>
    {
        /// <summary>
        /// Returns an expression that evaluates as true if the context provided for the condition is equal to <code>default(T)</code>.
        /// </summary>
        TPredicate Default();

        /// <summary>
        /// Uses an <see cref="IEqualityComparer{T}"/> to compare object values.
        /// </summary>
        TPredicate EqualTo(T comparable, IEqualityComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if <paramref name="comparable"/> is equivalent to the wrapped object.
        /// </summary>
        TPredicate SameAs(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than <paramref name="comparable"/>.
        /// </summary>
        TPredicate GreaterThan(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than <paramref name="comparable"/>.
        /// </summary>
        TPredicate LessThan(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is within a specified range.
        /// </summary>
        TPredicate Between(T start, T end, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than or equal to <paramref name="comparable"/>.
        /// </summary>
        TPredicate AtLeast(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than or equal to <paramref name="comparable"/>.
        /// </summary>
        TPredicate AtMost(T comparable, IComparer<T> comparer = null);

        T Context { get; }
    }

    /// <summary>
    /// Provides a new instance of a <see cref="FluentPredicate{T}"/> for expressions common to all object types.
    /// </summary>
    public interface IFluentExpression<T> : IFluentExpression<T, FluentPredicate<T>>
    {
    }
}