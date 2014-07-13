﻿namespace Sugar
{
    /// <summary>
    /// Provides an <see cref="IsFluentExpression{T}"/> for access to the <see cref="NotFluentExpression{T}"/> property.
    /// </summary>
    public interface ILogicalFluentExpression<T> : IFluentExpression<T>
    {
        /// <summary>
        /// Provides access to the <see cref="NotFluentExpression{T}"/> property.
        /// </summary>
        IsFluentExpression<T> Is { get; }
    }
}