namespace System
{
    using Utilities;

    /// <summary>
    /// Simplifies action invocation and operations.
    /// </summary>
    public static partial class ActionExtensions
    {
        /// <summary>
        /// Provides an object for conditional invocation.
        /// </summary>
        public static When When(this Action self, Func<bool> predicate)
        {
            return new When(self, predicate);
        }

        /// <summary>
        /// Provides a new <see cref="Looper"/> instances that wraps a specified <see cref="Action"/>.
        /// </summary>
        public static Looper Loop(this Action self)
        {
            return new Looper(self);
        }

        /// <summary>
        /// Wraps proceeding Catch/Finally blocks to allow passing control of blocks to other areas.
        /// </summary>
        public static IExecutionBlock Try(this Action self)
        {
            return new ExecutionBlock(self);
        }
    }
}