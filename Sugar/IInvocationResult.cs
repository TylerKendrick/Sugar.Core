namespace System
{
    /// <summary>
    /// Provides a more detailed result set from the invocation of a <see cref="TryBlock"/>.
    /// </summary>
    public interface IInvocationResult : IResult
    {
        /// <summary>
        /// A possibly null exception.
        /// </summary>
        Exception Exception { get; }
    }
}