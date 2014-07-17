namespace System
{
    using Utilities;

    public class Otherwise : IBlock
    {
        private readonly Action _action;
        private readonly Action _other;
        private readonly Func<bool> _predicate;
        private When _when;

        public Otherwise(Action action, Action other, Func<bool> predicate)
        {
            _action = action;
            _other = other;
            _predicate = predicate;
        }

        public When When(Func<bool> predicate)
        {
            return _when = new When(this, predicate);
        }

        public IResult Raise()
        {
            IResult result;

            if (_when == null)
            {
                var success = _predicate();
                if (success) _action();
                else _other();
                result = new Result(success);
            }
            else
            {
                result = _when.Raise();
            }

            return result;
        }

        public static implicit operator Action(Otherwise operand)
        {
            return () => operand.Raise();
        }
    }
}