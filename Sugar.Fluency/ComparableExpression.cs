using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sugar
{
    /// <summary>
    /// Provides a new instance of a <see cref="ConditionalExpression{T}"/> for expressions common to all object types.
    /// </summary>
    public class ComparableExpression<T> : 
        ComparableExpression<T, ConditionalExpression<T>>, 
        IComparableExpression<T>
    {
        /// <summary>
        /// Uses a specified context and predicate to provide context and offset the evaluation of proceeding expressions.
        /// </summary>
        /// <param name="context">The object context for evaluation.</param>
        /// <param name="evaluate">The offset predicate.  Returns an identity function (x => x) if null.</param>
        public ComparableExpression(T context, Func<bool, bool> evaluate = null) 
            : base(context, evaluate)
        {
        }

        /// <summary>
        /// Generates a new instance of <see cref="ConditionalExpression{T}"/> for use by subsequent expressions.
        /// </summary>
        protected override ConditionalExpression<T> GetDefaultExpression()
        {
            return new ConditionalExpression<T>(Context, HandleIsDefault());
        }

        /// <summary>
        /// Generates a new instance of <see cref="ConditionalExpression{T}"/> for use by subsequent expressions.
        /// </summary>
        protected override ConditionalExpression<T> GetConditionalExpression(bool predicate)
        {
            return new ConditionalExpression<T>(Context, predicate);
        }

        private bool HandleIsDefault()
        {
            var isEqual = RuntimeHelpers.Equals(Context, default(T));
            return Evaluate(isEqual);
        }
    }

    /// <summary>
    /// Provides a new instance of a <see cref="ConditionalExpression{T}"/> for expressions common to all object types.
    /// </summary>
    public abstract class ComparableExpression<T, TConditional> : IComparableExpression<T, TConditional> 
        where TConditional : IConditionalExpression<T>
    {
        protected readonly T Context;
        protected readonly Func<bool, bool> Evaluate;
        private readonly Lazy<TConditional> _default;

        /// <summary>
        /// Returns an expression that evaluates as true if the context provided for the condition is equal to <code>default(T)</code>.
        /// </summary>
        public TConditional Default()
        {
            return _default.Value;
        }

        /// <summary>
        /// Uses a specified context and predicate to provide context and offset the evaluation of proceeding expressions.
        /// </summary>
        /// <param name="context">The object context for evaluation.</param>
        /// <param name="evaluate">The offset predicate.  Returns an identity function (x => x) if null.</param>
        protected internal ComparableExpression(T context, Func<bool, bool> evaluate = null)
        {
            Context = context;
            Evaluate = evaluate ?? (x => x);
            _default = new Lazy<TConditional>(GetDefaultExpression);
        }

        /// <summary>
        /// Generates a new instance of <see cref="ConditionalExpression{T}"/> for use by subsequent expressions.
        /// </summary>
        protected abstract TConditional GetDefaultExpression();

        /// <summary>
        /// Generates a new instance of <see cref="ConditionalExpression{T}"/> for use by subsequent expressions.
        /// </summary>
        protected abstract TConditional GetConditionalExpression(bool predicate);
        
        /// <summary>
        /// Uses an <see cref="IEqualityComparer{T}"/> to compare object values.
        /// </summary>
        public TConditional EqualTo(T comparable, IEqualityComparer<T> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
            var result = comparer.Equals(Context, comparable);
            return GetConditionalExpression(Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if <paramref name="comparable"/> is equivalent to the wrapped object.
        /// </summary>
        public TConditional SameAs(T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(Context, comparable) == 0;
            return GetConditionalExpression(Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than <paramref name="comparable"/>.
        /// </summary>
        public TConditional GreaterThan(T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(Context, comparable) > 0;
            return GetConditionalExpression(Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than <paramref name="comparable"/>.
        /// </summary>
        public TConditional LessThan(T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(Context, comparable) < 0;
            return GetConditionalExpression(Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is within a specified range.
        /// </summary>
        public TConditional Between(T start, T end, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            //The relation between start and end could be a negative range.
            //In this case, just make sure that the compare results (when added) show no difference.
            var result = comparer.Compare(Context, start) + comparer.Compare(Context, end) == 0;
            return GetConditionalExpression(Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than or equal to <paramref name="comparable"/>.
        /// </summary>
        public TConditional AtLeast(T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(Context, comparable) >= 0;
            return GetConditionalExpression(Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than or equal to <paramref name="comparable"/>.
        /// </summary>
        public TConditional AtMost(T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(Context, comparable) <= 0;
            return GetConditionalExpression(Evaluate(result));
        }
    }
}