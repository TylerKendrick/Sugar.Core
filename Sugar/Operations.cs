internal static partial class Operations
{
    internal static class Long
    {
        internal static long ShiftLeftOperation(long left, int right)
        {
            return left << right;
        }
        internal static long OnShiftRight(long left, int right)
        {
            return left >> right;
        }

        internal static long OnAnd(long left, long right)
        {
            return left & right;
        }

        internal static long OnOr(long left, long right)
        {
            return left | right;
        }

        internal static long OnXOr(long left, long right)
        {
            return left ^ right;
        }

        internal static long OnNot(long target)
        {
            return ~target;
        }

        internal static long OnAdd(long left, long right)
        {
            return left + right;
        }

        internal static long OnSubtract(long left, long right)
        {
            return left - right;
        }

        internal static long OnMultiply(long left, long right)
        {
            return left * right;
        }

        internal static long OnDivide(long left, long right)
        {
            return left / right;
        }

        internal static long OnModulo(long left, long right)
        {
            return left % right;
        }

        internal static long OnNegate(long target)
        {
            return -target;
        }

        internal static long OnIncrement(long target)
        {
            return target + 1;
        }

        internal static long OnDecrement(long target)
        {
            return target - 1;
        }

        internal static bool OnGreaterThan(long left, long right)
        {
            return left > right;
        }

        internal static bool OnGreaterThanOrEqual(long left, long right)
        {
            return left >= right;
        }

        internal static bool OnLessThan(long left, long right)
        {
            return left < right;
        }

        internal static bool OnLessThanOrEqual(long left, long right)
        {
            return left <= right;
        }

        internal static bool OnEquality(long left, long right)
        {
            return left == right;
        }

        internal static bool OnInequality(long left, long right)
        {
            return left != right;
        }
    }
}