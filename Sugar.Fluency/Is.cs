using System;
using System.Collections.Generic;

namespace Sugar
{
    /// <summary>
    /// Returns Conditional expression with a closed context for evaluation of the expression.
    /// </summary>
    public static class Is
    {
        public static ConditionalExpression<T> Null<T>(T target)
            where T : class
        {
            return new ConditionalExpression<T>(target, target == null);
        }

        public static ConditionalExpression<T> Null<T>(It<T> it)
            where T : class 
        {
            return it.Is.Default;
        }

        public static ConditionalExpression<T> Default<T>(T it)
        {
            return Fluent.It(it).Is.Default;
        }
        public static ConditionalExpression<T> Default<T>(It<T> it)
        {
            return it.Is.Default;
        }
        
        public static Func<It<T>, ConditionalExpression<T>> GreaterThan<T>(T other)
        {
            return it => it.Is.GreaterThan(other);
        }

        public static Func<It<T>, ConditionalExpression<T>> GreaterThan<T>(T other, IComparer<T> comparer)
        {
            return it => it.Is.GreaterThan(other, comparer);
        }
        public static Func<It<T>, ConditionalExpression<T>> LessThan<T>(T other)
        {
            return it => it.Is.LessThan(other);
        }

        public static class Not
        {
            public static ConditionalExpression<T> Null<T>(It<T> it)
                where T : class
            {
                return it.Is.Not.Default;
            }

            public static ConditionalExpression<T> Default<T>(It<T> it)
            {
                return it.Is.Not.Default;
            }
            public static Func<T, ConditionalExpression<T>> GreaterThan<T>(T other)
            {
                return x => Fluent.It(x).Is.Not.GreaterThan(other);
            }
            public static Func<T, ConditionalExpression<T>> LessThan<T>(T other)
            {
                return x => Fluent.It(x).Is.LessThan(other);
            }
        }

        public static Func<It<T>, ConditionalExpression<T>> EqualTo<T>(T other)
        {
            return it => it.Is.EqualTo(other);
        }

        public static Func<It<T>, ConditionalExpression<T>> AtMost<T>(T max, IComparer<T> comparer = null)
        {
            return it => it.Is.AtMost(max, comparer);
        }

        public static Func<It<T>, ConditionalExpression<T>> AtLeast<T>(T min, IComparer<T> comparer = null)
        {
            return it => it.Is.AtLeast(min, comparer);
        }

        public static Func<It<T>, ConditionalExpression<T>> SameAs<T>(T target)
        {
            return it => it.Is.SameAs(target);
        }
    }
}