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
        /// <returns>Returns a new instance of <see cref="ConditionalExpression{T}"/> that resolves to true when the specified target is null.</returns>
        public static ConditionalExpression<T> Null<T>(T target)
            where T : class
        {
            return new ConditionalExpression<T>(target, target == null);
        }

        /// <summary>
        /// Used to determine if a specified target is null.
        /// </summary>
        /// <typeparam name="T">Any specified class type.</typeparam>
        /// <param name="it">The specified target for comparison.</param>
        /// <returns>Returns a new instance of <see cref="ConditionalExpression{T}"/> that resolves to true when the specified target is null.</returns>
        public static ConditionalExpression<T> Null<T>(It<T> it)
            where T : class 
        {
            return it.Is.Default();
        }

        /// <summary>
        /// Used to determine if a specified target is set to its default value.
        /// </summary>
        /// <typeparam name="T">Any specified type.</typeparam>
        /// <param name="it">The specified target for comparison.</param>
        /// <returns>Returns a new instance of <see cref="ConditionalExpression{T}"/> that resolves to true when the specified target is set to its default value.</returns>
        public static ConditionalExpression<T> Default<T>(T it)
        {
            return Fluent.It(it).Is.Default();
        }

        /// <summary>
        /// Used to determine if a specified target is set to its default value.
        /// </summary>
        /// <typeparam name="T">Any specified type.</typeparam>
        /// <param name="it">The specified target for comparison.</param>
        /// <returns>Returns a new instance of <see cref="ConditionalExpression{T}"/> that resolves to true when the specified target is set to its default value.</returns>
        public static ConditionalExpression<T> Default<T>(It<T> it)
        {
            return it.Is.Default();
        }

        /// <summary>
        /// Used to determine if a specified value is greater than a specified target.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <param name="other">The object to evaluate against a specified target for comparison.</param>
        /// <returns>Returns a function that evaluates against the specified argument <paramref name="other"/>.</returns>
        public static Func<It<T>, ConditionalExpression<T>> GreaterThan<T>(T other)
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
        public static Func<It<T>, ConditionalExpression<T>> GreaterThan<T>(T other, IComparer<T> comparer)
        {
            return it => it.Is.GreaterThan(other, comparer);
        }

        /// <summary>
        /// Used to determine if a specified value is less than a specified target.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <param name="other">The object to evaluate against a specified target for comparison.</param>
        /// <returns>Returns a function that evaluates against the specified argument <paramref name="other"/>.</returns>
        public static Func<It<T>, ConditionalExpression<T>> LessThan<T>(T other)
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
        public static Func<It<T>, ConditionalExpression<T>> LessThan<T>(T other, IComparer<T> comparer)
        {
            return it => it.Is.LessThan(other, comparer);
        }

        /// <summary>
        /// Determines object equivalence.
        /// </summary>
        /// <typeparam name="T">The type of object for comparison.</typeparam>
        /// <returns>Returns a function to evaluate against a fluent target.</returns>
        public static Func<It<T>, ConditionalExpression<T>> EqualTo<T>(T other)
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
        public static Func<It<T>, ConditionalExpression<T>> AtMost<T>(T max, IComparer<T> comparer)
        {
            return it => it.Is.AtMost(max, comparer);
        }

        /// <summary>
        /// Determines sort order between comparable objects.
        /// </summary>
        /// <typeparam name="T">The type to use for comparison.</typeparam>
        /// <param name="min">The minimum expected value.</param>
        /// <returns>Returns a function for evaluating the expression against the specified values.</returns>
        public static Func<It<T>, ConditionalExpression<T>> AtLeast<T>(T min)
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
        public static Func<It<T>, ConditionalExpression<T>> AtLeast<T>(T min, IComparer<T> comparer)
        {
            return it => it.Is.AtLeast(min, comparer);
        }

        /// <summary>
        /// Determines sort order between comparable objects.
        /// </summary>
        /// <typeparam name="T">The type to use for comparison.</typeparam>
        /// <param name="target">The target value expected to be of matching sort order.</param>
        /// <returns>Returns a function for evaluating the expression against the specified values.</returns>
        public static Func<It<T>, ConditionalExpression<T>> SameAs<T>(T target)
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
        public static Func<It<T>, ConditionalExpression<T>> SameAs<T>(T target, IComparer<T> comparer)
        {
            return it => it.Is.SameAs(target, comparer);
        }
    }
}