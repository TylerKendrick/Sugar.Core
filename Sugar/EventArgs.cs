namespace System
{
    /// <summary>
    /// Contains event data of a specified type <typeparamref name="T"/>.
    /// </summary>
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// Exposes the constructor as a delegate.
        /// </summary>
        public static readonly Func<T, EventArgs<T>> Create = value => new EventArgs<T>(value);
        
        /// <summary>
        /// Exposes the wrapped value for the specified event data type.
        /// </summary>
        public T Value { get; private set; }

        private EventArgs(T value)
        {
            Value = value;
        }
    }
}