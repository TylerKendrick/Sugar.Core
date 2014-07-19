namespace System
{
    using Collections.Generic;
    using Linq.Expressions;
    using Linq;

    public static class FuncExtensions
    {
        public static Predicate<T> ToPredicate<T>(this Func<T, bool> self)
        {
            return x => self(x);
        }
        public static Func<T, bool> ToFunc<T>(this Predicate<T> self)
        {
            return x => self(x);
        }
        public static Expression<Func<TOut>> ToExpression<TOut>(this Func<TOut> self)
        {
            return () => self();
        }
        public static Expression<Func<TIn, TOut>> ToExpression<TIn, TOut>(this Func<TIn, TOut> self)
        {
            return x => self(x);
        }
        public static Expression<Func<T1, T2, TOut>> ToExpression<T1, T2, TOut>(this Func<T1, T2, TOut> self)
        {
            return (t1, t2) => self(t1, t2);
        }
        public static Expression<Func<T1, T2, T3, TOut>> ToExpression<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> self)
        {
            return (t1, t2, t3) => self(t1, t2, t3);
        }
        public static Expression<Func<T1, T2, T3, T4, TOut>> ToExpression<T1, T2, T3, T4, TOut>(this Func<T1, T2, T3, T4, TOut> self)
        {
            return (t1, t2, t3, t4) => self(t1, t2, t3, t4);
        }
        
        public static Func<TIn, TOut> Memoize<TIn, TOut>(this Func<TIn, TOut> self, IDictionary<TIn, TOut> results = null)
        {
            self.Require();
            results = results.Ensure(Dictionary.Create<TIn, TOut>);
            
            return x => results.GetOrAdd(x, () => self(x));
        }
    }
}