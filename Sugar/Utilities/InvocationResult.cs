namespace System.Utilities
{
    internal class InvocationResult : IInvocationResult
    {
        public bool Success { get; private set; }
        public Exception Exception { get; private set; }

        public InvocationResult(bool success, Exception exception)
        {
            Exception = exception;
            Success = success;
        }
    }
}