using System;

namespace Sugar
{
    public static class Lambda
    {
        public static Func<T1, Func<T2, TOut>> Curry<T1, T2, TOut>(this Func<T1, T2, TOut> func)
        {
            return t1 => t2 => func(t1, t2);
        }
        public static Func<T1, Func<T2, Func<T3, TOut>>> Curry<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func)
        {
            return t1 => t2 => t3 => func(t1, t2, t3);
        }
    }
}
