namespace System.Utilities
{
    internal class TryConfiguration : ITryConfiguration
    {
        private readonly Func<IInvocationResult, bool> _shouldRetry;
        private readonly Func<bool, Exception, IResult> _generateResult;

        public TryConfiguration(Func<IInvocationResult, bool> shouldRetry, 
            Func<bool, Exception, IResult> generateResult)
        {
            _shouldRetry = shouldRetry;
            _generateResult = generateResult;
        }

        public bool ShouldRetry(IInvocationResult result)
        {
            return _shouldRetry(result);
        }

        public IResult GenerateResult(bool success, Exception exception)
        {
            return _generateResult(success, exception);
        }
    }
}