namespace System
{
    /// <summary>
    /// Wraps Try/Catch/Finally invocation blocks to allow catch blocks to be passed around and handled externally.
    /// </summary>
    public interface ITryBlock : IBlock
    {
        /// <summary>
        /// Configures the execution block to handle execution failure when an exception of type <typeparamref name="TException"/> is thrown.
        /// </summary>
        /// <typeparam name="TException">The kind of exception to handle.</typeparam>
        ITryBlock Catch<TException>(Action<TException> onException)
            where TException : Exception;

        /// <summary>
        /// Configures the execution block to execute specified actions regardless of the state of execution.
        /// </summary>
        IBlock Finally(Action onComplete);
    }
}