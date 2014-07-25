public static partial class Operators
{
    public static class EventHandler
    {
        public static readonly Binary<System.EventHandler, System.EventHandler, System.EventHandler> Combine =
            (left, right) => left + right;
        public static readonly Binary<System.EventHandler, System.EventHandler, System.EventHandler> Subscribe =
            (left, right) => left += right;
        public static readonly Binary<System.EventHandler, System.EventHandler, System.EventHandler> Unsubscribe =
            (left, right) => left -= right;
    }
}