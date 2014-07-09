using System;

namespace Sugar
{
    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    public class It<T> : It<T, IsComparableExpression<T>>
    {
        /// <summary>
        /// Provides the context to wrap.
        /// </summary>
        internal It(T handle)
            : base(() => new IsComparableExpression<T>(handle))
        {
        }
    }

    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    public class It<T, TIs> : It<T, TIs, ConditionalExpression<T>> 
        where TIs : IIsComparableExpression<T, ConditionalExpression<T>>
    {
        /// <summary>
        /// Provides predicate expressions through an instance of a subclass of <see cref="IsComparableExpression{T}"/>.
        /// </summary>
        public It(Func<TIs> factoryMethod) 
            : base(factoryMethod)
        {
        }
    }

    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    public class It<T, TIs, TConditional> : IIt<T, TIs, TConditional> 
        where TIs : IIsComparableExpression<T, TConditional> 
        where TConditional : IConditionalExpression<T>
    {
        private readonly Lazy<TIs> _is;

        /// <summary>
        /// Provides predicate expressions through an instance of a subclass of <see cref="IsComparableExpression{T}"/>.
        /// </summary>
        public TIs Is { get { return _is.Value; } }

        /// <summary>
        /// Provides the context to wrap.
        /// </summary>
        public It(Func<TIs> factoryMethod)
        {
            _is = new Lazy<TIs>(factoryMethod);
        }
    }
}