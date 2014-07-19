public static partial class Operators
{
    public static class TimeSpan
    {
        public static readonly Binary<System.TimeSpan, System.TimeSpan, System.TimeSpan> Add = (left, right) => left + right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, System.TimeSpan> Subtract = (left, right) => left - right;
        public static readonly Unary<System.TimeSpan, System.TimeSpan> Negate = target => -target;

        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> GreaterThan = (left, right) => left > right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> GreaterThanOrEqual = (left, right) => left >= right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> LessThan = (left, right) => left < right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> LessThanOrEqual = (left, right) => left <= right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> Equal = (left, right) => left == right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> NotEqual = (left, right) => left != right;
    }
}