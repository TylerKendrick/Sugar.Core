using System;
using System.Linq.Expressions;

namespace Sugar
{
    /// <summary>
    /// Provides common usages of the Lazy object.
    /// </summary>
    public static class LazyExtensions
    {
        /// <summary>
        /// Converts a function to a lazy object.
        /// </summary>
        /// <typeparam name="T">Lazy Generic Type.</typeparam>
        /// <param name="self">The function to be used as the factory method for a Lazy object.</param>
        /// <returns>Returns a lazy object with the initial function as a factory method.</returns>
        public static Lazy<T> AsLazy<T>(this Func<T> self)
        {
            self.Require();
            return new Lazy<T>(self);
        }

        /// <summary>
        /// Selects a member of a lazy object, lazily.
        /// </summary>
        /// <typeparam name="TIn">The type to select against.</typeparam>
        /// <typeparam name="TOut">The type to return.</typeparam>
        /// <param name="self">The object being selected against.</param>
        /// <param name="memberExpression">The expression selecting the member of the lazy object.</param>
        /// <returns>A new Lazy object evaluating the member expression from another Lazy object.</returns>
        public static Lazy<TOut> Select<TIn, TOut>(this Lazy<TIn> self, Expression<Func<TIn, TOut>> memberExpression)
        {
            self.Require();
            Require.That(memberExpression.NodeType, Is.EqualTo(ExpressionType.MemberAccess));

            var func = memberExpression.Compile();
            return new Lazy<TOut>(func.Curry(self.Value));
        }

        /// <summary>
        /// Selects a member of a lazy object, lazily.
        /// </summary>
        /// <typeparam name="TIn">The type to select against.</typeparam>
        /// <typeparam name="TOut">The type to return.</typeparam>
        /// <param name="self">The object being selected against.</param>
        /// <param name="selector">The expression selecting the member of the lazy object.</param>
        /// <returns>A new Lazy object evaluating the member expression from another Lazy object.</returns>
        public static Lazy<TOut> SelectMany<TIn, TOut>(this Lazy<TIn> self, Func<TIn, Lazy<TOut>> selector)
        {
            self.Require();
            return new Lazy<TOut>(() => selector(self.Value).Value);
        }
    }
}
