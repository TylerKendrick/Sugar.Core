namespace System
{
    /// <summary>
    /// Provides simplified loop conditions.
    /// </summary>
    public static class Loop
    {
        /// <summary>
        /// Provides a wrapper for do-while loops to provide consistent invocations.
        /// </summary>
        /// <param name="predicate">The condition provided to the while statement.</param>
        /// <param name="action">The body of the <remarks>do</remarks> loop.</param>
        public static void DoWhile(Func<bool> predicate, Action action)
        {
            predicate.Require();
            action.Require();
            do
            {
                action();
            } while (predicate());
        }

        /// <summary>
        /// Provides a wrapper for do-while loops to provide consistent invocations.
        /// Inverts the predicate conditions.
        /// </summary>
        /// <param name="predicate">The condition provided to the while statement.</param>
        /// <param name="action">The body of the <remarks>do</remarks> loop.</param>
        public static void DoUntil(Func<bool> predicate, Action action)
        {
            predicate.Require();
            action.Require();
            do
            {
                action();
            } while (!predicate());
        }

        /// <summary>
        /// Provides a wrapper for while loops to provide consistent invocations.
        /// </summary>
        /// <param name="predicate">The condition provided to the while statement.</param>
        /// <param name="action">The body of the loop.</param>
        public static void While(Func<bool> predicate, Action action)
        {
            predicate.Require();
            action.Require();
            while (predicate())
            {
                action();
            }
        }

        /// <summary>
        /// Provides a wrapper for do-while loops to provide consistent invocations.
        /// Inverts the predicate conditions.
        /// </summary>
        /// <param name="predicate">The condition provided to the while statement.</param>
        /// <param name="action">The body of the <remarks>do</remarks> loop.</param>
        public static void Until(Func<bool> predicate, Action action)
        {
            predicate.Require();
            action.Require();
            while (!predicate())
            {
                action();
            }
        }

        /// <summary>
        /// Invokes a provided action between the start and end values provided.
        /// </summary>
        /// <param name="start">The start index.</param>
        /// <param name="end">The terminating value.</param>
        /// <param name="action">The action for invocation in the loop.</param>
        public static void Times(int start, int end, Action<int> action)
        {
            Require.That(start.IsLessThan(end));
            action.Require();

            for (var i = start; i < end; i++)
            {
                action(i);
            }
        }

        /// <summary>
        /// Invokes a provided action between the start and end values provided.
        /// </summary>
        /// <param name="start">The start index.</param>
        /// <param name="end">The terminating value.</param>
        /// <param name="action">The action for invocation in the loop.</param>
        public static void Times(int start, int end, Action action)
            => Times(start, end, _ => action());

        /// <summary>
        /// Invokes a provided action between the start and end values provided.
        /// </summary>
        /// <param name="range">The start index and terminating value.</param>
        /// <param name="action">The action for invocation in the loop.</param>
        public static void Times(IRange<int> range, Action<int> action)
            => Times(range.Start, range.End, action);

        /// <summary>
        /// Invokes a provided action between the start and end values provided.
        /// </summary>
        /// <param name="range">The start index and terminating value.</param>
        /// <param name="action">The action for invocation in the loop.</param>
        public static void Times(IRange<int> range, Action action)
            => Times(range.Start, range.End, action);

        /// <summary>
        /// Invokes a provided action a set number of times.
        /// </summary>
        /// <param name="count">The number of times to invoke the action.</param>
        /// <param name="action">The action for invocation in the loop.</param>
        public static void Times(int count, Action<int> action)
            => Times(0, count, action);

        /// <summary>
        /// Invokes a provided action a set number of times.
        /// </summary>
        /// <param name="count">The number of times to invoke the action.</param>
        /// <param name="action">The action for invocation in the loop.</param>
        public static void Times(int count, Action action)
            => Times(0, count, action);
    }
}
