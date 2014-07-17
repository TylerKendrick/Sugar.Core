namespace System
{
    /// <summary>
    /// Wraps Try/Catch/Finally invocation blocks to allow catch blocks to be passed around and handled externally.
    /// </summary>
    public interface IExecutionBlock : IBlock
    {
        IExecutionBlock Catch<TException>(Action<TException> onException)
            where TException : Exception;

        IBlock Finally(Action onComplete);
    }
}