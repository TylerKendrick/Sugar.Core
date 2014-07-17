using System;

namespace System
{
    /// <summary>
    /// Provides a new instance of a <see cref="FluentPredicate{T}"/> for expressions common to all object types.
    /// </summary>
    public class FluentExpression<T> : IFluentExpression<T>
    {
        T IFluentExpression<T>.Context { get { return Context; } }
        bool IFluentExpression<T>.Evaluate(bool isEqual)
        {
            return Evaluate(isEqual);
        }

        protected readonly T Context;
        protected readonly Func<bool, bool> Evaluate;
        
        /// <summary>
        /// Uses a specified context and predicate to provide context and offset the evaluation of proceeding expressions.
        /// </summary>
        /// <param name="context">The object context for evaluation.</param>
        /// <param name="evaluate">The offset predicate.  Returns an identity function (x => x) if null.</param>
        protected internal FluentExpression(T context, Func<bool, bool> evaluate = null)
        {
            Context = context;
            Evaluate = evaluate ?? (x => x);
        }
    }
}