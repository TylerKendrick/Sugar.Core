namespace System
{
    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static partial class Lambda
    {
        #region Action

        #region Curry 

        /// <summary>
        /// Converts an action of the form Kab to F a b -> a -> b -> Fab
        /// </summary>
        public static Func<T1, Action<T2>> Curry<T1, T2>(this Action<T1, T2> action)
            => t1 => t2 => action(t1, t2);

        /// <summary>
        /// Converts an action of the form Kabc to F a b c -> a -> b -> -> c -> Fabc
        /// </summary>
        public static Func<T1, Func<T2, Action<T3>>> Curry<T1, T2, T3>(this Action<T1, T2, T3> action)
            => t1 => t2 => t3 => action(t1, t2, t3);

        /// <summary>
        /// Converts an action of the form Kabcd to F a b c d -> a -> b -> c -> d -> Fabcd
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Action<T4>>>> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
            => t1 => t2 => t3 => t4 => action(t1, t2, t3, t4);

        #endregion Curry

        #endregion Action

        #region Function

        #region Curry

        /// <summary>
        /// Converts an action of the form Kab to F a b -> a -> b -> Fab
        /// </summary>
        public static Func<T1, Func<T2, TOut>> Curry<T1, T2, TOut>(this Func<T1, T2, TOut> func)
            => t1 => t2 => func(t1, t2);

        /// <summary>
        /// Converts an action of the form Kabc to F a b c -> a -> b -> -> c -> Fabc
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, TOut>>> Curry<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func)
            => t1 => t2 => t3 => func(t1, t2, t3);

        /// <summary>
        /// Converts an action of the form Kabcd to F a b c d -> a -> b -> c -> d -> Fabcd
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, TOut>>>> Curry<T1, T2, T3, T4, TOut>(this Func<T1, T2, T3, T4, TOut> func)
            => t1 => t2 => t3 => t4 => func(t1, t2, t3, t4);

        #endregion Curry

        #endregion Function
    }
}
