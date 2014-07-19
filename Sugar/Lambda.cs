namespace System
{
    public static class Lambda
    {
    #region Action
        #region Curry 
        public static Func<T1, Action<T2>> Curry<T1, T2>(this Action<T1, T2> action)
        {
            return t1 => t2 => action(t1, t2);
        }
        public static Func<T1, Func<T2, Action<T3>>> Curry<T1, T2, T3>(this Action<T1, T2, T3> action)
        {
            return t1 => t2 => t3 => action(t1, t2, t3);
        }
        public static Func<T1, Func<T2, Func<T3, Action<T4>>>> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
        {
            return t1 => t2 => t3 => t4 => action(t1, t2, t3, t4);
        }
        #endregion Curry
        #region Apply T4
        public static Action<T2, T3, T4> Apply<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action, T1 t1)
        {
            return (t2, t3, t4) => action(t1, t2, t3, t4);
        }
        public static Action<T1, T3, T4> Apply<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action, T2 t2)
        {
            return (t1, t3, t4) => action(t1, t2, t3, t4);
        }
        public static Action<T1, T2, T4> Apply<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action, T3 t3)
        {
            return (t1, t2, t4) => action(t1, t2, t3, t4);
        }
        public static Action<T1, T2, T3> Apply<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action, T4 t4)
        {
            return (t1, t2, t3) => action(t1, t2, t3, t4);
        }
        #endregion Apply T4
        #region Apply T3
        public static Action<T2, T3> Apply<T1, T2, T3>(
            this Action<T1, T2, T3> action, T1 t1)
        {
            return (t2, t3) => action(t1, t2, t3);
        }
        public static Action<T1, T3> Apply<T1, T2, T3>(
            this Action<T1, T2, T3> action, T2 t2)
        {
            return (t1, t3) => action(t1, t2, t3);
        }
        public static Action<T1, T2> Apply<T1, T2, T3>(
            this Action<T1, T2, T3> action, T3 t3)
        {
            return (t1, t2) => action(t1, t2, t3);
        }
        #endregion Apply T3
        #region Apply T2
        public static Action<T2> Apply<T1, T2>(
            this Action<T1, T2> action, T1 t1)
        {
            return t2 => action(t1, t2);
        }
        public static Action<T1> Apply<T1, T2>(
            this Action<T1, T2> action, T2 t2)
        {
            return t1 => action(t1, t2);
        }
        #endregion Apply T2
        #region Apply T1
        public static Action Apply<T1>(
            this Action<T1> action, T1 t1)
        {
            return () => action(t1);
        }
        #endregion Apply T1
    #endregion Function
    #region Function
        #region Curry 
        public static Func<T1, Func<T2, TOut>> Curry<T1, T2, TOut>(this Func<T1, T2, TOut> func)
        {
            return t1 => t2 => func(t1, t2);
        }
        public static Func<T1, Func<T2, Func<T3, TOut>>> Curry<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func)
        {
            return t1 => t2 => t3 => func(t1, t2, t3);
        }
        public static Func<T1, Func<T2, Func<T3, Func<T4, TOut>>>> Curry<T1, T2, T3, T4, TOut>(this Func<T1, T2, T3, T4, TOut> func)
        {
            return t1 => t2 => t3 => t4 => func(t1, t2, t3, t4);
        }
        #endregion Curry
        #region Apply T4
        public static Func<T2, T3, T4, TResult> Apply<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func, T1 t1)
        {
            return (t2, t3, t4) => func(t1, t2, t3, t4);
        }
        public static Func<T1, T3, T4, TResult> Apply<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func, T2 t2)
        {
            return (t1, t3, t4) => func(t1, t2, t3, t4);
        }
        public static Func<T1, T2, T4, TResult> Apply<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func, T3 t3)
        {
            return (t1, t2, t4) => func(t1, t2, t3, t4);
        }
        public static Func<T1, T2, T3, TResult> Apply<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func, T4 t4)
        {
            return (t1, t2, t3) => func(t1, t2, t3, t4);
        }
        #endregion Apply T4
        #region Apply T3
        public static Func<T2, T3,TResult> Apply<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func, T1 t1)
        {
            return (t2, t3) => func(t1, t2, t3);
        }
        public static Func<T1, T3, TResult> Apply<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func, T2 t2)
        {
            return (t1, t3) => func(t1, t2, t3);
        }
        public static Func<T1, T2, TResult> Apply<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func, T3 t3)
        {
            return (t1, t2) => func(t1, t2, t3);
        }
        #endregion Apply T3
        #region Apply T2
        public static Func<T2, TResult> Apply<T1, T2, TResult>(
            this Func<T1, T2, TResult> func, T1 t1)
        {
            return t2 => func(t1, t2);
        }
        public static Func<T1, TResult> Apply<T1, T2, TResult>(
            this Func<T1, T2, TResult> func, T2 t2)
        {
            return t1 => func(t1, t2);
        }
        #endregion Apply T2
        #region Apply T1
        public static Func<TResult> Apply<T1, TResult>(
            this Func<T1, TResult> func, T1 t1)
        {
            return () => func(t1);
        }
        #endregion Apply T1
    #endregion Function
    }
}
