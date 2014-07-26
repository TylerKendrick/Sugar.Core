public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="TimeSpan"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class TimeSpan
    {
        public static readonly Binary<System.TimeSpan, System.TimeSpan, System.TimeSpan> Add = (left, right) => left + right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, System.TimeSpan> Subtract = (left, right) => left - right;
        public static readonly Unary<System.TimeSpan, System.TimeSpan> Negate = target => -target;

        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> GreaterThan = (left, right) => left > right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> GreaterThanOrEqual = (left, right) => left >= right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> LessThan = (left, right) => left < right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> LessThanOrEqual = (left, right) => left <= right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> Equality = (left, right) => left == right;
        public static readonly Binary<System.TimeSpan, System.TimeSpan, bool> Inequality = (left, right) => left != right;
    }
}