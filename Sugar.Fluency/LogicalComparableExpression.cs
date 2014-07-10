using System;

namespace Sugar
{
    /// <summary>
    /// Provides an <see cref="IsComparableExpression{T}"/> for access to the <see cref="NotComparableExpression{T}"/> property.
    /// </summary>
    public class LogicalComparableExpression<T> : ComparableExpression<T>, ILogicalComparableExpression<T>
    {
        /// <summary>
        /// Provides access to the <see cref="NotComparableExpression{T}"/> property.
        /// </summary>
        public IsComparableExpression<T> Is { get { return new IsComparableExpression<T>(Context); } } 

        /// <summary>
        /// Used to create a new instance of an <see cref="IsComparableExpression{T}"/> object.
        /// </summary>
        protected internal LogicalComparableExpression(T context, Func<bool, bool> evaluate)
            : base(context, evaluate)
        {
        }
    }
}