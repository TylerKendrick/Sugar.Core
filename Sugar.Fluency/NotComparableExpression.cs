namespace Sugar
{
    /// <summary>
    /// Negates proceeding <see cref="ComparableExpression{T}"/> results.
    /// </summary>
    internal sealed class NotComparableExpression<T> : ComparableExpression<T>
    {
        /// <summary>
        /// Provides a context for evaluation.
        /// </summary>
        internal NotComparableExpression(T context)
            : base(context, x => !x)
        {
        }
    }
}