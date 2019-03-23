namespace System
{
    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static partial class Lambda<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Reverses the parameter invocation on a curried function.
        /// </summary>
        public static Func<T4, Func<T3, Func<T2, Func<T1, T5>>>> Reverse(
            Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> func)
        {
            return d => c => b => a => func(a)(b)(c)(d);
        }
    }

    public static partial class Lambda<T1, T2, T3, T4>
    {
        /// <summary>
        /// Reverses the parameter invocation on a curried function.
        /// </summary>
        public static Func<T3, Func<T2, Func<T1, T4>>> Reverse(
            Func<T1, Func<T2, Func<T3, T4>>> func)
        {
            return z => y => x => func(x)(y)(z);
        }
    }

    public static partial class Lambda<T1, T2, TResult>
    {
        /// <summary>
        /// Reverses the parameter invocation on a curried function.
        /// </summary>
        public static Func<T2, Func<T1, TResult>> Reverse(
            Func<T1, Func<T2, TResult>> func)
        {
            return y => x => func(x)(y);
        }
    }

    public static partial class Lambda
    {
        /// <summary>
        /// Reverses the parameter invocation on a curried function.
        /// </summary>
        public static Func<T4, Func<T3, Func<T2, Func<T1, T5>>>> Reverse<T1, T2, T3, T4, T5>(
            this Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> func)
        {
            return Lambda<T1, T2, T3, T4, T5>.Reverse(func);
        }

        /// <summary>
        /// Reverses the parameter invocation on a curried function.
        /// </summary>
        public static Func<T3, Func<T2, Func<T1, TResult>>> Reverse<T1, T2, T3, TResult>(
            this Func<T1, Func<T2, Func<T3, TResult>>> func)
        {
            return Lambda<T1, T2, T3, TResult>.Reverse(func);
        }


        /// <summary>
        /// Reverses the parameter invocation on a curried function.
        /// </summary>
        public static Func<T2, Func<T1, TResult>> Reverse<T1, T2, TResult>(
            this Func<T1, Func<T2, TResult>> func)
        {
            return Lambda<T1, T2, TResult>.Reverse(func);
        }
    }
}