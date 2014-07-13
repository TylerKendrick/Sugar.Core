namespace Sugar
{
    /// <summary>
    /// Evaluates in the expression chain as a logical OR operation.
    /// </summary>
    internal sealed class OrFluentExpression<T> : LogicalFluentExpression<T>
    {
        /// <summary>
        /// Wraps the context in a new instance of <see cref="IsFluentExpression{T}"/>.
        /// </summary>
        internal OrFluentExpression(T context, bool offset = false) 
            : base(context, x => x || offset)
        {
        }
    }
}