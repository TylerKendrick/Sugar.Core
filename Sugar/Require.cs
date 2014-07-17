﻿using System.Utilities;

namespace System
{
    /// <summary>
    /// Provides fluent run-time assertions against <see cref="Object"/> instances.
    /// </summary>
    public static class Require
    {
        /// <summary>
        /// Provides an explicit fluent assertion against a specified <see cref="T"/>.
        /// </summary>
        public static void That<T>(T instance, Func<T, bool> predicate)
        {
            if (!predicate(instance))
            {
                var value = predicate.ToString();
                var message = "Predicate \"{0}\" evaluated as false.";
                message = string.Format(message, value);
                var exception = Error.Argument("predicate", message);
                throw Error.Failure(message, exception);
            }
        }

        /// <summary>
        /// Provides an explicit fluent assertion against a specified condition.
        /// </summary>
        public static void That(bool condition)
        {
            That(condition, x => x);
        }
    }
}