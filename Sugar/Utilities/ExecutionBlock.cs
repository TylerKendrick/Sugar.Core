using System.Collections.Generic;
using System.Linq;

namespace System.Utilities
{
    class ExecutionBlock : IExecutionBlock
    {
        private readonly Action _tryAction;
        private readonly IDictionary<Type, Action<Exception>> _errors = new Dictionary<Type, Action<Exception>>();
        private readonly IList<Action> _responses = new List<Action>();
        public ExecutionBlock(Action tryAction)
        {
            _tryAction = tryAction;
        }

        public IResult Raise()
        {
            var success = true;
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
            }
            finally
            {
                _responses.ForEach(x => x.Raise());
            }
            return new Result(success);
        }

        public IExecutionBlock Catch<TException>(Action<TException> onException) 
            where TException : Exception
        {
            _errors.Add(typeof(TException), e => onException(e.Cast<TException>()));
            return this;
        }

        public IBlock Finally(Action onComplete)
        {
            _responses.Add(onComplete);
            return this;
        }
    }
}