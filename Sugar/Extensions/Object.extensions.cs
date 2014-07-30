using System.Linq.Expressions;

namespace System
{
    /// <summary>
    /// Provides common operations with base <see cref="Object"/> instances as extension methods.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Attempts to cast a value to a specified type with an optional fallback value.
        /// </summary>
        public static T Cast<T>(this object self, T fallbackValue = default(T))
        {
            return self is T ? (T)self : fallbackValue;
        }

        /// <summary>
        /// Exposes Conver.ChangeType as an extension method with an optional fallback value.
        /// </summary>
        public static TOut ConvertTo<TOut>(this object self, TOut fallbackValue = default(TOut))
        {
            return Convert.ChangeType(self, typeof (TOut)).Cast(fallbackValue);
        }

        /// <summary>
        /// Throws an expcetion of the provided predicate fails.
        /// </summary>
        public static void Require<T>(this T self, Func<T, bool> predicate)
        {
            System.Require.That(self, predicate);
        }

        /// <summary>
        /// Executes an action on the caller and returns the caller.
        /// </summary>
        public static T Pipe<T>(this T self, Action<T> action)
        {
            System.Require.That(action != null);
            action(self);
            return self;
        }

        /// <summary>
        /// Exposes the maybe monad as an extension method.
        /// Allows for cascading member expressions to return a potentially null value.
        /// </summary>
        public static IOption<TOut> Maybe<TIn, TOut>(this TIn self, Expression<Func<TIn, TOut>> selector)
        {
            return Option<TIn>.Maybe(self, selector);
        }
    }
}