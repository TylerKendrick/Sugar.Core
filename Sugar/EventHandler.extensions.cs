using System;
using Sugar.Observables;

namespace Sugar
{
    /// <summary>
    /// Providers simplified operations with <see cref="EventHandler"/> objects.
    /// </summary>
    public static class EventHandlerExtensions
    {
        /// <summary>
        /// Invokes the delegate with the specified parameters if the delegate is not null.
        /// </summary>
        public static void Raise(this EventHandler self, object sender, EventArgs e)
        {
            if (self != null) self(sender, e);
        }

        /// <summary>
        /// Invokes the delegate with the specified parameters if the delegate is not null.
        /// </summary>
        public static void Raise<T>(this EventHandler<T> self, object sender, T e)
            where T : EventArgs
        {
            if (self != null) self(sender, e);
        }

        /// <summary>
        /// Returns a <see cref="IDisposable"/> context to the subscribed listener.
        /// </summary>
        public static IDisposable Subscribe(this EventHandler self, EventHandler listener)
        {
            self.Require();
            listener.Require();

            self += listener;
            return new Disposable(() => self -= listener);
        }

        /// <summary>
        /// Returns a <see cref="IDisposable"/> context to the subscribed listener.
        /// </summary>
        public static IDisposable Subscribe<T>(this EventHandler<T> self, EventHandler<T> listener)
        {
            self.Require();
            listener.Require();
            self += listener;
            return new Disposable(() => self -= listener);
        }

        /// <summary>
        /// Converts an <see cref="EventHandler"/> delegate type to an <see cref="Action"/> delegate type.
        /// </summary>
        public static Action<object, EventArgs> ToAction(this EventHandler self)
        {
            return (o, e) => self(o, e);
        }

        /// <summary>
        /// Converts an <see cref="Action"/> delegate type to an <see cref="EventHandler"/> delegate type.
        /// </summary>
        public static EventHandler ToEventHandler(this Action<object, EventArgs> self)
        {
            return (o, e) => self(o, e);
        }

        /// <summary>
        /// Converts an <see cref="EventHandler"/> delegate type to an <see cref="Action"/> delegate type.
        /// </summary>
        public static Action<object, T> ToAction<T>(this EventHandler<T> self)
            where T : EventArgs
        {
            return (o, e) => self(o, e);
        }

        /// <summary>
        /// Converts an <see cref="Action"/> delegate type to an <see cref="EventHandler"/> delegate type.
        /// </summary>
        public static EventHandler<T> ToEventHandler<T>(this Action<object, T> self)
            where T : EventArgs
        {
            return (o, e) => self(o, e);
        }
    }
}