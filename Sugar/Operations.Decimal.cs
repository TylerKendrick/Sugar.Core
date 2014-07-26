internal static partial class Operations
{
    internal static class Decimal
    {
        internal static decimal OnAdd(decimal left, decimal right)
        {
            return left + right;
        }


        internal static decimal OnSubtract(decimal left, decimal right)
        {
            return left - right;
        }


        internal static decimal OnMultiply(decimal left, decimal right)
        {
            return left * right;
        }


        internal static decimal OnDivide(decimal left, decimal right)
        {
            return left / right;
        }


        internal static decimal OnModulo(decimal left, decimal right)
        {
            return left % right;
        }


        internal static decimal OnNegate(decimal target)
        {
            return -target;
        }


        internal static decimal OnIncrement(decimal target)
        {
            return target + 1;
        }


        internal static decimal OnDecrement(decimal target)
        {
            return target - 1;
        }


        internal static bool OnGreaterThan(decimal left, decimal right)
        {
            return left > right;
        }


        internal static bool OnGreaterThanOrEqual(decimal left, decimal right)
        {
            return left >= right;
        }


        internal static bool OnLessThan(decimal left, decimal right)
        {
            return left < right;
        }


        internal static bool OnLessThanOrEqual(decimal left, decimal right)
        {
            return left <= right;
        }


        internal static bool OnEquality(decimal left, decimal right)
        {
            return left == right;
        }


        internal static bool OnInequality(decimal left, decimal right)
        {
            return left != right;
        }
    }
}