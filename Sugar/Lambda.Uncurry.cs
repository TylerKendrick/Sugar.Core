namespace System
{
    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static partial class Lambda
    {
        public static Func<T1, T2, TResult> Uncurry<T1, T2, TResult>(
            this Func<T1, Func<T2, TResult>> func)
        {
            return (t1, t2) => func(t1)(t2);
        }
        public static Func<T1, T2, T3, TResult> Uncurry<T1, T2, T3, TResult>(
            this Func<T1, Func<T2, Func<T3, TResult>>> func)
        {
            return (t1, t2, t3) => func(t1)(t2)(t3);
        }
        public static Func<T1, T2, T3, T4, TResult> Uncurry<T1, T2, T3, T4, TResult>(
            this Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> func)
        {
            return (t1, t2, t3, t4) => func(t1)(t2)(t3)(t4);
        }


        public static Action<T1, T2> Uncurry<T1, T2>(
            this Func<T1, Action<T2>> func)
        {
            return (t1, t2) => func(t1)(t2);
        }
        public static Action<T1, T2, T3> Uncurry<T1, T2, T3>(
            this Func<T1, Func<T2, Action<T3>>> func)
        {
            return (t1, t2, t3) => func(t1)(t2)(t3);
        }
        public static Action<T1, T2, T3, T4> Uncurry<T1, T2, T3, T4>(
            this Func<T1, Func<T2, Func<T3, Action<T4>>>> func)
        {
            return (t1, t2, t3, t4) => func(t1)(t2)(t3)(t4);
        }
    }
}
