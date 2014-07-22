namespace System
{
    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static class Lambda
    {

    #region Action

        #region Curry 

        /// <summary>
        /// Converts an action of the form Kab to F a b -> a -> b -> Fab
        /// </summary>
        public static Func<T1, Action<T2>> Curry<T1, T2>(this Action<T1, T2> action)
        {
            return t1 => t2 => action(t1, t2);
        }

        /// <summary>
        /// Converts an action of the form Kabc to F a b c -> a -> b -> -> c -> Fabc
        /// </summary>
        public static Func<T1, Func<T2, Action<T3>>> Curry<T1, T2, T3>(this Action<T1, T2, T3> action)
        {
            return t1 => t2 => t3 => action(t1, t2, t3);
        }

        /// <summary>
        /// Converts an action of the form Kabcd to F a b c d -> a -> b -> c -> d -> Fabcd
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Action<T4>>>> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
        {
            return t1 => t2 => t3 => t4 => action(t1, t2, t3, t4);
        }

        #endregion Curry

        #region Apply T4
        
        /// <summary>
        /// Returns a <see cref="Action"/>   that applies all arguments to a <see cref="Action{T1, T2, T3, T4}"/> instance.
        /// </summary>
        public static Action Apply<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return () => action(t1, t2, t3, t4);
        }

        /// <summary>
        /// Returns a <see cref="Action{T2, T3, T4}"/>   that applies the first argument to a <see cref="Action{T1, T2, T3, T4}"/> instance.
        /// </summary>
        public static Action<T2, T3, T4> ApplyFirst<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action, T1 t1)
        {
            return (t2, t3, t4) => action(t1, t2, t3, t4);
        }

        /// <summary>
        /// Returns a <see cref="Action{T1, T3}"/>  that applies the second argument to a <see cref="Action{T1, T2, T3}"/> instance.
        /// </summary>
        public static Action<T1, T3, T4> ApplySecond<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action, T2 t2)
        {
            return (t1, t3, t4) => action(t1, t2, t3, t4);
        }

        /// <summary>
        /// Returns a <see cref="Action{T1, T2, T4}"/>  that applies the second argument to a <see cref="Action{T1, T2, T3, T4}"/> instance.
        /// </summary>
        public static Action<T1, T2, T4> ApplyThird<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action, T3 t3)
        {
            return (t1, t2, t4) => action(t1, t2, t3, t4);
        }

        /// <summary>
        /// Returns a <see cref="Action{T1, T2, T3}"/>  that applies the second argument to a <see cref="Action{T1, T2, T3, T4}"/> instance.
        /// </summary>
        public static Action<T1, T2, T3> ApplyFourth<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> action, T4 t4)
        {
            return (t1, t2, t3) => action(t1, t2, t3, t4);
        }
        #endregion Apply T4

        #region Apply T3

        /// <summary>
        /// Returns a <see cref="Action"/>   that applies all arguments to a <see cref="Action{T1, T2, T3}"/> instance.
        /// </summary>
        public static Action Apply<T1, T2, T3>(
            this Action<T1, T2, T3> action, T1 t1, T2 t2, T3 t3)
        {
            return () => action(t1, t2, t3);
        }

        /// <summary>
        /// Returns a <see cref="Action{T2, T3}"/>   that applies the first argument to a <see cref="Action{T1, T2, T3}"/> instance.
        /// </summary>
        public static Action<T2, T3> ApplyFirst<T1, T2, T3>(
            this Action<T1, T2, T3> action, T1 t1)
        {
            return (t2, t3) => action(t1, t2, t3);
        }

        /// <summary>
        /// Returns a <see cref="Action{T1, T3}"/>  that applies the second argument to a <see cref="Action{T1, T2, T3}"/> instance.
        /// </summary>
        public static Action<T1, T3> ApplySecond<T1, T2, T3>(
            this Action<T1, T2, T3> action, T2 t2)
        {
            return (t1, t3) => action(t1, t2, t3);
        }
        
        /// <summary>
        /// Returns a <see cref="Action{T1, T2}"/>  that applies the second argument to a <see cref="Action{T1, T2, T3}"/> instance.
        /// </summary>
        public static Action<T1, T2> ApplyThird<T1, T2, T3>(
            this Action<T1, T2, T3> action, T3 t3)
        {
            return (t1, t2) => action(t1, t2, t3);
        }

        #endregion Apply T3

        #region Apply T2

        /// <summary>
        /// Returns a <see cref="Action"/>   that applies all arguments to a <see cref="Action{T1, T2}"/> instance.
        /// </summary>
        public static Action Apply<T1, T2>(
            this Action<T1, T2> action, T1 t1, T2 t2)
        {
            return () => action(t1, t2);
        }

        /// <summary>
        /// Returns a <see cref="Action{T2}"/>   that applies the first argument to a <see cref="Action{T1, T2}"/> instance.
        /// </summary>
        public static Action<T2> ApplyFirst<T1, T2>(
            this Action<T1, T2> action, T1 t1)
        {
            return t2 => action(t1, t2);
        }

        /// <summary>
        /// Returns a <see cref="Action{T1}"/>  that applies the second argument to a <see cref="Action{T1, T2}"/> instance.
        /// </summary>
        public static Action<T1> ApplySecond<T1, T2>(
            this Action<T1, T2> action, T2 t2)
        {
            return t1 => action(t1, t2);
        }

        #endregion Apply T2

        #region Apply T1

        /// <summary>
        /// Returns a <see cref="Action"/> that applies all arguments to an <see cref="Action{T1}"/> instance.
        /// </summary>
        public static Action Apply<T1>(
            this Action<T1> action, T1 t1)
        {
            return () => action(t1);
        }

        #endregion Apply T1

    #endregion Function

    #region Function

        #region Curry

        /// <summary>
        /// Converts an action of the form Kab to F a b -> a -> b -> Fab
        /// </summary>
        public static Func<T1, Func<T2, TOut>> Curry<T1, T2, TOut>(this Func<T1, T2, TOut> func)
        {
            return t1 => t2 => func(t1, t2);
        }

        /// <summary>
        /// Converts an action of the form Kabc to F a b c -> a -> b -> -> c -> Fabc
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, TOut>>> Curry<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func)
        {
            return t1 => t2 => t3 => func(t1, t2, t3);
        }

        /// <summary>
        /// Converts an action of the form Kabcd to F a b c d -> a -> b -> c -> d -> Fabcd
        /// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, TOut>>>> Curry<T1, T2, T3, T4, TOut>(this Func<T1, T2, T3, T4, TOut> func)
        {
            return t1 => t2 => t3 => t4 => func(t1, t2, t3, t4);
        }

        #endregion Curry

        #region Apply T4

        /// <summary>
        /// Returns a <see cref="Func{TResult}"/>  that applies all arguments to a <see cref="Func{T1, T2, T3, TResult}"/> instance.
        /// </summary>
        public static Func<TResult> Apply<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return () => func(t1, t2, t3, t4);
        }

        /// <summary>
        /// Returns a <see cref="Func{T2, T3, T4, TResult}"/>  that applies the first argument to a <see cref="Func{T1, T2, T3, T4, TResult}"/> instance.
        /// </summary>
        public static Func<T2, T3, T4, TResult> ApplyFirst<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func, T1 t1)
        {
            return (t2, t3, t4) => func(t1, t2, t3, t4);
        }

        /// <summary>
        /// Returns a <see cref="Func{T1, T3, T4, TResult}"/>  that applies the second argument to a <see cref="Func{T1, T2, T3, T4, TResult}"/> instance.
        /// </summary>
        public static Func<T1, T3, T4, TResult> ApplySecond<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func, T2 t2)
        {
            return (t1, t3, t4) => func(t1, t2, t3, t4);
        }

        /// <summary>
        /// Returns a <see cref="Func{T1, T2, T4, TResult}"/>  that applies the third argument to a <see cref="Func{T1, T2, T3, T4, TResult}"/> instance.
        /// </summary>
        public static Func<T1, T2, T4, TResult> ApplyThird<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func, T3 t3)
        {
            return (t1, t2, t4) => func(t1, t2, t3, t4);
        }

        /// <summary>
        /// Returns a <see cref="Func{T1, T2, T3, TResult}"/>  that applies the third argument to a <see cref="Func{T1, T2, T3, T4, TResult}"/> instance.
        /// </summary>
        public static Func<T1, T2, T3, TResult> ApplyFourth<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func, T4 t4)
        {
            return (t1, t2, t3) => func(t1, t2, t3, t4);
        }

        #endregion Apply T4

        #region Apply T3

        /// <summary>
        /// Returns a <see cref="Func{TResult}"/>  that applies all arguments to a <see cref="Func{T1, T2, T3, TResult}"/> instance.
        /// </summary>
        public static Func<TResult> Apply<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func, T1 t1, T2 t2, T3 t3)
        {
            return () => func(t1, t2, t3);
        }

        /// <summary>
        /// Returns a <see cref="Func{T2, T3, TResult}"/>  that applies the first argument to a <see cref="Func{T1, T2, T3, TResult}"/> instance.
        /// </summary>
        public static Func<T2, T3, TResult> ApplyFirst<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func, T1 t1)
        {
            return (t2, t3) => func(t1, t2, t3);
        }

        /// <summary>
        /// Returns a <see cref="Func{T1, T3, TResult}"/>  that applies the second argument to a <see cref="Func{T1, T2, T3, TResult}"/> instance.
        /// </summary>
        public static Func<T1, T3, TResult> ApplySecond<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func, T2 t2)
        {
            return (t1, t3) => func(t1, t2, t3);
        }

        /// <summary>
        /// Returns a <see cref="Func{T1, T2, TResult}"/>  that applies the third argument to a <see cref="Func{T1, T2, T3, TResult}"/> instance.
        /// </summary>
        public static Func<T1, T2, TResult> ApplyThird<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func, T3 t3)
        {
            return (t1, t2) => func(t1, t2, t3);
        }

        #endregion Apply T3

        #region Apply T2

        /// <summary>
        /// Returns a <see cref="Func{TResult}"/>  that applies all arguments to a <see cref="Func{T1, T2, TResult}"/> instance.
        /// </summary>
        public static Func<TResult> Apply<T1, T2, TResult>(
            this Func<T1, T2, TResult> func, T1 t1, T2 t2)
        {
            return () => func(t1, t2);
        }

        /// <summary>
        /// Returns a <see cref="Func{T2, TResult}"/>  that applies the first argument to a <see cref="Func{T1, T2, TResult}"/> instance.
        /// </summary>
        public static Func<T2, TResult> ApplyFirst<T1, T2, TResult>(
            this Func<T1, T2, TResult> func, T1 t1)
        {
            return t2 => func(t1, t2);
        }

        /// <summary>
        /// Returns a <see cref="Func{T1, TResult}"/>  that applies the second argument to a <see cref="Func{T1, T2, TResult}"/> instance.
        /// </summary>
        public static Func<T1, TResult> ApplySecond<T1, T2, TResult>(
            this Func<T1, T2, TResult> func, T2 t2)
        {
            return t1 => func(t1, t2);
        }
        #endregion Apply T2

        #region Apply T1

        /// <summary>
        /// Returns a <see cref="Func{TResult}"/> that applies all arguments to an <see cref="Action{T1}"/> instance.
        /// </summary>
        public static Func<TResult> Apply<T1, TResult>(
            this Func<T1, TResult> func, T1 t1)
        {
            return () => func(t1);
        }

        #endregion Apply T1

    #endregion Function
    }
}
