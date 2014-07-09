namespace Sugar
{
    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    public interface IIsComparableExpression<T, out TConditional> : IComparableExpression<T, TConditional> 
        where TConditional : IConditionalExpression<T>
    {
        /// <summary>
        /// Negates the following comparable expressions.
        /// </summary>
        ComparableExpression<T> Not { get; }

        /// <summary>
        /// Determines if the context of the expression is contained within a collection.
        /// </summary>
        TConditional In(params T[] collection);
    }

    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    public interface IIsComparableExpression<T> : IComparableExpression<T>, IIsComparableExpression<T, ConditionalExpression<T>>
    {
    }
}