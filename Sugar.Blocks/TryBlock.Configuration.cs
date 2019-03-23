namespace System
{
    using Utilities;
    /// <summary>
    /// Provides a fluent wrapper to invert control over try/catch/finally blocks.
    /// </summary>
    public sealed partial class TryBlock
    {
        /// <summary>
        /// Provides some default configurations for handling errors in try/catch/finally blocks.
        /// </summary>
        public static class Configuration
        {
            /// <summary>
            /// Configures the execution block to never attempt a retry.
            /// </summary>
            public static readonly Func<Action, ITryConfiguration> Default = TryConfiguration.Create
                .ApplySecond(_ => false)
                .ApplySecond(K(Result.Create));

            /// <summary>
            /// Configures the execution block to attempt a retry a specified number of times.
            /// </summary>
            public static readonly Func<Action, int, ITryConfiguration> RetryTimes = (action, count) =>
            {
                Require.That(count >= 1);
                var i = 0;
                bool predicate(IInvocationResult _) => i++ < count;

                return TryConfiguration.Create(action,
                    predicate, (o, e) => InvocationResult.Create(o, e));
            };

            /// <summary>
            /// Configures the execution block to attempt a retry whenever a specified predicate resolves as true.
            /// </summary>
            public static readonly Func<Action, Func<IInvocationResult, bool>, ITryConfiguration> RetryWhen
                = TryConfiguration.Create.ApplyThird(K(Result.Create));

            /// <summary>
            /// Configures the execution block to attempt a retry whenever a specified predicate resolves as false.
            /// </summary>
            public static readonly Func<Action, Func<IInvocationResult, bool>, ITryConfiguration> RetryUnless =
                (action, predicate) => TryConfiguration.Create(action, x => !predicate(x), K(Result.Create));

            /// <summary>
            /// Configures the execution block to always attempt to retry invocation if a failure occurred.
            /// </summary>
            public static readonly Func<Action, ITryConfiguration> RetryAlways = action =>
                TryConfiguration.Create(action, _ => true, K(Result.Create));

            private static Func<bool, Exception, IResult> K(Func<bool, IResult> func) => (b, _) => func(b);
        }
    }
}