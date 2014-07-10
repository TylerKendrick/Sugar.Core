namespace Sugar
{
    /// <summary>
    /// Evaluates in the expression chain as a logical OR operation.
    /// </summary>
    internal sealed class OrComparableExpression<T> : LogicalComparableExpression<T>
    {
        /// <summary>
        /// Wraps the context in a new instance of <see cref="IsComparableExpression{T}"/>.
        /// </summary>
        internal OrComparableExpression(T context, bool offset = false) 
            : base(context, x => x || offset)
        {
        }
    }
}