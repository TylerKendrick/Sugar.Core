public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="DateTime"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class DateTime
    {
        public static readonly Binary<System.DateTime, System.TimeSpan, System.DateTime> Add = (left, right) => left + right;
        public static readonly Binary<System.DateTime, System.TimeSpan, System.DateTime> Subtract = (left, right) => left - right;

        public static readonly Binary<System.DateTime, System.DateTime, bool> GreaterThan = (left, right) => left > right;
        public static readonly Binary<System.DateTime, System.DateTime, bool> GreaterThanOrEqual = (left, right) => left >= right;
        public static readonly Binary<System.DateTime, System.DateTime, bool> LessThan = (left, right) => left < right;
        public static readonly Binary<System.DateTime, System.DateTime, bool> LessThanOrEqual = (left, right) => left <= right;
        public static readonly Binary<System.DateTime, System.DateTime, bool> Equality = (left, right) => left == right;
        public static readonly Binary<System.DateTime, System.DateTime, bool> Inequality = (left, right) => left != right;
    }
}