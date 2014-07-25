public static partial class Operators
{
    public static class String
    {
        public static readonly Binary<string, string, string> Add = (left, right) => left + right;

        public static readonly Binary<string, string, bool> Equality = (left, right) => left == right;
        public static readonly Binary<string, string, bool> Inequality = (left, right) => left != right;
    }
}