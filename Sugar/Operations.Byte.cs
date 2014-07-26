internal static partial class Operations
{
    internal static class Byte
    {
        internal static int OnShiftLeft(byte left, int right)
        {
            return left << right;
        }


        internal static int OnShiftRight(byte left, int right)
        {
            return left >> right;
        }


        internal static int OnAnd(byte left, byte right)
        {
            return left & right;
        }


        internal static int OnOr(byte left, byte right)
        {
            return left | right;
        }


        internal static int OnXOr(byte left, byte right)
        {
            return left ^ right;
        }

        internal static bool OnGreaterThan(byte left, byte right)
        {
            return left > right;
        }


        internal static bool OnGreaterThanOrEqual(byte left, byte right)
        {
            return left >= right;
        }


        internal static bool OnLessThan(byte left, byte right)
        {
            return left < right;
        }


        internal static bool OnLessThanOrEqual(byte left, byte right)
        {
            return left <= right;
        }


        internal static bool OnEquality(byte left, byte right)
        {
            return left == right;
        }


        internal static bool OnInequality(byte left, byte right)
        {
            return left != right;
        }


        internal static int OnNot(byte target)
        {
            return ~target;
        }
    }
}