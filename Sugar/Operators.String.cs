public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="String"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class String
    {
        public static readonly Binary<string, string, string> Add = (left, right) => left + right;

        public static readonly Binary<string, string, bool> Equality = (left, right) => left == right;
        public static readonly Binary<string, string, bool> Inequality = (left, right) => left != right;
    }
}