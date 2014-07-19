namespace System.Collections.Generic
{
    internal static class HashSetExtensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> set)
        {
            return new HashSet<T>();
        }
    }
}