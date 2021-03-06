﻿namespace System.Reflection
{
    /// <summary>
    /// Simplifies accessing members of a type.
    /// </summary>
    /// <typeparam name="T">The type being requested.</typeparam>
    public static class MemberInfo<T>
    {
        // ReSharper disable once StaticFieldInGenericType
        private static readonly Type Type;

        static MemberInfo()
        {
            Type = typeof (T);
        }

        /// <summary>
        /// Returns all members from the target type.
        /// </summary>
        public static MemberInfo[] Select()
        {
            return Type.GetMembers();
        }

        /// <summary>
        /// Returns all members from the target type with the specified bindingFlags.
        /// </summary>
        public static MemberInfo[] Select(BindingFlags bindingFlags)
        {
            return Type.GetMembers(bindingFlags);
        }

        /// <summary>
        /// Simplifies inspection of fields for types.
        /// </summary>
        /// <param name="name">The field for inspection.</param>
        /// <param name="bindingFlags">Uses BindingFlags.Default if null.</param>
        public static MemberInfo[] Parse(string name, BindingFlags bindingFlags = BindingFlags.Default)
        {
            return Type.GetMember(name, bindingFlags);
        }
    }

    /// <summary>
    /// Provides extension to <see cref="MemberInfo"/>
    /// </summary>
    public static class MemberInfoExtensions
    {
        /// <summary>
        /// Returns all members of a specified type.
        /// </summary>
        /// <typeparam name="T">The type used for inspection.</typeparam>
        /// <param name="self">The instance used for inspection.</param>
        /// <param name="bindingFlags">Uses BindingFlags.Default if null.</param>
        public static MemberInfo[] GetMembers<T>(this T self, BindingFlags bindingFlags = BindingFlags.Default)
        {
            var type = typeof (T);
            return type.GetMembers(bindingFlags);
        }
    }
}
