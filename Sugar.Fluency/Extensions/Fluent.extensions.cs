using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sugar
{
    public static class FluentExpressionExtensions
    {
        /// <summary>
        /// Determines if the context of the expression is contained within a collection.
        /// </summary>
        public static FluentPredicate<T> In<T>(this IFluentExpression<T> self, params T[] collection)
        {
            var result = collection.Contains(self.Context);
            return GetConditionalExpression(self, result);
        }

        /// <summary>
        /// Returns an expression that evaluates as true if the context provided for the condition is equal to <code>default(T)</code>.
        /// </summary>
        public static FluentPredicate<T> Default<T>(this IFluentExpression<T> self)
            where T : struct
        {
            return GetDefaultExpression(self);
        }

        public static FluentPredicate<T> Null<T>(this IFluentExpression<T> self)
            where T : class
        {
            return new FluentPredicate<T>(self.Context, self.Context == null);
        }

        /// <summary>
        /// Uses an <see cref="IEqualityComparer{T}"/> to compare object values.
        /// </summary>
        public static FluentPredicate<T> EqualTo<T>(this IFluentExpression<T> self, T comparable, IEqualityComparer<T> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
            var result = comparer.Equals(self.Context, comparable);
            return GetConditionalExpression(self, self.Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if <paramref name="comparable"/> is equivalent to the wrapped object.
        /// </summary>
        public static FluentPredicate<T> SameAs<T>(this IFluentExpression<T> self, T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(self.Context, comparable) == 0;
            return GetConditionalExpression(self, self.Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than <paramref name="comparable"/>.
        /// </summary>
        public static FluentPredicate<T> GreaterThan<T>(this IFluentExpression<T> self, T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(self.Context, comparable) > 0;
            return GetConditionalExpression(self, self.Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than <paramref name="comparable"/>.
        /// </summary>
        public static FluentPredicate<T> LessThan<T>(this IFluentExpression<T> self, T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(self.Context, comparable) < 0;
            return GetConditionalExpression(self, self.Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is within a specified range.
        /// </summary>
        public static FluentPredicate<T> Between<T>(this IFluentExpression<T> self, T start, T end, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            //The relation between start and end could be a negative range.
            //In this case, just make sure that the compare results (when added) show no difference.
            var result = comparer.Compare(self.Context, start) + comparer.Compare(self.Context, end) == 0;
            return GetConditionalExpression(self, self.Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is greater than or equal to <paramref name="comparable"/>.
        /// </summary>
        public static FluentPredicate<T> AtLeast<T>(this IFluentExpression<T> self, T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(self.Context, comparable) >= 0;
            return GetConditionalExpression(self, self.Evaluate(result));
        }

        /// <summary>
        /// Uses an <see cref="IComparer{T}"/> to determine if the wrapped object is less than or equal to <paramref name="comparable"/>.
        /// </summary>
        public static FluentPredicate<T> AtMost<T>(this IFluentExpression<T> self, T comparable, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            var result = comparer.Compare(self.Context, comparable) <= 0;
            return GetConditionalExpression(self, self.Evaluate(result));
        }

        /// <summary>
        /// Generates a new instance of <see cref="FluentPredicate{T}"/> for use by subsequent expressions.
        /// </summary>
        private static FluentPredicate<T> GetConditionalExpression<T>(IFluentExpression<T> self, bool predicate)
        {
            return new FluentPredicate<T>(self.Context, predicate);
        }
        private static bool HandleIsDefault<T>(IFluentExpression<T> self)
        {
            var isEqual = RuntimeHelpers.Equals(self.Context, default(T));
            return self.Evaluate(isEqual);
        }

        /// <summary>
        /// Generates a new instance of <see cref="FluentPredicate{T}"/> for use by subsequent expressions.
        /// </summary>
        private static FluentPredicate<T> GetDefaultExpression<T>(this IFluentExpression<T> self)
        {
            return new FluentPredicate<T>(self.Context, HandleIsDefault(self));
        }

        internal static FluentPredicate<T> Generate<T>(this IFluentExpression<T> self,
            Func<T, bool> predicate)
        {
            return new FluentPredicate<T>(self.Context, predicate(self.Context));
        }
    }
}