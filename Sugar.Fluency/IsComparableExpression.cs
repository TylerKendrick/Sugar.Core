using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    public class IsComparableExpression<T> : ComparableExpression<T>
    {
        /// <summary>
        /// Negates the following comparable expressions.
        /// </summary>
        public ComparableExpression<T> Not { get; private set; }

        /// <summary>
        /// Defines a context for evaluation.
        /// </summary>
        public IsComparableExpression(T context) 
            : base(context)
        {
            Not = new NotComparableExpression<T>(context);
        }

        /// <summary>
        /// Determines if the context of the expression is contained within a collection.
        /// </summary>
        public ConditionalExpression<T> In(params T[] collection)
        {
            var result = collection.Contains(Context);
            return new ConditionalExpression<T>(Context, result);
        }
    }
}