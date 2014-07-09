using System;
using System.Collections.Concurrent;
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
        public static Func<TOut> Curry<TIn, TOut>(this Func<TIn, TOut> self, TIn value)
        {
            return () => self(value);
        }
        public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(this Func<T1, T2, T3> self)
        {
            return x => y => self(x, y);
        }
        
        public static Predicate<T> ToPredicate<T>(this Func<T, bool> self)
        {
            return new Predicate<T>(self);
        }
        public static Func<T, bool> ToFunc<T>(this Predicate<T> self)
        {
            return x => self(x);
        }

        public static Expression<Func<TIn, TOut>> ToExpression<TIn, TOut>(this Func<TIn, TOut> self)
        {
            return x => self(x);
        }

        public static IComparer<T> AsComparer<T>(this Func<T, T, int> comparer)
        {
            return new CustomComparer<T>(comparer);
        }

        public static Func<TIn, TOut> Memoize<TIn, TOut>(this Func<TIn, TOut> self)
        {
            var concurrentDictionary = new ConcurrentDictionary<TIn, TOut>();
            return x => concurrentDictionary.GetOrAdd(x, self);
        }
    }
}