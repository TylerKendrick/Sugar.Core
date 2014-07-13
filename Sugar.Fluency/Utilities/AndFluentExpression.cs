namespace Sugar
{
    /// <summary>
    /// Evaluates in the expression chain as a logical AND operation.
    /// </summary>
    internal sealed class AndFluentExpression<T> : LogicalFluentExpression<T>
    {
        /// <summary>
        /// Wraps the context in a new instance of <see cref="IsFluentExpression{T}"/>.
        /// </summary>
        internal AndFluentExpression(T context, bool offset = true)
            : base(context, x => x && offset)
        {
        }
    }
}