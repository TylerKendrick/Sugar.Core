namespace System
{
    using Utilities;

    /// <summary>
    /// Provides a fluent wrapper to invert control over try/catch/finally blocks.
    /// </summary>
    public partial class TryBlock
    {
        /// <summary>
        /// Provides some default configurations for handling errors in try/catch/finally blocks.
        /// </summary>
        public class Configuration
        {
            /// <summary>
            /// Configures the execution block to never attempt a retry.
            /// </summary>
            public static readonly ITryConfiguration Default = new TryConfiguration(x => false, (x, e) => new Result(x));

            /// <summary>
            /// Configures the execution block to attempt a retry a sepcified number of times.
            /// </summary>
            /// <param name="count">The specified number of time to attempt invocation.</param>
            public static ITryConfiguration RetryTimes(int count)
            {
                Require.That(count.IsAtLeast(1));
                var i = 0;
                return new TryConfiguration(
                    x => i++ < count, 
                    (x, e) => new InvocationResult(x, e));
            }

            /// <summary>
            /// Configures the execution block to attempt a retry whenever a specified predicate resolves as true.
            /// </summary>
            /// <param name="predicate">The specified predicate to determine whether an attempt to retry should be made or not.</param>
            public static ITryConfiguration RetryWhen(Func<bool> predicate)
            {
                return new TryConfiguration(x => predicate(), (b, exception) => new Result(b));
            }

            /// <summary>
            /// Configures the execution block to attempt a retry whenever a specified predicate resolves as false.
            /// </summary>
            /// <param name="predicate">The specified predicate to determine whether an attempt to retry should be made or not.</param>
            public static ITryConfiguration RetryUnless(Func<bool> predicate)
            {
                return new TryConfiguration(x => predicate() == false, (b, exception) => new Result(b));
            }

            /// <summary>
            /// Confiugures the execution block to always attempt to retry invocation if a failure occurred.
            /// </summary>
            public static readonly ITryConfiguration RetryAlways = new TryConfiguration(x => true, (x, e) => new Result(x));
        }
    }
}