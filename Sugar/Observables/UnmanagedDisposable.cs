using System;

namespace Sugar.Observables
{
    /// <summary>
    /// Defines an object implementing the Disposable Pattern for unmanaged resources.
    /// Should not be used for objects that do not consume unmanaged resources.
    /// </summary>
    public abstract class UnmanagedDisposable : IDisposable
    {
        private bool _isAlive = true;
        private readonly Action _dispose;

        /// <summary>
        /// Wraps an action to execute on disposal.
        /// </summary>
        /// <param name="dispose">The method to execute on disposal.</param>
        protected UnmanagedDisposable(Action dispose)
        {
            _dispose = dispose;
        }

        /// <summary>
        /// This method should only dispose of managed resources.
        /// </summary>
        protected abstract void DisposeManagedResources();

        /// <summary>
        /// This method should only dispose of unmanaged resources.
        /// The existance of managed resources cannot be guaranteed.
        /// </summary>
        protected abstract void DisposeUnmanagedResources();

        public void Dispose()
        {
            if (_isAlive)
            {
                _dispose();
                DisposeManagedResources();
                DisposeUnmanagedResources();
                GC.SuppressFinalize(this);
                _isAlive = false;
            }
        }

        ~UnmanagedDisposable()
        {
            _dispose();
            DisposeUnmanagedResources();
            _isAlive = false;
        }
    }
}