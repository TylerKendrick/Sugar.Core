using System;

namespace Sugar.Observables
{
    /// <summary>
    /// Provides methods that invert the relationship between disposables and using blocks.
    /// </summary>
    public static class DisposableExtensions
    {
        /// <summary>
        /// Wraps a disposable object in a using block for execution.
        /// </summary>
        /// <typeparam name="T">The type of disposable.</typeparam>
        /// <param name="self">The target disposable to be disposed.</param>
        /// <param name="action">The action to execute before disposing.</param>
        public static void Using<T>(this T self, Action<T> action)
            where T : IDisposable
        {
            using (self)
            {
                action(self);
            }
        }

        /// <summary>
        /// Wraps a disposable object in a using block for execution.
        /// </summary>
        /// <typeparam name="TIn">The type of disposable.</typeparam>
        /// <typeparam name="TOut">The type of object being returned from the disposable.</typeparam>
        /// <param name="self">The target disposable to be disposed.</param>
        /// <param name="func">The action to execute before disposing.</param>
        /// <returns>The result of the function.</returns>
        public static TOut Using<TIn, TOut>(this TIn self, Func<TIn, TOut> func)
            where TIn : IDisposable
        {
            using (self)
            {
                return func(self);
            }
        }
    }
}