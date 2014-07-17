using System.Collections.Generic;

namespace System
{
    public static class CustomComparer
    {
        public static IComparer<T> Create<T>(Func<T, T, int> comparer)
        {
            return new CustomComparer<T>(comparer);
        }
    }
    internal class CustomComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _comparer;

        public CustomComparer(Func<T, T, int> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            return _comparer(x, y);
        }
    }
}
