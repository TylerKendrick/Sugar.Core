using System;
using System.Reflection;

namespace Sugar.Reflection
{    
    /// <summary>
    /// Simplifies accessing methods of a type.
    /// </summary>
    /// <typeparam name="T">The type being requested.</typeparam>
    public static class MethodInfo<T>
    {
        // ReSharper disable once StaticFieldInGenericType
        private static readonly Type Type;

        static MethodInfo()
        {
            Type = typeof(T);
        }

        /// <summary>
        /// Simplifies inspection of methods for types.
        /// </summary>
        /// <param name="name">The method for inspection.</param>
        /// <param name="bindingFlags">Uses BindingFlags.Default if null.</param>
        public static MethodInfo Parse(string name, BindingFlags bindingFlags = BindingFlags.Default)
        {
            return Type.GetMethod(name, bindingFlags);
        }

        /// <summary>
        /// Simplifies inspection of fields for types.
        /// </summary>
        public static MethodInfo Parse(string name, BindingFlags bindingFlags, 
            Binder binder, Type[] types, params ParameterModifier[] modifiers)
        {
            return Type.GetMethod(name, bindingFlags, binder, types, modifiers);
        }
    }
}
