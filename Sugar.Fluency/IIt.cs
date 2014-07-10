namespace Sugar
{
    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    public interface IIt<T>
    {
        /// <summary>
        /// Provides predicate expressions through an instance of a subclass of <see cref="IsComparableExpression{T}"/>.
        /// </summary>
        IsComparableExpression<T> Is { get; }
    }
}