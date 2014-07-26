public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="EventHandler"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class EventHandler
    {
        public static readonly Binary<System.EventHandler, System.EventHandler, System.EventHandler> Combine =
            (left, right) => left + right;
        public static readonly Binary<System.EventHandler, System.EventHandler, System.EventHandler> Subscribe =
            (left, right) => left + right;
        public static readonly Binary<System.EventHandler, System.EventHandler, System.EventHandler> Unsubscribe =
            (left, right) => left - right;
    }
}