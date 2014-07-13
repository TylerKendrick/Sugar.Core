namespace Sugar
{
    /// <summary>
    /// Provides predicate comparable expressions for fluent evaluation.
    /// </summary>
    public class FluentPredicate<T> : IFluentPredicate<T>
    {
        protected readonly T Handle;
        protected readonly bool? Offset;

        /// <summary>
        /// Negates the preceeding comparable expressions during evaluation.
        /// </summary>
        public FluentExpression<T> Not { get { return CreateNotExpression(Handle, Offset); } }

        /// <summary>
        /// Compounds the preceeding comparable expressions during evaluation.
        /// </summary>
        public LogicalFluentExpression<T> And { get { return CreateAndExpression(Handle, Offset); } }

        /// <summary>
        /// Substitutes preceeding comparables epressions that evaluate to false.
        /// </summary>
        public LogicalFluentExpression<T> Or { get { return CreateOrExpression(Handle, Offset); } }

        /// <summary>
        /// Optionally offsets the proceeding comparable expressions with a seed value from <paramref name="offset"/>.
        /// </summary>
        internal FluentPredicate(T handle, bool? offset = null)
        {
            Handle = handle;
            Offset = offset;
        }

        /// <summary>
        /// Creates an instance of <see cref="OrFluentExpression{T}"/>.
        /// </summary>
        protected LogicalFluentExpression<T> CreateOrExpression(T handle, bool? offset)
        {
            return new OrFluentExpression<T>(handle, (offset.HasValue && offset.Value));
        }

        /// <summary>
        /// Creates an instance of <see cref="AndFluentExpression{T}"/>.
        /// </summary>
        protected LogicalFluentExpression<T> CreateAndExpression(T handle, bool? offset)
        {
            return new AndFluentExpression<T>(handle, (!offset.HasValue || offset.Value));
        }

        /// <summary>
        /// Creates an instance of <see cref="NotFluentExpression{T}"/>.
        /// </summary>
        protected FluentExpression<T> CreateNotExpression(T handle, bool? offset)
        {
            return new NotFluentExpression<T>(handle);
        }

        public static implicit operator bool(FluentPredicate<T> handle)
        {
            return handle.Resolve();
        }

        public bool Resolve()
        {
            return Offset.GetValueOrDefault();
        }
    }
}