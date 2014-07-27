namespace System
{
    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static partial class Lambda<T1, T2, T3, T4, T5>
    {
        public static Func<T4, Func<T3, Func<T2, Func<T1, T5>>>> Reverse(
            Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> func)
        {
            return d => c => b => a => func(a)(b)(c)(d);
        }
    }

    public static partial class Lambda<T1, T2, T3, T4>
    {
        public static Func<T3, Func<T2, Func<T1, T4>>> Reverse(
            Func<T1, Func<T2, Func<T3, T4>>> func)
        {
            return z => y => x => func(x)(y)(z);
        }
    }

    public static partial class Lambda<T1, T2, T3>
    {
        public static Func<T2, Func<T1, T3>> Reverse(
            Func<T1, Func<T2, T3>> func)
        {
            return y => x => func(x)(y);
        }
    }

    public static partial class Lambda
    {
        public static Func<T4, Func<T3, Func<T2, Func<T1, T5>>>> Reverse<T4, T3, T2, T1, T5>(
            this Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> func)
        {
            return Lambda<T1, T2, T3, T4, T5>.Reverse(func);
        }

        public static Func<T3, Func<T2, Func<T1, T4>>> Reverse<T3, T2, T1, T4>(
            this Func<T1, Func<T2, Func<T3, T4>>> func)
        {
            return Lambda<T1, T2, T3, T4>.Reverse(func);
        }

        public static Func<Ty, Func<Tx, Tz>> Reverse<Tx, Ty, Tz>(
            this Func<Tx, Func<Ty, Tz>> func)
        {
            return Lambda<Tx, Ty, Tz>.Reverse(func);
        }
    }
}
