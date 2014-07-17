namespace System
{
    using Collections.Generic;
    using Reflection;

    /// <summary>
    /// Simplifies construction of delegates from reflected types.
    /// </summary>
    /// <typeparam name="T">Assumes a type constraint of <see cref="Delegate"/>.  Even though the CLR supports this constraint, the current compiler does not.</typeparam>
    public static class Delegate<T>
    {
        /// <summary>
        /// Creates a new Delegate instance from the speficied <see cref="MethodInfo"/> parameter <paramref name="method"/>.
        /// </summary>
        public static T Create(MethodInfo method)
        {
            return Delegate.CreateDelegate(typeof(T), method).Cast<T>();
        }
    }

    public static class DelegateExtensions
    {
        public static object Raise(this Delegate @delegate, params object[] parameters)
        {
            return @delegate != null
                ? @delegate.DynamicInvoke(parameters)
                : null;
        }

        public static object Raise(this Delegate @delegate, IEnumerable<object> parameters = null, object fallbackValue = null)
        {
            return @delegate.Raise(parameters) ?? fallbackValue;
        }
        public static T Raise<T>(this Delegate @delegate, IEnumerable<object> parameters = null, T fallbackValue = default(T))
        {
            return @delegate.Raise(parameters).Cast(fallbackValue);
        }
    }
}