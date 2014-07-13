namespace Sugar
{
    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    internal class It<T> : IIt<T> 
    {
        /// <summary>
        /// Provides predicate expressions through an instance of a subclass of <see cref="IsFluentExpression{T}"/>.
        /// </summary>
        public IIsFluentExpression<T> Is { get; private set; }

        /// <summary>
        /// Provides the context to wrap.
        /// </summary>
        internal It(T context)
        {
            Is = new IsFluentExpression<T>(context);
        }
    }
}