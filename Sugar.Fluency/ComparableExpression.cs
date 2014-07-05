using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sugar
{
    /// <summary>
    /// Provides a new instance of a <see cref="ConditionalExpression{T}"/> for expressions common to all object types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ComparableExpression<T>
    {
        protected readonly T Context;
        protected readonly Func<bool, bool> Evaluate;
        private readonly Lazy<ConditionalExpression<T>> _default;

        /// <summary>
        /// Returns an expression that evaluates as true if the context provided for the condition is equal to <code>default(T)</code>.
        /// </summary>
        public ConditionalExpression<T> Default { get { return _default.Value; } } 

        /// <summary>
        /// Uses a specified context and predicate to provide context and offset the evaluation of proceeding expressions.
        /// </summary>
        /// <param name="context">The object context for evaluation.</param>
        /// <param name="evaluate">The offset predicate.  Returns an identity function (x => x) if null.</param>
        public ComparableExpression(T context, Func<bool, bool> evaluate = null)
        {
            Context = context;
            Evaluate = evaluate ?? (x => x);
            _default = new Lazy<ConditionalExpression<T>>(() => new ConditionalExpression<T>(Context, HandleIsDefault()));
        }

        private bool HandleIsDefault()
        {
            var isEqual = RuntimeHelpers.Equals(Context, default(T));
            return Evaluate(isEqual);
        }

        /// <summary>
        /// Uses an <see cref="IEqualityComparer{T}"/> to compare object values.
        /// </summary>
        public ConditionalExpression<T> EqualTo(T comparable, IEqualityComparer<T> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
            var result = comparer.Equals(Context, comparable);
            return new ConditionalExpression<T>(Context, Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if <paramref name="comparable"/> is equivalent to the wrapped object.
        /// </summary>
        public ConditionalExpression<T> SameAs(T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(Context, comparable) == 0;
            return new ConditionalExpression<T>(Context, Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than <paramref name="comparable"/>.
        /// </summary>
        public ConditionalExpression<T> GreaterThan(T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(Context, comparable) > 0;
            return new ConditionalExpression<T>(Context, Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than <paramref name="comparable"/>.
        /// </summary>
        public ConditionalExpression<T> LessThan(T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(Context, comparable) < 0;
            return new ConditionalExpression<T>(Context, Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is within a specified range.
        /// </summary>
        public ConditionalExpression<T> Between(T start, T end, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            //The relation between start and end could be a negative range.
            //In this case, just make sure that the compare results (when added) show no difference.
            var result = comparer.Compare(Context, start) + comparer.Compare(Context, end) == 0;
            return new ConditionalExpression<T>(Context, Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than or equal to <paramref name="comparable"/>.
        /// </summary>
        public ConditionalExpression<T> AtLeast(T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(Context, comparable) >= 0;
            return new ConditionalExpression<T>(Context, Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than or equal to <paramref name="comparable"/>.
        /// </summary>
        public ConditionalExpression<T> AtMost(T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(Context, comparable) <= 0;
            return new ConditionalExpression<T>(Context, Evaluate(result));
        }
    }
}