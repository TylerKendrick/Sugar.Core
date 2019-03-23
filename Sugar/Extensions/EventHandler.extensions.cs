namespace System
{
    /// <summary>
    /// Providers simplified operations with <see cref="EventHandler"/> objects.
    /// </summary>
    public static class EventHandlerExtensions
    {
        /// <summary>
        /// Invokes the delegate with the specified parameters if the delegate is not null.
        /// </summary>
        public static void Raise(this EventHandler self, object sender, EventArgs e) => self?.Invoke(sender, e);

        /// <summary>
        /// Invokes the delegate with the specified parameters if the delegate is not null.
        /// </summary>
        public static void Raise<T>(this EventHandler<T> self, object sender, T e)
            where T : EventArgs => self?.Invoke(sender, e);

        /// <summary>
        /// Converts an <see cref="EventHandler"/> delegate type to an <see cref="Action"/> delegate type.
        /// </summary>
        public static Action<object, EventArgs> ToAction(this EventHandler self) => (o, e) => self(o, e);

        /// <summary>
        /// Converts an <see cref="Action"/> delegate type to an <see cref="EventHandler"/> delegate type.
        /// </summary>
        public static EventHandler ToEventHandler(this Action<object, EventArgs> self) => (o, e) => self(o, e);

        /// <summary>
        /// Converts an <see cref="EventHandler"/> delegate type to an <see cref="Action"/> delegate type.
        /// </summary>
        public static Action<object, T> ToAction<T>(this EventHandler<T> self)
            where T : EventArgs => (o, e) => self(o, e);

        /// <summary>
        /// Converts an <see cref="Action"/> delegate type to an <see cref="EventHandler"/> delegate type.
        /// </summary>
        public static EventHandler<T> ToEventHandler<T>(this Action<object, T> self)
            where T : EventArgs => (o, e) => self(o, e);
    }
}