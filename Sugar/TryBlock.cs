namespace System
{
    using Collections.Generic;
    using Utilities;

    public partial class TryBlock : ITryBlock
    {
        private readonly Action _tryAction;
        private readonly ITryConfiguration _configuration;
        private readonly IDictionary<Type, Action<Exception>> _errors = new Dictionary<Type, Action<Exception>>();
        private readonly IList<Action> _responses = new List<Action>();

        private TryBlock(Action tryAction, ITryConfiguration configuration)
        {
            _tryAction = tryAction;
            _configuration = configuration;
        }

        /// <summary>
        /// Exposes the constructor of <see cref="TryBlock"/> as a delegate.
        /// </summary>
        public static readonly Func<Action, ITryConfiguration, ITryBlock> Create =
            (action, configuration) => new TryBlock(action, configuration);

        /// <summary>
        /// Invokes the try block with the specified configurations.
        /// </summary>
        public IResult Raise()
        {
            bool shouldRetry;
            var success = true;
            IInvocationResult result;

            do
            {
                Exception exception = null;

                try
                {
                    _tryAction();
                }
                catch (Exception e)
                {
                    exception = e;
                    success = false;
                    HandleCatchBlock(e);
                }
                finally
                {
                    result = HandleFinallyBlock(success, exception);
                    shouldRetry = _configuration.ShouldRetry(result);
                }
            } while (shouldRetry && success == false);
            return result;
        }

        private IInvocationResult HandleFinallyBlock(bool success, Exception exception)
        {
            _responses.ForEach(x => x.Raise());
            return InvocationResult.Create(success, exception);
        }

        private void HandleCatchBlock(Exception e)
        {
            var key = e.GetType();
            if (_errors.ContainsKey(key))
            {
                _errors[key].Raise(e);
            }
        }

        /// <summary>
        /// Configures the execution block to handle execution failure 
        /// when an exception of type <typeparamref name="TException"/> is thrown.
        /// </summary>
        /// <typeparam name="TException">The kind of exception to handle.</typeparam>
        public ITryBlock Catch<TException>(Action<TException> onException) 
            where TException : Exception
        {
            _errors.Add(typeof(TException), e => onException(e.Cast<TException>()));
            return this;
        }

        /// <summary>
        /// Configures the execution block to execute specified actions regardless of the state of execution.
        /// </summary>
        public IBlock Finally(Action onComplete)
        {
            _responses.Add(onComplete);
            return this;
        }
    }
}