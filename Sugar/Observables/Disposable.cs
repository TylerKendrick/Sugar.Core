using System;

namespace Sugar.Observables
{
    public class Disposable : IDisposable
    {
        private bool _isDisposed = false;
        private readonly Action _dispose;
        public Disposable(Action dispose)
        {
            _dispose = dispose;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _dispose();
                _isDisposed = true;
            }
        }
    }

    public class Disposable<T> : IDisposable<T>
    {
        private readonly Action<IDisposable<T>> _dispose;
        public T Value { get; private set; }

        public Disposable(T value, Action<IDisposable<T>> dispose)
        {
            Value = value;
            _dispose = dispose;
        }

        public void Dispose()
        {
            _dispose(this);
        }
    }
}