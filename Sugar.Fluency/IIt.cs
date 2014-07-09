namespace Sugar
{
    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    public interface IIt<T, out TIs, TConditional> 
        where TIs : IIsComparableExpression<T, TConditional> 
        where TConditional : IConditionalExpression<T>
    {
        /// <summary>
        /// Provides predicate expressions through an instance of a subclass of <see cref="IsComparableExpression{T}"/>.
        /// </summary>
        TIs Is { get; }
    }

    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    public interface IIt<T, out TIs> : IIt<T, TIs, ConditionalExpression<T>> 
        where TIs : IIsComparableExpression<T, ConditionalExpression<T>>
    {
    }
}