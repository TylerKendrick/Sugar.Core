using System;

namespace Sugar
{
    /// <summary>
    /// Provides fluent run-time assertions against <see cref="FluentPredicate{T}"/> objects.
    /// </summary>
    public static class Require
    {
        /// <summary>
        /// Provides an explicit fluent assertion against a specified <see cref="FluentPredicate{T}"/>.
        /// </summary>
        public static void That<T>(T instance, Func<IIt<T>, FluentPredicate<T>> predicate)
        {
            instance.Require(predicate);
        }
    }
}