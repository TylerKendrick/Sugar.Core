namespace System
{
    using Utilities;

    /// <summary>
    /// Provides common extensions for objects with the class constraint.
    /// </summary>
    public static class ClassExtensions
    {
        /// <summary>
        /// Throws an exception if the value is null.
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws an exception when the caller is null.</exception>
        public static void Require<T>(this T self, string name = null, string message = null)
            where T : class
        {
            if (self == null)
            {
                if (message == null)
                {
                    throw Error.NullArgument(name);
                }
                throw Error.NullArgument(name, message);
            }
        }

        public static T Ensure<T>(this T self)
            where T : class, new()
        {
            return self ?? new T();
        }
        public static T Ensure<T, TFallback>(this T self)
            where T : class
            where TFallback : class, T, new()
        {
            return self ?? new TFallback();
        }
        public static T Ensure<T, TFallback>(this T self, TFallback fallback)
            where T : class
            where TFallback : class, T, new()
        {
            return self ?? fallback ?? new TFallback();
        }

        public static T Ensure<T>(this T self, Func<T> fallbackGenerator)
            where T : class
        {
            return self ?? fallbackGenerator();
        }
    }
}