using System;

namespace Sugar
{
    /// <summary>
    /// Provides an <see cref="IsComparableExpression{T}"/> for access to the <see cref="NotComparableExpression{T}"/> property.
    /// </summary>
    public abstract class LogicalComparableExpression<T> : ComparableExpression<T>
    {
        private readonly Lazy<IsComparableExpression<T>> _isExpression;

        /// <summary>
        /// Provides access to the <see cref="NotComparableExpression{T}"/> property.
        /// </summary>
        public IsComparableExpression<T> Is { get { return _isExpression.Value; } } 

        /// <summary>
        /// Used to create a new instance of an <see cref="IsComparableExpression{T}"/> object.
        /// </summary>
        protected LogicalComparableExpression(T context, Func<bool, bool> evaluate)
            : base(context, evaluate)
        {
            _isExpression = new Lazy<IsComparableExpression<T>>(() => new IsComparableExpression<T>(context));
        }
    }
}