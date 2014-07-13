using System;

namespace Sugar
{
    /// <summary>
    /// Exposes fluent expression syntax through a static interface.
    /// </summary>
    public static class Fluent
    {
        /// <summary>
        /// Returns a new instance of <see cref="FluentExpression{T}"/> that wraps the provided context.
        /// </summary>
        public static IIt<T> It<T>(T context)
        {
            return new It<T>(context);
        }

        /// <summary>
        /// Returns a new instance of <see cref="FluentPredicate{T}"/> that wraps the provided context and executes the specified predicate.
        /// </summary>
        /// <param name="context">The context for execution of the specified parameter <paramref name="predicate"/> of type <see cref="FluentPredicate{T}"/>.</param>
        /// <param name="predicate">The predicate for evaluation.</param>
        public static FluentPredicate<T> It<T>(T context, Func<IIt<T>, FluentPredicate<T>> predicate)
        {
            return predicate(It(context));
        }

        /// <summary>
        /// Returns a new instance of <see cref="Sugar.It{string}"/> that wraps the provided context as a fluent expression.
        /// </summary>
        /// <param name="handle">The specified string to wrap for evluation of fluent expressions.</param>
        public static IIt<string> String(string handle)
        {
            return new It<string>(handle);
        }
    }
}