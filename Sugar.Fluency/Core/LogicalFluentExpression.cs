using System;

namespace Sugar
{
    /// <summary>
    /// Provides an <see cref="IsFluentExpression{T}"/> for access to the <see cref="NotFluentExpression{T}"/> property.
    /// </summary>
    public class LogicalFluentExpression<T> : FluentExpression<T>, ILogicalFluentExpression<T>
    {
        /// <summary>
        /// Provides access to the <see cref="NotFluentExpression{T}"/> property.
        /// </summary>
        public IsFluentExpression<T> Is { get { return new IsFluentExpression<T>(Context); } } 

        /// <summary>
        /// Used to create a new instance of an <see cref="IsFluentExpression{T}"/> object.
        /// </summary>
        internal LogicalFluentExpression(T context, Func<bool, bool> evaluate)
            : base(context, evaluate)
        {
        }
    }
}