namespace System
{
    using Utilities;

    /// <summary>
    /// Used to provide fluent conditional invocations.
    /// </summary>
    public class When : IBlock
    {
        private readonly Func<bool> _predicate;
        private readonly Action _action;
        private Otherwise _otherwise;

        /// <summary>
        /// Wraps an action and predicate.
        /// </summary>
        internal When(Action action, Func<bool> predicate)
        {
            action.Require();
            predicate.Require();

            _action = action;
            _predicate = predicate;
        }

        /// <summary>
        /// Provides the else and else-if equivalent.
        /// </summary>
        /// <param name="other">Wraps the method for invocation if the predicate is false.</param>
        /// <returns>When the predicate is true, it returns the original action, otherwise, it returns the "other" provided parameter.</returns>
        public Otherwise Otherwise(Action other)
        {
            return _otherwise = new Otherwise(_action, other, () => !_predicate());
        }

        /// <summary>
        /// Invokes the chain of predicates built the the when/otherwise chain.
        /// </summary>
        public IResult Raise()
        {
            var success = _predicate();

            if (success)
            {
                _action();
            }
            else if (_otherwise != null)
            {
                _otherwise.Raise();
            }

            return Result.Create(success);
        }

        /// <summary>
        /// Exposes the Raise method as an action.
        /// </summary>
        public Action ToAction() => () => Raise();

        /// <summary>
        /// Invokes ToAction
        /// </summary>
        public static implicit operator Action(When operand)
            => operand.ToAction();
    }
}