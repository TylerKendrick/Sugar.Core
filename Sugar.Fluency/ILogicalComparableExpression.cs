namespace Sugar
{
    /// <summary>
    /// Provides an <see cref="IsComparableExpression{T}"/> for access to the <see cref="NotComparableExpression{T}"/> property.
    /// </summary>
    public interface ILogicalComparableExpression<T> : IComparableExpression<T>
    {
        /// <summary>
        /// Provides access to the <see cref="NotComparableExpression{T}"/> property.
        /// </summary>
        IsComparableExpression<T> Is { get; }
    }
}