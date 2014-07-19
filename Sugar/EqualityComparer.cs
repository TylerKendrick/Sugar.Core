using System.Collections.Generic;

namespace System
{
    public class EqualityComparer
    {
        public IEqualityComparer<T> Create<T>(Func<T, T, bool> equalityComarer)
        {
            return new EqualityComparer<T>(equalityComarer, x => x.GetHashCode());
        }

        public IEqualityComparer<T> Create<T>(Func<T, T, bool> equalityComparer,
            Func<T, int> hashGenerator)
        {
            return new EqualityComparer<T>(equalityComparer, hashGenerator);
        }
    }
    internal class EqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equalityComparer;
        private readonly Func<T, int> _hashGenerator;

        internal EqualityComparer(Func<T, T, bool> equalityComparer,
            Func<T, int> hashGenerator)
        {
            _equalityComparer = equalityComparer;
            _hashGenerator = hashGenerator;
        }

        public bool Equals(T x, T y)
        {
            return _equalityComparer(x, y);
        }

        public int GetHashCode(T arg)
        {
            return _hashGenerator(arg);
        }
    }
}