using System;
using System.Reflection;

namespace Sugar.Reflection
{
    /// <summary>
    /// Simplifies parsing any given type for fields.
    /// </summary>
    /// <typeparam name="T">The type for inspection.</typeparam>
    public static class PropertyInfo<T>
    {
        // ReSharper disable once StaticFieldInGenericType
        private static readonly Type Type;

        static PropertyInfo()
        {
            Type = typeof(T);
        }

        /// <summary>
        /// Simplifies inspection of properties for types.
        /// </summary>
        /// <param name="name">The property for inspection.</param>
        /// <param name="bindings">Uses BindingFlags.Default if null.</param>
        public static PropertyInfo Parse(string name, BindingFlags bindings = BindingFlags.Default)
        {
            return Type.GetProperty(name, bindings);
        }

        /// <summary>
        /// Simplifies accessing properties against an instance.
        /// </summary>
        /// <typeparam name="TOut">The expected type of the inspected property.</typeparam>
        /// <param name="name">The name of the property for inspection.</param>
        /// <param name="instance">The instance used for providing the property.</param>
        /// <returns>Returns the value of the property.</returns>
        public static TOut Get<TOut>(string name, object instance)
        {
            return Parse(name).GetValue(instance, null).Cast<TOut>();
        }

        /// <summary>
        /// Simplifies mutating properties against an instance.
        /// </summary>
        /// <typeparam name="TIn">The expected type of the property.</typeparam>
        /// <param name="name">The name of the property for inspection.</param>
        /// <param name="instance">The instance used for providing the property.</param>
        /// <param name="value">The value attempted for assignment.</param>
        public static void Set<TIn>(string name, object instance, TIn value)
        {
            Parse(name).SetValue(instance, value, null);
        }
    }
}