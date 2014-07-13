namespace Sugar
{
    /// <summary>
    /// Negates proceeding <see cref="FluentExpression{T}"/> results.
    /// </summary>
    internal sealed class NotFluentExpression<T> : FluentExpression<T>
    {
        /// <summary>
        /// Provides a context for evaluation.
        /// </summary>
        internal NotFluentExpression(T context)
            : base(context, x => !x)
        {
        }
    }
}