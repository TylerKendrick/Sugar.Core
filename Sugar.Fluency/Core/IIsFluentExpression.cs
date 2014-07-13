namespace Sugar
{
    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    public interface IIsFluentExpression<T> : IFluentExpression<T>
    {
        /// <summary>
        /// Negates the following comparable expressions.
        /// </summary>
        FluentExpression<T> Not();

        /// <summary>
        /// Determines if the context of the expression is contained within a collection.
        /// </summary>
        FluentPredicate<T> In(params T[] collection);
    }
}