namespace Sugar
{
    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    internal class It<T> : IIt<T> 
    {
        private readonly T _context;
        private IIsFluentExpression<T> _fluentExpression; 

        /// <summary>
        /// Provides predicate expressions through an instance of a subclass of <see cref="IsFluentExpression{T}"/>.
        /// </summary>
        public IIsFluentExpression<T> Is
        {
            get { return GetExpression(); }
        }

        /// <summary>
        /// Provides the context to wrap.
        /// </summary>
        internal It(T context)
        {
            _context = context;
        }

        private IIsFluentExpression<T> GetExpression()
        {
            return _fluentExpression ?? (_fluentExpression = new IsFluentExpression<T>(_context));
        }
    }
}