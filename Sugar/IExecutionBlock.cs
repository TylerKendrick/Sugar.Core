using System;

namespace Sugar
{
    public interface IExecutionBlock : IBlock
    {
        IExecutionBlock Catch<TException>(Action<TException> onException)
            where TException : Exception;

        IBlock Finally(Action onComplete);
    }
}