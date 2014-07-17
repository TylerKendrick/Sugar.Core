namespace System
{
    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    public interface IIt<T>
    {
        /// <summary>
        /// Provides predicate expressions through an instance of a subclass of <see cref="IsFluentExpression{T}"/>.
        /// </summary>
        IIsFluentExpression<T> Is { get; }
    }
}