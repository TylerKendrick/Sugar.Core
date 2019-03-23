namespace System.Utilities
{
    internal sealed class InvocationResult : IInvocationResult
    {
        public bool Success { get; }
        public Exception Exception { get; }

        private InvocationResult(bool success, Exception exception)
        {
            Exception = exception;
            Success = success;
        }

        public static readonly Func<bool, Exception, IInvocationResult> Create =
            (success, exception) => new InvocationResult(success, exception);
    }
}