using System;

namespace Sugar
{
    /// <summary>
    /// Provides predicate comparable expressions for fluent evaluation.
    /// </summary>
    /// <typeparam name="T">The kind of object being used for evaluation.</typeparam>
    public class ConditionalExpression<T>
    {
        private readonly bool? _offset;
        private readonly Lazy<NotComparableExpression<T>> _not;
        private readonly Lazy<AndComparableExpression<T>> _and;
        private readonly Lazy<OrComparableExpression<T>> _or;

        /// <summary>
        /// Negates the preceeding comparable expressions during evaluation.
        /// </summary>
        public NotComparableExpression<T> Not { get { return _not.Value; } }
        /// <summary>
        /// Compounds the preceeding comparable expressions during evaluation.
        /// </summary>
        public AndComparableExpression<T> And { get { return _and.Value; } }
        /// <summary>
        /// Substitutes preceeding comparables epressions that evaluate to false.
        /// </summary>
        public OrComparableExpression<T> Or { get { return _or.Value; } }

        /// <summary>
        /// Optionally offsets the proceeding comparable expressions with a seed value from <paramref name="offset"/>.
        /// </summary>
        public ConditionalExpression(T handle, bool? offset = null)
        {
            _offset = offset;
            _not = new Lazy<NotComparableExpression<T>>(() => new NotComparableExpression<T>(handle));
            _and = new Lazy<AndComparableExpression<T>>(() => new AndComparableExpression<T>(handle, (!offset.HasValue || offset.Value)));
            _or = new Lazy<OrComparableExpression<T>>(() => new OrComparableExpression<T>(handle, (offset.HasValue && offset.Value)));
        }

        /// <summary>
        /// Evaluates the expression tree and returns the result as a single bool.
        /// </summary>
        public static implicit operator bool(ConditionalExpression<T> handle)
        {
            var result = handle._offset;
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