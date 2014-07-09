using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sugar.Reflection
{
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
            var type = instance.GetType();
            return type.GetCustomAttribute<TAttribute>();
        }

        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        public static TAttribute Parse<T>()
        {
            var type = typeof(T);
            return type.GetCustomAttribute<TAttribute>();
        }

        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        /// <param name="instance">The instance to inspect with reflection.</param>
        public static IEnumerable<TAttribute> ParseMany<T>(T instance)
        {
            var type = instance.GetType();
            return type.GetCustomAttributes<TAttribute>();
        }

        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        public static IEnumerable<TAttribute> ParseMany<T>()
        {
            var type = typeof(T);
            return type.GetCustomAttributes<TAttribute>();
        }

        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        /// <param name="instance">The instance to inspect with reflection.</param>
        /// <param name="inherit">true to inspect the ancestors of <paramref name="instance"/>; otherwise, false. </param>
        public static IEnumerable<TAttribute> ParseMany<T>(T instance, bool inherit)
        {
            var type = instance.GetType();
            return type.GetCustomAttributes<TAttribute>(inherit);
        }

        /// <summary>
        /// Uses reflection to parse the object for Attributes of the targeted type.
        /// </summary>
        /// <typeparam name="T">The type of the provided instance.</typeparam>
        /// <param name="inherit">true to inspect the ancestors of the targetted type; otherwise, false. </param>
        public static IEnumerable<TAttribute> ParseMany<T>(bool inherit)
        {
            var type = typeof(T);
            return type.GetCustomAttributes<TAttribute>(inherit);
        }
    }
}