public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Float"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Float
    {
        public static readonly Binary<float, float, float> Add = (left, right) => left + right;
        public static readonly Binary<float, float, float> Subtract = (left, right) => left - right;
        public static readonly Binary<float, float, float> Multiply = (left, right) => left * right;
        public static readonly Binary<float, float, float> Divide = (left, right) => left / right;
        public static readonly Binary<float, float, float> Modulo = (left, right) => left % right;
        public static readonly Unary<float, float> Negate = target => -target;
        public static readonly Unary<float, float> Increment = target => target + 1;
        public static readonly Unary<float, float> Decrement = target => target - 1;

        public static readonly Binary<float, float, bool> GreaterThan = (left, right) => left > right;
        public static readonly Binary<float, float, bool> GreaterThanOrEqual = (left, right) => left >= right;
        public static readonly Binary<float, float, bool> LessThan = (left, right) => left < right;
        public static readonly Binary<float, float, bool> LessThanOrEqual = (left, right) => left <= right;
        public static readonly Binary<float, float, bool> Equality = (left, right) => left == right;
        public static readonly Binary<float, float, bool> Inequality = (left, right) => left != right;
    }
}