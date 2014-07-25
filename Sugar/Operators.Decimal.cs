public static partial class Operators
{
    public static class Decimal
    {
        public static readonly Binary<decimal, decimal, decimal> Add = (left, right) => left + right;
        public static readonly Binary<decimal, decimal, decimal> Subtract = (left, right) => left - right;
        public static readonly Binary<decimal, decimal, decimal> Multiply = (left, right) => left * right;
        public static readonly Binary<decimal, decimal, decimal> Divide = (left, right) => left / right;
        public static readonly Binary<decimal, decimal, decimal> Modulo = (left, right) => left % right;
        public static readonly Unary<decimal, decimal> Negate = target => -target;
        public static readonly Unary<decimal, decimal> Increment = target => target + 1;
        public static readonly Unary<decimal, decimal> Decrement = target => target - 1;

        public static readonly Binary<decimal, decimal, bool> GreaterThan = (left, right) => left > right;
        public static readonly Binary<decimal, decimal, bool> GreaterThanOrEqual = (left, right) => left >= right;
        public static readonly Binary<decimal, decimal, bool> LessThan = (left, right) => left < right;
        public static readonly Binary<decimal, decimal, bool> LessThanOrEqual = (left, right) => left <= right;
        public static readonly Binary<decimal, decimal, bool> Equality = (left, right) => left == right;
        public static readonly Binary<decimal, decimal, bool> Inequality = (left, right) => left != right;
    }
}