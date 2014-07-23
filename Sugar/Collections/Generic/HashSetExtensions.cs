namespace System.Collections.Generic
{
    /// <summary>
    /// Provides common operations with <see cref="HashSet{T}"/> instances as extension methods.
    /// </summary>
    public static class HashSetExtensions
    {
        /// <summary>
        /// Converts a target enumerable into a new instance of a <see cref="HashSet{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set"></param>
        /// <returns></returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> set)
        {
            return new HashSet<T>(set);
        }
    }
}