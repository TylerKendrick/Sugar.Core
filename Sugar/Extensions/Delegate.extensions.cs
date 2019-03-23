namespace System
{
    using Reflection;

    /// <summary>
    /// Simplifies construction of delegates from reflected types.
    /// </summary>
    /// <typeparam name="T">Assumes a type constraint of <see cref="Delegate"/>.  Even though the CLR supports this constraint, the current compiler does not.</typeparam>
    public static class Delegate<T>
    {
        /// <summary>
        /// Creates a new Delegate instance from the specified <see cref="MethodInfo"/> parameter <paramref name="method"/>.
        /// </summary>
        public static T Create(MethodInfo method) => Delegate.CreateDelegate(typeof(T), method).Cast<T>();
    }
}