namespace System.Utilities
{
    internal class InvocationResult : IInvocationResult
    {
        public bool Success { get; private set; }
        public Exception Exception { get; private set; }

        private InvocationResult(bool success, Exception exception)
        {
            Exception = exception;
            Success = success;
        }

        public static readonly Func<bool, Exception, IInvocationResult> Create = 
            (success, exception) => new InvocationResult(success, exception);
    }
}