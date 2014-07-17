namespace System
{
    using Collections.Generic;
    using Linq.Expressions;

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
        public static Expression<Func<TIn, TOut>> ToExpression<TIn, TOut>(this Func<TIn, TOut> self)
        {
            return x => self(x);
        }
        
        public static Func<TIn, TOut> Memoize<TIn, TOut>(this Func<TIn, TOut> self)
        {
            self.Require();

            var dictionary = new Dictionary<TIn, TOut>();
            return x =>
            {
                TOut result;
                if (dictionary.ContainsKey(x) == false)
                {
                    result = self(x);
                    dictionary.Add(x, result);
                }
                else
                {
                    result = dictionary[x];
                }
                return result;
            };
        }
    }
}