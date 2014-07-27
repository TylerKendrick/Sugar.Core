namespace System
{
    using Linq.Expressions;

    /// <summary>
    /// Provides common operations with a <see cref="Func"/> instance as extension methods.
    /// </summary>
    public static class FuncExtensions
    {
        /// <summary>
        /// Converts an instance of <see cref="Func{T, bool}"/> to an instance of <see cref="Predicate{T}"/>.
        /// </summary>
        public static Predicate<T> ToPredicate<T>(this Func<T, bool> self)
        {
            return x => self(x);
        }

        /// <summary>
        /// Converts an instance of <see cref="Predicate{T}"/> to an instance of <see cref="Func{T, bool}"/>.
        /// </summary>
        public static Func<T, bool> ToFunc<T>(this Predicate<T> self)
        {
            return x => self(x);
        }

        /// <summary>
        /// Converts an instance of <see cref="Func{TOut}"/> to an instance of <see cref="Expression{Func{TOut}}"/>.
        /// </summary>
        public static Expression<Func<TOut>> ToExpression<TOut>(this Func<TOut> self)
        {
            return () => self();
        }

        /// <summary>
        /// Converts an instance of <see cref="Expression{Func{TIn, TOut}}"/> to an instance of <see cref="Func{TIn, TOut}"/>.
        /// </summary>
        public static Expression<Func<TIn, TOut>> ToExpression<TIn, TOut>(this Func<TIn, TOut> self)
        {
            return x => self(x);
        }

        /// <summary>
        /// Converts an instance of <see cref="Expression{Func{T1, T2, TOut}}"/> to an instance of <see cref="Func{T1, T2, TOut}"/>.
        /// </summary>
        public static Expression<Func<T1, T2, TOut>> ToExpression<T1, T2, TOut>(this Func<T1, T2, TOut> self)
        {
            return (t1, t2) => self(t1, t2);
        }

        /// <summary>
        /// Converts an instance of <see cref="Expression{Func{T1, T2, T3, TOut}}"/> to an instance of <see cref="Func{T1, T2, T3, TOut}"/>.
        /// </summary>
        public static Expression<Func<T1, T2, T3, TOut>> ToExpression<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> self)
        {
            return (t1, t2, t3) => self(t1, t2, t3);
        }

        /// <summary>
        /// Converts an instance of <see cref="Expression{Func{T1, T2, T3, T4, TOut}}"/> to an instance of <see cref="Func{T1, T2, T3, T4, TOut}"/>.
        /// </summary>
        public static Expression<Func<T1, T2, T3, T4, TOut>> ToExpression<T1, T2, T3, T4, TOut>(this Func<T1, T2, T3, T4, TOut> self)
        {
            return (t1, t2, t3, t4) => self(t1, t2, t3, t4);
        }
    }
}