using System;

namespace Sugar
{
    public static partial class Is
    {
        /// <summary>
        /// Negates the proceeding expressions
        /// </summary>
        public static class Not
        {
            /// <summary>
            /// Used to determine if a specified target is null.
            /// </summary>
            /// <typeparam name="T">Any specified class type.</typeparam>
            /// <param name="it">The specified target for comparison.</param>
            /// <returns>Returns a new instance of <see cref="FluentPredicate{T}"/> that resolves to true when the specified target is null.</returns>
            public static FluentPredicate<T> Null<T>(IIt<T> it)
                where T : class
            {
                return it.Is.Not().Default();
            }

            /// <summary>
            /// Used to determine if a specified target is set to its default value.
            /// </summary>
            /// <typeparam name="T">Any specified type.</typeparam>
            /// <param name="it">The specified target for comparison.</param>
            /// <returns>Returns a new instance of <see cref="FluentPredicate{T}"/> that resolves to true when the specified target is set to its default value.</returns>
            public static FluentPredicate<T> Default<T>(IIt<T> it)
            {
                return it.Is.Not().Default();
            }

            /// <summary>
            /// Used to determine if a specified value is greater than a specified target.
            /// </summary>
            /// <typeparam name="T">The type of object for comparison.</typeparam>
            /// <param name="other">The object to evaluate against a specified target for comparison.</param>
            /// <returns>Returns a function that evaluates against the specified argument <paramref name="other"/>.</returns>
            public static Func<T, FluentPredicate<T>> GreaterThan<T>(T other)
            {
                return x => Fluent.It(x).Is.Not().GreaterThan(other);
            }

            /// <summary>
            /// Used to determine if a specified value is less than a specified target.
            /// </summary>
            /// <typeparam name="T">The type of object for comparison.</typeparam>
            /// <param name="other">The object to evaluate against a specified target for comparison.</param>
            /// <returns>Returns a function that evaluates against the specified argument <paramref name="other"/>.</returns>
            public static Func<T, FluentPredicate<T>> LessThan<T>(T other)
            {
                return x => Fluent.It(x).Is.LessThan(other);
            }
        }
    }
}
