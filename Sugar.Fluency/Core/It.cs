
namespace Sugar
{
    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    internal class It<T> : IIt<T> 
    {
        private readonly T _context;

        /// <summary>
        /// Provides predicate expressions through an instance of a subclass of <see cref="IsFluentExpression{T}"/>.
        /// </summary>
        public IIsFluentExpression<T> Is
        {
            get { return new IsFluentExpression<T>(_context); }
        }

        /// <summary>
        /// Provides the context to wrap.
        /// </summary>
        internal It(T context)
        {
            _context = context;
        }
    }
}