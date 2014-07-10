using System;

namespace Sugar
{
    /// <summary>
    /// Treats loop operations as first class objects.
    /// </summary>
    public class Looper
    {
        protected readonly Action Action;

        /// <summary>
        /// Wraps an action in a looper object.
        /// </summary>
        /// <param name="action">The required action to wrap.</param>
        public Looper(Action action)
        {
            action.Require();
            Action = action;
        }

        /// <summary>
        /// Invokes the action once.
        /// </summary>
        public void Raise()
        {
            Action();
        }

        /// <summary>
        /// Executes the action while the predicate is true.
        /// </summary>
        /// <param name="predicate">The condition for looping.</param>
        public void While(Func<bool> predicate)
        {
            while (predicate())
            {
                Action();
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
                Action();
            }
        }

        /// <summary>
        /// Executes the action a set number of times.
        /// </summary>
        /// <param name="count">The number of times to execute the action.</param>
        public void Times(int count)
        {
            Require.That(count, Is.GreaterThan(0));
            for (var i = 0; i < count; i++)
            {
                Action();
            }
        }
    }
}