namespace System
{
    /// <summary>
    /// Provides an <see cref="IsFluentExpression{T}"/> for access to the <see cref="NotFluentExpression{T}"/> property.
    /// </summary>
    public interface ILogicalFluentExpression<T> : IFluentExpression<T>
    {
        /// <summary>
        /// Provides access to the <see cref="NotFluentExpression{T}"/> property.
        /// </summary>
        IIsFluentExpression<T> Is { get; }
    }
}