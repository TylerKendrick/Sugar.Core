using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar.Linq
{
    /// <summary>
    /// Provides extensions to common Linq operations to allow for easier use of Fluent expressions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Exposes syntactic sugar for evaluating a conditional expression in a linq Where clause.
        /// </summary>
        public static IEnumerable<T> Where<T>(this IEnumerable<T> self,
            Func<It<T>, ConditionalExpression<T>> fluentExpression)
        {
            return self.Where(x => fluentExpression(Fluent.It(x)) == true);
        }

        /// <summary>
        /// Exposes syntactic sugar for evaluating a conditional expression in a linq Any clause.
        /// </summary>
        public static bool Any<T>(this IEnumerable<T> self,
            Func<It<T>, ConditionalExpression<T>> fluentExpression)
        {
            return self.Any(x => fluentExpression(Fluent.It(x)));
        }

        /// <summary>
        /// Exposes syntactic sugar for evaluating a conditional expression in a linq All clause.
        /// </summary>
        public static bool All<T>(this IEnumerable<T> self,
            Func<It<T>, ConditionalExpression<T>> fluentExpression)
        {
            return self.All(x => fluentExpression(Fluent.It(x)));
        }

        /// <summary>
        /// Exposes syntactic sugar for evaluating a conditional expression in a linq Single clause.
        /// </summary>
        public static T Single<T>(this IEnumerable<T> self,
            Func<It<T>, ConditionalExpression<T>> fluentExpression)
        {
            return self.Single(x => fluentExpression(Fluent.It(x)));
        }

        /// <summary>
        /// Exposes syntactic sugar for evaluating a conditional expression in a linq SingleOrDefault clause.
        /// </summary>
        public static T SingleOrDefault<T>(this IEnumerable<T> self,
            Func<It<T>, ConditionalExpression<T>> fluentExpression)
        {
            return self.SingleOrDefault(x => fluentExpression(Fluent.It(x)));
        }


        /// <summary>
        /// Exposes syntactic sugar for evaluating a conditional expression in a linq First clause.
        /// </summary>
        public static T First<T>(this IEnumerable<T> self,
            Func<It<T>, ConditionalExpression<T>> fluentExpression)
        {
            return self.First(x => fluentExpression(Fluent.It(x)));
        }

        /// <summary>
        /// Exposes syntactic sugar for evaluating a conditional expression in a linq FirstOrDefault clause.
        /// </summary>
        public static T FirstOrDefault<T>(this IEnumerable<T> self,
            Func<It<T>, ConditionalExpression<T>> fluentExpression)
        {
            return self.FirstOrDefault(x => fluentExpression(Fluent.It(x)));
        }


        /// <summary>
        /// Exposes syntactic sugar for evaluating a conditional expression in a linq Last clause.
        /// </summary>
        public static T Last<T>(this IEnumerable<T> self,
            Func<It<T>, ConditionalExpression<T>> fluentExpression)
        {
            return self.Single(x => fluentExpression(Fluent.It(x)));
        }

        /// <summary>
        /// Exposes syntactic sugar for evaluating a conditional expression in a linq LastOrDefault clause.
        /// </summary>
        public static T LastOrDefault<T>(this IEnumerable<T> self,
            Func<It<T>, ConditionalExpression<T>> fluentExpression)
        {
            return self.LastOrDefault(x => fluentExpression(Fluent.It(x)));
        }


        /// <summary>
        /// Exposes syntactic sugar for evaluating a conditional expression in a linq Count expression.
        /// </summary>
        public static int Count<T>(this IEnumerable<T> self,
            Func<It<T>, ConditionalExpression<T>> fluentExpression)
        {
            return self.Count(x => fluentExpression(Fluent.It(x)));
        }
    }
}