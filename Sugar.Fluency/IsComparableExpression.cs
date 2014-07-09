using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    public class IsComparableExpression<T> : IsComparableExpression<T, ConditionalExpression<T>>, IIsComparableExpression<T>
    {
        /// <summary>
        /// Defines a context for evaluation.
        /// </summary>
        public IsComparableExpression(T context) 
            : base(context)
        {
        }

        protected override ConditionalExpression<T> GetDefaultExpression()
        {
            return new ConditionalExpression<T>(Context, Context.Equals(default(T)));
        }

        protected override ConditionalExpression<T> GetConditionalExpression(bool predicate)
        {
            return new ConditionalExpression<T>(Context, predicate);
        }
    }

    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    public abstract class IsComparableExpression<T, TConditional> : 
        ComparableExpression<T, TConditional>, 
        IIsComparableExpression<T, TConditional>
        where TConditional : IConditionalExpression<T>
    {
        /// <summary>
        /// Negates the following comparable expressions.
        /// </summary>
        public ComparableExpression<T> Not { get; private set; }
        
        /// <summary>
        /// Defines a context for evaluation.
        /// </summary>
        protected internal IsComparableExpression(T context) 
            : base(context)
        {
            Not = new NotComparableExpression<T>(context);
        }

        /// <summary>
        /// Determines if the context of the expression is contained within a collection.
        /// </summary>
        public TConditional In(params T[] collection)
        {
            var result = collection.Contains(Context);
            return GetConditionalExpression(result);
        }
    }
}