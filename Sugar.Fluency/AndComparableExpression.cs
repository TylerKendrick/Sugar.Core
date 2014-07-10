namespace Sugar
{
    /// <summary>
    /// Evaluates in the expression chain as a logical AND operation.
    /// </summary>
    internal sealed class AndComparableExpression<T> : LogicalComparableExpression<T>
    {
        /// <summary>
        /// Wraps the context in a new instance of <see cref="IsComparableExpression{T}"/>.
        /// </summary>
        internal AndComparableExpression(T context, bool offset = true)
            : base(context, x => x && offset)
        {
        }
    }
}