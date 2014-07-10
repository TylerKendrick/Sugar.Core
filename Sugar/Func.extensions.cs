using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Sugar.Utilities;

namespace Sugar
{
    /// <summary>
    /// Simplifies construction of delegates from reflected types.
    /// </summary>
    /// <typeparam name="T">Assumes a type constraint of <see cref="Delegate"/>.  Even though the CLR supports this constraint, the current compiler does not.</typeparam>
    public static class Delegate<T>
    {
        /// <summary>
        /// Creates a new Delegate instance from the speficied <see cref="MethodInfo"/> parameter <paramref name="method"/>.
        /// </summary>
        public static T Create(MethodInfo method)
        {
            return Delegate.CreateDelegate(typeof(T), method).Cast<T>();
        }
    }

    public static class FuncExtensions
    {
        public static Predicate<T> ToPredicate<T>(this Func<T, bool> self)
        {
            return x => self(x);
        }
        public static Func<T, bool> ToFunc<T>(this Predicate<T> self)
        {
            return x => self(x);
        }
        public static Expression<Func<TIn, TOut>> ToExpression<TIn, TOut>(this Func<TIn, TOut> self)
        {
            return x => self(x);
        }

        public static IComparer<T> ToComparer<T>(this Func<T, T, int> comparer)
        {
            return new CustomComparer<T>(comparer);
        }

        public static Func<TIn, TOut> Memoize<TIn, TOut>(this Func<TIn, TOut> self)
        {
            self.Require();

            var dictionary = new Dictionary<TIn, TOut>();
            return x =>
            {
                TOut result;
                if (dictionary.ContainsKey(x) == false)
                {
                    result = self(x);
                    dictionary.Add(x, result);
                }
                else
                {
                    result = dictionary[x];
                }
                return result;
            };
        }
    }
}