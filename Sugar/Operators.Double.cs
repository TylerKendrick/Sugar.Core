public static partial class Operators
{
    public static class Double
    {
        public static readonly Binary<double, double, double> Add = (left, right) => left + right;
        public static readonly Binary<double, double, double> Subtract = (left, right) => left - right;
        public static readonly Binary<double, double, double> Multiply = (left, right) => left * right;
        public static readonly Binary<double, double, double> Divide = (left, right) => left / right;
        public static readonly Binary<double, double, double> Modulo = (left, right) => left % right;
        public static readonly Unary<double, double> Negate = target => -target;
        public static readonly Unary<double, double> Increment = target => target + 1;
        public static readonly Unary<double, double> Decrement = target => target - 1;

        public static readonly Binary<double, double, bool> GreaterThan = (left, right) => left > right;
        public static readonly Binary<double, double, bool> GreaterThanOrEqual = (left, right) => left >= right;
        public static readonly Binary<double, double, bool> LessThan = (left, right) => left < right;
        public static readonly Binary<double, double, bool> LessThanOrEqual = (left, right) => left <= right;
        public static readonly Binary<double, double, bool> Equal = (left, right) => left == right;
        public static readonly Binary<double, double, bool> NotEqual = (left, right) => left != right;
    }
}