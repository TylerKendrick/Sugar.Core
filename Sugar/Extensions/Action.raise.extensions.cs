namespace System
{
    public static partial class ActionExtensions
    {
        /// <summary>
        /// Invokes the action if not null.
        /// </summary>
        public static void Raise(this Action self)
        {
            if (self != null) self();
        }

        /// <summary>
        /// Invokes the action if not null.
        /// </summary>
        public static void Raise<T>(this Action<T> self, T value)
        {
            if (self != null) self(value);
        }

        /// <summary>
        /// Invokes the action if not null.
        /// </summary>
        public static void Raise<T1, T2>(this Action<T1, T2> self, T1 value, T2 value2)
        {
            if (self != null) self(value, value2);
        }
    }
}
