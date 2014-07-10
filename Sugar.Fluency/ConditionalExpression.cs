namespace Sugar
{
    /// <summary>
    /// Provides predicate comparable expressions for fluent evaluation.
    /// </summary>
    public class ConditionalExpression<T> : IConditionalExpression<T>
    {
        protected readonly T Handle;
        protected readonly bool? Offset;

        /// <summary>
        /// Negates the preceeding comparable expressions during evaluation.
        /// </summary>
        public ComparableExpression<T> Not { get { return CreateNotExpression(Handle, Offset); } }

        /// <summary>
        /// Compounds the preceeding comparable expressions during evaluation.
        /// </summary>
        public LogicalComparableExpression<T> And { get { return CreateAndExpression(Handle, Offset); } }

        /// <summary>
        /// Substitutes preceeding comparables epressions that evaluate to false.
        /// </summary>
        public LogicalComparableExpression<T> Or { get { return CreateOrExpression(Handle, Offset); } }

        /// <summary>
        /// Optionally offsets the proceeding comparable expressions with a seed value from <paramref name="offset"/>.
        /// </summary>
        internal ConditionalExpression(T handle, bool? offset = null)
        {
            Handle = handle;
            Offset = offset;
        }

        /// <summary>
        /// Creates an instance of <see cref="OrComparableExpression{T}"/>.
        /// </summary>
        protected LogicalComparableExpression<T> CreateOrExpression(T handle, bool? offset)
        {
            return new OrComparableExpression<T>(handle, (offset.HasValue && offset.Value));
        }

        /// <summary>
        /// Creates an instance of <see cref="AndComparableExpression{T}"/>.
        /// </summary>
        protected LogicalComparableExpression<T> CreateAndExpression(T handle, bool? offset)
        {
            return new AndComparableExpression<T>(handle, (!offset.HasValue || offset.Value));
        }

        /// <summary>
        /// Creates an instance of <see cref="NotComparableExpression{T}"/>.
        /// </summary>
        protected ComparableExpression<T> CreateNotExpression(T handle, bool? offset)
        {
            return new NotComparableExpression<T>(handle);
        }

        public static implicit operator bool(ConditionalExpression<T> handle)
        {
            return handle.Offset.GetValueOrDefault();
        }
    }
}