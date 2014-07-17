using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// Provides fluent expression for generator blocks and yield statements.
    /// </summary>
    public static class Yield
    {
        /// <summary>
        /// Returns values while a predicate is true.
        /// </summary>
        /// <typeparam name="T">The type of item to return.</typeparam>
        /// <param name="predicate">Required condition for the loop expression.</param>
        /// <param name="generator">Required factory method for generating items.</param>
        /// <returns>Items generated while the predicate returned true.</returns>
        public static IEnumerable<T> While<T>(Func<bool> predicate, Func<T> generator)
        {
            predicate.Require();
            generator.Require();

            while (predicate())
            {
                yield return generator();
            }
        }

        /// <summary>
        /// Returns values while a predicate is false.
        /// </summary>
        /// <typeparam name="T">The type of item to return.</typeparam>
        /// <param name="predicate">Required condition for the loop expression.</param>
        /// <param name="generator">Required factory method for generating items.</param>
        /// <returns>Items generated while the predicate returned false.</returns>
        public static IEnumerable<T> Until<T>(Func<bool> predicate, Func<T> generator)
        {
            predicate.Require();
            generator.Require();

            while (!predicate())
            {
                yield return generator();
            }
        }
        
        /// <summary>
        /// Invokes a generator function a set number of times, using the iterator index as a parameter.
        /// </summary>
        /// <param name="count">The number of times to invoke the generator.</param>
        /// <param name="initial">The seed value for the generator function.</param>
        /// <param name="generator">The method providing values to the return result.</param>
        /// <typeparam name="T">The type of items in the returned collection.</typeparam>
        /// <returns>The results return by the generator function.</returns>
        public static IEnumerable<T> Times<T>(int count, T initial, Func<int, T, T> generator)
        {
            Require.That(count.IsAtLeast(1));
            generator.Require();

            var previous = initial;
            for (var i = 0; i < count; i++)
            {
                var result = generator(i, previous);
                yield return result;
                previous = result;
            }
        }

        /// <summary>
        /// Invokes a generator function a set number of times, using the iterator index as a parameter.
        /// </summary>
        /// <param name="count">The number of times to invoke the generator.</param>
        /// <param name="generator">The method providing values to the return result.</param>
        /// <typeparam name="T">The type of items in the returned collection.</typeparam>
        /// <returns>The results return by the generator function.</returns>
        public static IEnumerable<T> Times<T>(int count, Func<int, T> generator)
        {
            Require.That(count.IsAtLeast(1));
            generator.Require();

            for (var i = 0; i < count; i++)
            {
                yield return generator(i);
            }
        }


        /// <summary>
        /// Invokes a generator function a set number of times, using the iterator index as a parameter.
        /// </summary>
        /// <param name="count">The number of times to invoke the generator.</param>
        /// <param name="generator">The method providing values to the return result.</param>
        /// <typeparam name="T">The type of items in the returned collection.</typeparam>
        /// <returns>The results return by the generator function.</returns>
        public static IEnumerable<T> Times<T>(int count, Func<int, T, T> generator)
        {
            return Times(count, default(T), generator);
        }
    }
}