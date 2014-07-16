using System;
using Sugar.Utilities;

namespace Sugar
{
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
    }
}