namespace System
{
    public static partial class ActionExtensions
    {
        /// <summary>
        /// Invokes the action if not null.
        /// </summary>
        public static void Raise(this Action self) => self?.Invoke();

        /// <summary>
        /// Invokes the action if not null.
        /// </summary>
        public static void Raise<T>(this Action<T> self, T value) => self?.Invoke(value);

        /// <summary>
        /// Invokes the action if not null.
        /// </summary>
        public static void Raise<T1, T2>(this Action<T1, T2> self, T1 value, T2 value2)
            => self?.Invoke(value, value2);

        /// <summary>
        /// Invokes the action if not null.
        /// </summary>
        public static void Raise<T1, T2, T3>(this Action<T1, T2, T3> self,
            T1 value, T2 value2, T3 value3) => self?.Invoke(value, value2, value3);

        /// <summary>
        /// Invokes the action if not null.
        /// </summary>
        public static void Raise<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> self,
            T1 value, T2 value2, T3 value3, T4 value4)
            => self?.Invoke(value, value2, value3, value4);
    }
}