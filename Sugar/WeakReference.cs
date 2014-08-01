namespace System
{
    /// <summary>
    /// Represents a weak reference, which references an object 
    /// while still allowing that object to be reclaimed by garbage collection.
    /// </summary>
    public class WeakReference<T> : WeakReference
    {
        private new T Target
        {
            get { return (T)base.Target; } 
            set { base.Target = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakReference{T}"/> class, 
        /// referencing the specified object.
        /// </summary>
        /// <param name="target">The object to track or null.</param>
        public WeakReference(T target) 
            : base(target)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakReference{T}"/> class, 
        /// referencing the specified object.
        /// </summary>
        /// <param name="target">The object to track or null.</param>
        /// <param name="trackResurrection">Indicates when to stop tracking the object. 
        /// If true, the object is tracked after finalization; 
        /// if false, the object is only tracked until finalization.</param>
        public WeakReference(T target, bool trackResurrection) 
            : base(target, trackResurrection)
        {
        }

        /// <summary>
        /// Tries to retrieve the target object 
        /// that is referenced by the current <see cref="WeakReference{T}"/> object.
        /// </summary>
        /// <param name="value">
        /// When this method returns, contains the target object, if it is available. 
        /// This parameter is treated as uninitialized.
        /// </param>
        /// <returns>true if the target was retrieved; otherwise, false.</returns>
        public bool TryGetTarget(out T value)
        {
            value = IsAlive ? Target : default (T);
            return IsAlive;
        }

        /// <summary>
        /// Sets the target object that is referenced 
        /// by this <see cref="WeakReference{T}"/> object.
        /// </summary>
        /// <param name="value">The new target object.</param>
        public void SetTarget(T value)
        {
            Target = value;
        }
    }
}