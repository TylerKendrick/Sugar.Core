namespace System
{
    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    internal class IsFluentExpression<T> : FluentExpression<T>, IIsFluentExpression<T>
    {
        public IFluentExpression<T> Not { get; private set; }

        /// <summary>
        /// Defines a context for evaluation.
        /// </summary>
        internal IsFluentExpression(T context) 
            : base(context)
        {
            Not = new NotFluentExpression<T>(context);
        }
    }
}