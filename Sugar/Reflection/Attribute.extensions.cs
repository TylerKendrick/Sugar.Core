namespace System.Reflection
{
    using Collections.Generic;
    using Linq;

    /// <summary>
    /// Simplifies code for accessing Attributes.
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    public static class Attribute<TAttribute>
        where TAttribute : Attribute
    {
        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        /// <param name="instance">The instance to inspect with reflection.</param>
        public static TAttribute Parse<T>(T instance)
        {
            return instance.GetType()
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .FirstOrDefault();
        }

        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        public static TAttribute Parse<T>()
        {
            return typeof(T)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .FirstOrDefault();
        }

        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        /// <param name="instance">The instance to inspect with reflection.</param>
        public static IEnumerable<TAttribute> ParseMany<T>(T instance)
        {
            return instance.GetType()
                .GetCustomAttributes(false)
                .OfType<TAttribute>();
        }

        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        public static IEnumerable<TAttribute> ParseMany<T>()
        {
            return typeof (T)
                .GetCustomAttributes(false)
                .OfType<TAttribute>();
        }

        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        /// <param name="instance">The instance to inspect with reflection.</param>
        /// <param name="inherit">true to inspect the ancestors of <paramref name="instance"/>; otherwise, false. </param>
        public static IEnumerable<TAttribute> ParseMany<T>(T instance, bool inherit)
        {
            return instance.GetType()
                .GetCustomAttributes(inherit)
                .OfType<TAttribute>();
        }

        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        /// <param name="inherit">true to inspect the ancestors of the targetted type; otherwise, false. </param>
        public static IEnumerable<TAttribute> ParseMany<T>(bool inherit)
        {
            return typeof(T)
                .GetCustomAttributes(inherit)
                .OfType<TAttribute>();
        }
    }
}