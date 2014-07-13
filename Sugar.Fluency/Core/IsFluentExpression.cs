using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    public class IsFluentExpression<T> : FluentExpression<T>, IIsFluentExpression<T>
    {
        private readonly FluentExpression<T> _not;

        /// <summary>
        /// Defines a context for evaluation.
        /// </summary>
        internal IsFluentExpression(T context) 
            : base(context)
        {
            _not = new NotFluentExpression<T>(context);
        }

        /// <summary>
        /// Negates the following comparable expressions.
        /// </summary>
        public FluentExpression<T> Not()
        {
            return _not;
        }

        /// <summary>
        /// Determines if the context of the expression is contained within a collection.
        /// </summary>
        public FluentPredicate<T> In(params T[] collection)
        {
            var result = collection.Contains(Context);
            return GetConditionalExpression(result);
        }
        protected override FluentPredicate<T> GetDefaultExpression()
        {
            return new FluentPredicate<T>(Context, Context.Equals(default(T)));
        }

        protected override FluentPredicate<T> GetConditionalExpression(bool predicate)
        {
            return new FluentPredicate<T>(Context, predicate);
        }
    }
}