namespace System
{
    /// <summary>
    /// Provides predicate comparable expressions for fluent evaluation.
    /// </summary>
    public class FluentPredicate<T> : IFluentPredicate<T>
    {
        T IFluentPredicate<T, FluentExpression<T>, LogicalFluentExpression<T>>.Context { get { return Context; } }
        protected readonly T Context;
        protected readonly bool? Offset;

        private LogicalFluentExpression<T> _orExpression;
        private LogicalFluentExpression<T> _andExpression;
        private FluentExpression<T> _notExpression;

        /// <summary>
        /// Negates the preceeding comparable expressions during evaluation.
        /// </summary>
        public FluentExpression<T> Not { get { return CreateNotExpression(Context, Offset); } }

        /// <summary>
        /// Compounds the preceeding comparable expressions during evaluation.
        /// </summary>
        public LogicalFluentExpression<T> And { get { return CreateAndExpression(Context, Offset); } }

        /// <summary>
        /// Substitutes preceeding comparables epressions that evaluate to false.
        /// </summary>
        public LogicalFluentExpression<T> Or { get { return CreateOrExpression(Context, Offset); } }

        /// <summary>
        /// Optionally offsets the proceeding comparable expressions with a seed value from <paramref name="offset"/>.
        /// </summary>
        internal FluentPredicate(T context, bool? offset = null)
        {
            Context = context;
            Offset = offset;
        }
 
        /// <summary>
        /// Creates an instance of <see cref="OrFluentExpression{T}"/>.
        /// </summary>
        protected LogicalFluentExpression<T> CreateOrExpression(T handle, bool? offset)
        {
            return _orExpression ??
                   (_orExpression = new OrFluentExpression<T>(handle, (offset.HasValue && offset.Value)));
        }

        /// <summary>
        /// Creates an instance of <see cref="AndFluentExpression{T}"/>.
        /// </summary>
        protected LogicalFluentExpression<T> CreateAndExpression(T handle, bool? offset)
        {
            return _andExpression ??
                   (_andExpression = new AndFluentExpression<T>(handle, (!offset.HasValue || offset.Value)));
        }

        /// <summary>
        /// Creates an instance of <see cref="NotFluentExpression{T}"/>.
        /// </summary>
        protected FluentExpression<T> CreateNotExpression(T handle, bool? offset)
        {
            return _notExpression ?? (_notExpression = new NotFluentExpression<T>(handle));
        }

        /// <summary>
        /// Syntatic sugar that invokes the Resolve method.
        /// </summary>
        public static implicit operator bool(FluentPredicate<T> handle)
        {
            return handle.Resolve();
        }

        /// <summary>
        /// Exposes the offset value of the <see cref="FluentPredicate{T}"/> instance.
        /// </summary>
        public bool Resolve()
        {
            return Offset.GetValueOrDefault();
        }
    }
}