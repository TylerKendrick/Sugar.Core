using System;

namespace Sugar
{
    /// <summary>
    /// Exposes fluent expression syntax through a static interface.
    /// </summary>
    public static class Fluent
    {
        /// <summary>
        /// Returns a new instance of <see cref="ComparableExpression{T}"/> that wraps the provided context.
        /// </summary>
        public static It<T> It<T>(T context)
        {
            return new It<T>(context);
        }

        /// <summary>
        /// Returns a new instance of <see cref="ConditionalExpression{T}"/> that wraps the provided context and executes the specified predicate.
        /// </summary>
        /// <param name="context">The context for execution of the specified parameter <paramref name="predicate"/> of type <see cref="ConditionalExpression{T}"/>.</param>
        /// <param name="predicate">The predicate for evaluation.</param>
        public static ConditionalExpression<T> It<T>(T context, Func<It<T>, ConditionalExpression<T>> predicate)
        {
            return predicate(It(context));
        }

        /// <summary>
        /// Returns a new instance of <see cref="StringIt"/> that wraps the provided context as a fluent expression.
        /// </summary>
        /// <param name="handle">The specified string to wrap for evluation of fluent expressions.</param>
        public static StringIt String(string handle)
        {
            return new StringIt(handle);
        }
    }
}