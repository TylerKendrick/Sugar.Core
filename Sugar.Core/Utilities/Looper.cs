namespace System
{
    /// <summary>
    /// Treats loop operations as first class objects.
    /// </summary>
    public class Looper
    {
        private readonly Action _action;

        /// <summary>
        /// Wraps an action in a looper object.
        /// </summary>
        /// <param name="action">The required action to wrap.</param>
        internal Looper(Action action)
        {
            action.Require();
            _action = action;
        }

        /// <summary>
        /// Invokes the action once.
        /// </summary>
        public void Raise() => _action();

        /// <summary>
        /// Executes the action while the predicate is true.
        /// </summary>
        /// <param name="predicate">The condition for looping.</param>
        public void While(Func<bool> predicate)
        {
            while (predicate())
            {
                _action();
            }
        }

        /// <summary>
        /// Executes the action while the predicate is false.
        /// </summary>
        /// <param name="predicate">The condition for looping</param>
        public void Until(Func<bool> predicate)
        {
            while (!predicate())
            {
                _action();
            }
        }

        /// <summary>
        /// Executes the action a set number of times.
        /// </summary>
        /// <param name="count">The number of times to execute the action.</param>
        public void Times(int count)
        {
            Require.That(count.IsGreaterThan(0));
            for (var i = 0; i < count; i++)
            {
                _action();
            }
        }
    }
}