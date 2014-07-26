public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Boolean"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Boolean
    {
        public static readonly Binary<bool, bool, bool> And = (left, right) => left && right;
        public static readonly Binary<bool, bool, bool> Or = (left, right) => left || right;
        public static readonly Unary<bool, bool> Not = target => !target;

        public static readonly Binary<bool, bool, bool> Equality = (left, right) => left == right;
        public static readonly Binary<bool, bool, bool> Inequality = (left, right) => left != right;
    }
}