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

        internal TryBlock(Action tryAction, ITryConfiguration configuration)
        {
            _tryAction = tryAction;
            _configuration = configuration;
        }

        /// <summary>
        /// Invokes the try block with the specified configurations.
        /// </summary>
        public IResult Raise()
        {
            bool shouldRetry;
            var success = true;
            InvocationResult result;

            do
            {
                Exception exception = null;

                try
                {
                    _tryAction();
                }
                catch (Exception e)
                {
                    success = false;
                    var key = e.GetType();
                    if (_errors.ContainsKey(key))
                    {
                        _errors[key].Raise(e);
                    }
                    exception = e;
                }
                finally
                {
                    _responses.ForEach(x => x.Raise());
                    result = new InvocationResult(success, exception);
                    shouldRetry = _configuration.ShouldRetry(result);
                }
            } while (shouldRetry && success == false);
            return result;
        }

        /// <summary>
        /// Configures the execution block to handle execution failure when an exception of type <see cref="TException"/> is thrown.
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