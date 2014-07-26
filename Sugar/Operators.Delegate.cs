public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Delegate"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Delegate
    {
        public static readonly Binary<System.Delegate, System.Delegate, bool> Equality = (left, right) => left == right;
        public static readonly Binary<System.Delegate, System.Delegate, bool> Inequality = (left, right) => left != right;

        public static readonly Binary<System.Delegate, System.Delegate, System.Delegate> Combine =
            (left, right) => System.Delegate.Combine(left, right);
    }
}