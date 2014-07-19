public static partial class Operators
{
    public static class String
    {
        public static readonly Binary<string, string, string> Add = (left, right) => left + right;

        public static readonly Binary<string, string, bool> Equal = (left, right) => left == right;
        public static readonly Binary<string, string, bool> NotEqual = (left, right) => left != right;
    }
}