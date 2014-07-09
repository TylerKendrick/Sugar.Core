using System;

namespace Sugar
{
    public static partial class ActionExtensions
    {
        /// <summary>
        /// Returns an action without parameters.
        /// </summary>
        public static Action Defer<T>(this Action<T> self, T value)
        {
            return () => self(value);
        }

        /// <summary>
        /// Decomposes the target action f{x,y} into f x -> y
        /// </summary>
        public static Func<T1, Action<T2>> Curry<T1, T2>(this Action<T1, T2> self)
        {
            return x => y => self(x, y);
        }

        /// <summary>
        /// Decomposes the target action f{x,y,z} into f x -> y -> z
        /// </summary>
        public static Func<T1, Func<T2, Action<T3>>> Curry<T1, T2, T3>(this Action<T1, T2, T3> self)
        {
            return x => y => z => self(x, y, z);
        }
    }
}
