namespace System
{
    /// <summary>
    /// Provides functional operations for delegates as extension methods.
    /// </summary>
    public static partial class Lambda<T1, T2, T3>
    {
        public static readonly Func<Func<T2, Func<T1, T3>>, Func<Func<T2, T1>, Func<T2, T3>>> Substitution = x => y => z => x(z)(y(z));
    }

    public static partial class Lambda<Tx, Ty>
    {
        public static readonly Func<Tx, Func<Ty, Tx>> Constant = x => y => x;
    }

    public static partial class Lambda<T>
    {
        public static readonly Func<T, T> Identity = x => x;
    }

    public static partial class Lambda
    {
        public static T Identity<T>(T x)
        {
            return Lambda<T>.Identity(x);
        }

        public static Tx Constant<Tx, Ty>(Tx x, Ty y)
        {
            return Lambda<Tx, Ty>.Constant(x)(y);
        }

        public static Tz Substitution<Tx, Ty, Tz>(
            Func<Ty, Func<Tx, Tz>> first,
            Func<Ty, Tx> second,
            Ty arg)
        {
            return Lambda<Tx, Ty, Tz>.Substitution(first)(second)(arg);
        }

        public static Func<TOther, TResult> Compose<TIn, TOther, TResult>(this Func<TIn, TResult> func,
            Func<TOther, TIn> other)
        {
            return x => func(other(x));
        }
    }
}
