﻿namespace Sugar
{
    /// <summary>
    /// Object wrapper to provide fluent extensions common to all objects.
    /// </summary>
    public class It<T> : IIt<T> 
    {
        private readonly T _context;

        /// <summary>
        /// Provides predicate expressions through an instance of a subclass of <see cref="IsComparableExpression{T}"/>.
        /// </summary>
        public IsComparableExpression<T> Is { get; private set; }

        /// <summary>
        /// Provides the context to wrap.
        /// </summary>
        internal It(T context)
        {
            _context = context;
            Is = new IsComparableExpression<T>(context);
        }

        public static implicit operator T(It<T> handle)
        {
            return handle._context;
        }
    }
}