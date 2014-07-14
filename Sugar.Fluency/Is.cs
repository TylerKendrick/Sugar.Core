using System;
using System.Collections.Generic;

namespace Sugar
{
    /// <summary>
    /// Returns Conditional expression with a closed context for evaluation of the expression.
    /// </summary>
    public static partial class Is
    {
        /// <summary>
        /// Used to determine if a specified target is null.
        /// </summary>
        /// <typeparam name="T">Any specified class type.</typeparam>
        /// <param name="target">The specified target for comparison.</param>
        /// <returns>Returns a new instance of <see cref="FluentPredicate{T}"/> that resolves to true when the specified target is null.</returns>
        public static FluentPredicate<T> Null<T>(T target)
            where T : class
        {
            return Null(Fluent.It(target));
        }

        /// <summary>
        /// Used to determine if a specified target is null.
        /// </summary>
        /// <typeparam name="T">Any specified class type.</typeparam>
        /// <param name="it">The specified target for comparison.</param>
        /// <returns>Returns a new instance of <see cref="FluentPredicate{T}"/> that resolves to true when the specified target is null.</returns>
        public static FluentPredicate<T> Null<T>(IIt<T> it)
            where T : class 
        {
            return it.Is.Null();
        }

        /// <summary>
        /// Used to determine if a specified target is set to its default value.
        /// </summary>
        /// <typeparam name="T">Any specified type.</typeparam>
        /// <param name="it">The specified target for comparison.</param>
        /// <returns>Returns a new instance of <see cref="FluentPredicate{T}"/> that resolves to true when the specified target is set to its default value.</returns>
        public static FluentPredicate<T> Default<T>(T it)
            where T : struct
        {
            return Default(Fluent.It(it));
        }

        /// <summary>
        /// Used to determine if a specified target is set to its default value.
        /// </summary>
        /// <typeparam name="T">Any specified type.</typeparam>
        /// <param name="it">The specified target for comparison.</param>
        /// <returns>Returns a new instance of <see cref="FluentPredicate{T}"/> that resolves to true when the specified target is set to its default value.</returns>
        public static FluentPredicate<T> Default<T>(IIt<T> it)
            where T : struct
        {
            return it.Is.Default();
        }

        /// <summary>
        /// Used to determine if a specified value is greater than a specified target.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <param name="other">The object to evaluate against a specified target for comparison.</param>
        /// <returns>Returns a function that evaluates against the specified argument <paramref name="other"/>.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> GreaterThan<T>(T other)
        {
            return it => it.Is.GreaterThan(other);
        }

        /// <summary>
        /// Used to determine if a specified value is greater than a specified target.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <param name="other">The object to evaluate against a specified target for comparison.</param>
        /// <param name="comparer">The comparer to use when evaluating the expression.</param>
        /// <returns>Returns a function that evaluates against the specified argument <paramref name="other"/>.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> GreaterThan<T>(T other, IComparer<T> comparer)
        {
            return it => it.Is.GreaterThan(other, comparer);
        }

        /// <summary>
        /// Used to determine if a specified value is less than a specified target.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <param name="other">The object to evaluate against a specified target for comparison.</param>
        /// <returns>Returns a function that evaluates against the specified argument <paramref name="other"/>.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> LessThan<T>(T other)
        {
            return it => it.Is.LessThan(other);
        }

        /// <summary>
        /// Used to determine if a specified value is less than a specified target.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <param name="other">The object to evaluate against a specified target for comparison.</param>
        /// <param name="comparer">The comparer to use when evaluating the expression.</param>
        /// <returns>Returns a function that evaluates against the specified argument <paramref name="other"/>.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> LessThan<T>(T other, IComparer<T> comparer)
        {
            return it => it.Is.LessThan(other, comparer);
        }

        /// <summary>
        /// Determines object equivalence.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <returns>Returns a function to evaluate against a fluent target.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> EqualTo<T>(T other)
        {
            return it => it.Is.EqualTo(other);
        }

        /// <summary>
        /// Determines sort order between comparable objects.
        /// </summary>
        /// <typeparam name="T">The type to use for comparison.</typeparam>
        /// <param name="max">The maximum expected value.</param>
        /// <param name="comparer">A custom comparer used when evaluating the expression.</param>
        /// <returns>Returns a function for evaluating the expression against the specified values.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> AtMost<T>(T max)
        {
            return AtMost(max, Comparer<T>.Default);
        }

        /// <summary>
        /// Determines sort order between comparable objects.
        /// </summary>
        /// <typeparam name="T">The type to use for comparison.</typeparam>
        /// <param name="max">The maximum expected value.</param>
        /// <param name="comparer">A custom comparer used when evaluating the expression.</param>
        /// <returns>Returns a function for evaluating the expression against the specified values.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> AtMost<T>(T max, IComparer<T> comparer)
        {
            return it => it.Is.AtMost(max, comparer);
        }

        /// <summary>
        /// Determines sort order between comparable objects.
        /// </summary>
        /// <typeparam name="T">The type to use for comparison.</typeparam>
        /// <param name="min">The minimum expected value.</param>
        /// <returns>Returns a function for evaluating the expression against the specified values.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> AtLeast<T>(T min)
        {
            return it => it.Is.AtLeast(min);
        }

        /// <summary>
        /// Determines sort order between comparable objects.
        /// </summary>
        /// <typeparam name="T">The type to use for comparison.</typeparam>
        /// <param name="min">The minimum expected value.</param>
        /// <param name="comparer">A custom comparer used when evaluating the expression.</param>
        /// <returns>Returns a function for evaluating the expression against the specified values.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> AtLeast<T>(T min, IComparer<T> comparer)
        {
            return it => it.Is.AtLeast(min, comparer);
        }

        /// <summary>
        /// Determines sort order between comparable objects.
        /// </summary>
        /// <typeparam name="T">The type to use for comparison.</typeparam>
        /// <param name="target">The target value expected to be of matching sort order.</param>
        /// <returns>Returns a function for evaluating the expression against the specified values.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> SameAs<T>(T target)
        {
            return it => it.Is.SameAs(target);
        }

        /// <summary>
        /// Determines sort order between comparable objects.
        /// </summary>
        /// <typeparam name="T">The type to use for comparison.</typeparam>
        /// <param name="target">The target value expected to be of matching sort order.</param>
        /// <param name="comparer">A custom comparer used when evaluating the expression.</param>
        /// <returns>Returns a function for evaluating the expression against the specified values.</returns>
        public static Func<IIt<T>, FluentPredicate<T>> SameAs<T>(T target, IComparer<T> comparer)
        {
            return it => it.Is.SameAs(target, comparer);
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is within a specified range.
        /// </summary>
        public static Func<IIt<T>, FluentPredicate<T>> Between<T>(T min, T max)
        {
            return x => x.Is.Between(min, max);
        }
        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is within a specified range.
        /// </summary>
        public static Func<IIt<T>, FluentPredicate<T>> Between<T>(T min, T max, IComparer<T> comparer)
        {
            return x => x.Is.Between(min, max, comparer);
        }
    }
}