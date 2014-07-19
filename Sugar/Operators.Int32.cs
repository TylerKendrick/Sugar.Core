public static partial class Operators
{
    public static class Int32
    {
        public static readonly Binary<int, int, int> ShiftLeft = (left, right) => left << right;
        public static readonly Binary<int, int, int> ShiftRight = (left, right) => left >> right;
        public static readonly Binary<int, int, int> And = (left, right) => left & right;
        public static readonly Binary<int, int, int> Or = (left, right) => left | right;
        public static readonly Binary<int, int, int> XOr = (left, right) => left ^ right;
        public static readonly Unary<int, int> Not = target => ~target;

        public static readonly Binary<int, int, int> Add = (left, right) => left + right;
        public static readonly Binary<int, int, int> Subtract = (left, right) => left - right;
        public static readonly Binary<int, int, int> Multiply = (left, right) => left * right;
        public static readonly Binary<int, int, int> Divide = (left, right) => left / right;
        public static readonly Binary<int, int, int> Modulo = (left, right) => left % right;
        public static readonly Unary<int, int> Negate = target => -target;
        public static readonly Unary<int, int> Increment = target => target + 1;
        public static readonly Unary<int, int> Decrement = target => target - 1;

        public static readonly Binary<int, int, bool> GreaterThan = (left, right) => left > right;
        public static readonly Binary<int, int, bool> GreaterThanOrEqual = (left, right) => left >= right;
        public static readonly Binary<int, int, bool> LessThan = (left, right) => left < right;
        public static readonly Binary<int, int, bool> LessThanOrEqual = (left, right) => left <= right;
        public static readonly Binary<int, int, bool> Equal = (left, right) => left == right;
        public static readonly Binary<int, int, bool> NotEqual = (left, right) => left != right;
    }
}