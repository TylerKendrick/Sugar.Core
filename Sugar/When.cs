using System;

namespace Sugar
{
    /// <summary>
    /// Used to provide fluent conditional invocations.
    /// </summary>
    public class When
    {
        private readonly Func<bool> _predicate;
        private readonly Action _action;
        private Otherwise _otherwise;

        /// <summary>
        /// Wraps an action and predicate.
        /// </summary>
        public When(Action action, Func<bool> predicate)
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
            return _otherwise = new Otherwise(_action, other, _predicate);
        }

        public void Raise()
        {
            Action self = this;
            self();
        }

        public static implicit operator Action(When operand)
        {
            return operand._otherwise == null
                ? () =>
                {
                    if (operand._predicate())
                    {
                        operand._action();
                    }
                }
                : (Action)operand._otherwise;
        }
    }

    public class Otherwise
    {
        private readonly Action _action;
        private readonly Action _other;
        private readonly Func<bool> _predicate;

        public Otherwise(Action action, Action other, Func<bool> predicate)
        {
            _action = action;
            _other = other;
            _predicate = predicate;
        }

        public When When(Func<bool> predicate)
        {
            return new When(this, predicate);
        }

        public void Raise()
        {
            Action self = this;
            self();
        }

        public static implicit operator Action(Otherwise operand)
        {
            return operand._predicate()
                ? operand._action
                : operand._other;
        }
    }
}