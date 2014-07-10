using System;

namespace Sugar
{
    /// <summary>
    /// Provides fluent run-time assertions against <see cref="ConditionalExpression{T}"/> objects.
    /// </summary>
    public static class Require
    {
        /// <summary>
        /// Provides an explicit fluent assertion against a specified <see cref="ConditionalExpression{T}"/>.
        /// </summary>
        public static void That<T>(T instance, Func<It<T>, ConditionalExpression<T>> predicate)
        {
            instance.Require(predicate);
        }
    }
}