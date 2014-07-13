namespace Sugar
{
    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    public interface IIsFluentExpression<T, out TConditional> : IFluentExpression<T, TConditional> 
        where TConditional : IFluentPredicate<T>
    {
        /// <summary>
        /// Negates the following comparable expressions.
        /// </summary>
        FluentExpression<T> Not();

        /// <summary>
        /// Determines if the context of the expression is contained within a collection.
        /// </summary>
        TConditional In(params T[] collection);
    }

    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    public interface IIsFluentExpression<T> : IFluentExpression<T>, IIsFluentExpression<T, FluentPredicate<T>>
    {
    }
}