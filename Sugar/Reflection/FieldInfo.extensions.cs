using System;
using System.Reflection;

namespace Sugar.Reflection
{
    /// <summary>
    /// Simplifies parsing any given type for fields.
    /// </summary>
    /// <typeparam name="T">The type for inspection.</typeparam>
    public class FieldInfo<T>
    {
        // ReSharper disable once StaticFieldInGenericType
        private static readonly Type Type;

        static FieldInfo()
        {
            Type = typeof (T);
        }

        /// <summary>
        /// Simplifies inspection of fields for types.
        /// </summary>
        /// <param name="name">The field for inspection.</param>
        /// <param name="bindingFlags">Uses BindingFlags.Default if null.</param>
        public static FieldInfo Parse(string name, BindingFlags bindingFlags = BindingFlags.Default)
        {
            return Type.GetField(name, bindingFlags);
        }

        /// <summary>
        /// Simplifies accessing fields against an instance.
        /// </summary>
        /// <typeparam name="TOut">The expected type of the inspected field.</typeparam>
        /// <param name="name">The name of the field for inspection.</param>
        /// <param name="instance">The instance used for providing the field.</param>
        /// <returns>Returns the value of the field.</returns>
        public static TOut Get<TOut>(string name, object instance)
        {
            return Parse(name).GetValue(instance).Cast<TOut>();
        }

        /// <summary>
        /// Simplifies mutating fields against an instance.
        /// </summary>
        /// <typeparam name="TIn">The expected type of the field.</typeparam>
        /// <param name="name">The name of the field for inspection.</param>
        /// <param name="instance">The instance used for providing the field.</param>
        /// <param name="value">The value attempted for assignment.</param>
        public static void Set<TIn>(string name, object instance, TIn value)
        {
            Parse(name).SetValue(instance, value);
        }
    }
}