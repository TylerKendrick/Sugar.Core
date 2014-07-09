using System;

namespace Sugar
{
    /// <summary>
    /// Provides predicate comparable expressions for fluent evaluation.
    /// </summary>
    public abstract class ConditionalExpression<T, TComparable, TLogical> : IConditionalExpression<T, TComparable, TLogical> 
        where TComparable : IComparableExpression<T> 
        where TLogical : ILogicalComparableExpression<T>, TComparable
    {
        protected readonly bool? Offset;
        private readonly Lazy<TComparable> _not;
        private readonly Lazy<TLogical> _and;
        private readonly Lazy<TLogical> _or;

        /// <summary>
        /// Negates the preceeding comparable expressions during evaluation.
        /// </summary>
        public TComparable Not { get { return _not.Value; } }

        /// <summary>
        /// Compounds the preceeding comparable expressions during evaluation.
        /// </summary>
        public TLogical And { get { return _and.Value; } }

        /// <summary>
        /// Substitutes preceeding comparables epressions that evaluate to false.
        /// </summary>
        public TLogical Or { get { return _or.Value; } }

        /// <summary>
        /// Optionally offsets the proceeding comparable expressions with a seed value from <paramref name="offset"/>.
        /// </summary>
        internal protected ConditionalExpression(T handle, bool? offset = null)
        {
            Offset = offset;
            _not = new Lazy<TComparable>(() => CreateNotExpression(handle, offset));
            _and = new Lazy<TLogical>(() => CreateAndExpression(handle, offset));
            _or = new Lazy<TLogical>(() => CreateOrExpression(handle, offset));
        }

        /// <summary>
        /// Creates an instance of <see cref="OrComparableExpression{T}"/>.
        /// </summary>
        protected abstract TLogical CreateOrExpression(T handle, bool? offset);

        /// <summary>
        /// Creates an instance of <see cref="AndComparableExpression{T}"/>.
        /// </summary>
        protected abstract TLogical CreateAndExpression(T handle, bool? offset);

        /// <summary>
        /// Creates an instance of <see cref="NotComparableExpression{T}"/>.
        /// </summary>
        protected abstract TComparable CreateNotExpression(T handle, bool? offset);
    }

    /// <summary>
    /// Provides predicate comparable expressions for fluent evaluation.
    /// </summary>
    /// <typeparam name="T">The kind of object being used for evaluation.</typeparam>
    public class ConditionalExpression<T> : ConditionalExpression<T, ComparableExpression<T>, LogicalComparableExpression<T>>, IConditionalExpression<T>
    {
        /// <summary>
        /// Optionally offsets the proceeding comparable expressions with a seed value from <paramref name="offset"/>.
        /// </summary>
        public ConditionalExpression(T handle, bool? offset = null)
            : base(handle, offset)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="OrComparableExpression{T}"/>.
        /// </summary>
        protected sealed override LogicalComparableExpression<T> CreateOrExpression(T handle, bool? offset)
        {
            return new OrComparableExpression<T>(handle, (offset.HasValue && offset.Value));
        }

        /// <summary>
        /// Creates an instance of <see cref="AndComparableExpression{T}"/>.
        /// </summary>
        protected override LogicalComparableExpression<T> CreateAndExpression(T handle, bool? offset)
        {
            return new AndComparableExpression<T>(handle, (!offset.HasValue || offset.Value));
        }

        /// <summary>
        /// Creates an instance of <see cref="NotComparableExpression{T}"/>.
        /// </summary>
        protected override ComparableExpression<T> CreateNotExpression(T handle, bool? offset)
        {
            return new NotComparableExpression<T>(handle);
        }

        /// <summary>
        /// Evaluates the expression tree and returns the result as a single bool.
        /// </summary>
        public static implicit operator bool(ConditionalExpression<T> handle)
        {
            var result = handle.Offset;
            return result.HasValue && result.Value;
        }

        /// <summary>
        /// Returns the expression as a function for evaluation.  Useful for compatibility with linq extensions.
        /// </summary>
        public static implicit operator Func<T, bool>(ConditionalExpression<T> handle)
        {
            return x => handle;
        }

        /// <summary>
        /// Returns the expression as a function for evaluation.  Useful for compatibility with linq extensions.
        /// </summary>
        public static implicit operator Predicate<T>(ConditionalExpression<T> handle)
        {
            return x => handle;
        }
    }
}