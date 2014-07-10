using System.Collections.Generic;

namespace Sugar
{
    /// <summary>
    /// Provides a new instance of a <see cref="ConditionalExpression{T}"/> for expressions common to all object types.
    /// </summary>
    public interface IComparableExpression<T, out TConditional>
        where TConditional : IConditionalExpression<T>
    {
        /// <summary>
        /// Returns an expression that evaluates as true if the context provided for the condition is equal to <code>default(T)</code>.
        /// </summary>
        TConditional Default();

        /// <summary>
        /// Uses an <see cref="IEqualityComparer{T}"/> to compare object values.
        /// </summary>
        TConditional EqualTo(T comparable, IEqualityComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if <paramref name="comparable"/> is equivalent to the wrapped object.
        /// </summary>
        TConditional SameAs(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than <paramref name="comparable"/>.
        /// </summary>
        TConditional GreaterThan(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than <paramref name="comparable"/>.
        /// </summary>
        TConditional LessThan(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is within a specified range.
        /// </summary>
        TConditional Between(T start, T end, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than or equal to <paramref name="comparable"/>.
        /// </summary>
        TConditional AtLeast(T comparable, IComparer<T> comparer = null);

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than or equal to <paramref name="comparable"/>.
        /// </summary>
        TConditional AtMost(T comparable, IComparer<T> comparer = null);        
    }

    /// <summary>
    /// Provides a new instance of a <see cref="ConditionalExpression{T}"/> for expressions common to all object types.
    /// </summary>
    public interface IComparableExpression<T> : IComparableExpression<T, ConditionalExpression<T>>
    {
    }
}