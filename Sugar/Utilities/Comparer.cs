using System;
using System.Collections.Generic;

namespace Sugar.Utilities
{
    internal class CustomComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _compare;

        public CustomComparer(Func<T, T, int> compare)
        {
            _compare = compare;
        }

        public int Compare(T x, T y)
        {
            return _compare(x, y);
        }
    }
}
