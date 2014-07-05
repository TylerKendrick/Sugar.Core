namespace Sugar
{
    /// <summary>
    /// Negates proceeding <see cref="ComparableExpression{T}"/> results.
    /// </summary>
    public class NotComparableExpression<T> : ComparableExpression<T>
    {
        /// <summary>
        /// Provides a context for evaluation.
        /// </summary>
        public NotComparableExpression(T context)
            : base(context, x => !x)
        {
        }
    }
}