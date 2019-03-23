namespace System
{
    using Collections;
    using Collections.Generic;
    using Linq;

    /// <summary>
    /// Provides simplified invocation for common operations with <see cref="Enum"/> objects.
    /// </summary>
    /// <typeparam name="TEnum">Assumed to be a <see cref="Type"/> constrained to <see cref="Enum"/>.  Even though the CLR supports this constraint, the current compiler does not.</typeparam>
    public static class Enum<TEnum>
    {
        // ReSharper disable once StaticFieldInGenericType
        private static readonly Type Type;

        static Enum() => Type = typeof(TEnum);

        /// <summary>
        /// Parses a string as a named member of the target enum.
        /// </summary>
        public static TEnum Parse(string memberName)
            => Enum.Parse(Type, memberName).Cast<TEnum>();

        /// <summary>
        /// Returns a typed collection of values from the enum.
        /// </summary>
        public static IEnumerable<T> GetValues<T>()
        {
            var values = Enum.GetValues(Type);
            return Enumerable.Cast<T>(values);
        }

        /// <summary>
        /// Returns an untyped collection of values from the enum.
        /// </summary>
        public static IEnumerable GetValues() => Enum.GetValues(Type);

        /// <summary>
        /// Returns a collection of member names from the enum.
        /// </summary>
        public static IEnumerable<string> GetNames() => Enum.GetNames(Type);

        /// <summary>
        /// Attempts to find the member name of the targeted enum by value
        /// </summary>
        public static string GetName(TEnum value) => Enum.GetName(Type, value);

        /// <summary>
        /// Checks to see if the target enum contains the specified value as a named member.
        /// </summary>
        public static bool IsDefined(object value) => Enum.IsDefined(Type, value);
    }
}