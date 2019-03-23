namespace System.Utilities
{
    internal sealed class TryConfiguration : ITryConfiguration
    {
        private readonly Action _action;
        private readonly Func<IInvocationResult, bool> _shouldRetry;
        private readonly Func<bool, Exception, IResult> _generateResult;

        private TryConfiguration(Action action,
            Func<IInvocationResult, bool> shouldRetry,
            Func<bool, Exception, IResult> generateResult)
        {
            _action = action;
            _shouldRetry = shouldRetry;
            _generateResult = generateResult;
        }

        internal static readonly Func<Action, Func<IInvocationResult, bool>, Func<bool, Exception, IResult>, ITryConfiguration> Create =
            (action, shouldRetry, generateResult) => new TryConfiguration(action, shouldRetry, generateResult);

        public bool ShouldRetry(IInvocationResult result) => _shouldRetry(result);

        public IResult GenerateResult(bool success, Exception exception) =>
            _generateResult(success, exception);

        public ITryBlock Configure() => TryBlock.Create(_action, this);
    }
}