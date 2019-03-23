namespace System
{
    using Utilities;

    /// <summary>
    /// Exposes the preceding logic of a when clause.
    /// </summary>
    public class Otherwise : IBlock
    {
        private readonly Action _action;
        private readonly Action _other;
        private readonly Func<bool> _predicate;
        private When _when;

        internal Otherwise(Action action, Action other, Func<bool> predicate)
        {
            _action = action;
            _other = other;
            _predicate = predicate;
        }

        /// <summary>
        /// Exposes additional when clauses.
        /// </summary>
        public When When(Func<bool> predicate) => _when = new When(this, predicate);

        /// <summary>
        /// Invokes the chain of predicates built the when/otherwise chain.
        /// </summary>
        public IResult Raise()
        {
            IResult result;

            if (_when == null)
            {
                var success = _predicate();
                result = Result.Create(success);

                if (success) _action();
                else _other();
            }
            else
            {
                result = _when.Raise();
            }

            return result;
        }

        /// <summary>
        /// Exposes the Raise method as an action.
        /// </summary>
        public Action ToAction() => () => Raise();

        /// <summary>
        /// Invokes ToAction
        /// </summary>
        public static implicit operator Action(Otherwise operand) => operand.ToAction();
    }
}