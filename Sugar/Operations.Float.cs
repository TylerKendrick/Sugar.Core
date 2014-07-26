internal static partial class Operations
{
    internal static class Float
    {
        internal static float OnAdd(float left, float right)
        {
            return left + right;
        }


        internal static float OnSubtract(float left, float right)
        {
            return left - right;
        }


        internal static float OnMultiply(float left, float right)
        {
            return left * right;
        }


        internal static float OnDivide(float left, float right)
        {
            return left / right;
        }


        internal static float OnModulo(float left, float right)
        {
            return left % right;
        }


        internal static float OnNegate(float target)
        {
            return -target;
        }


        internal static float OnIncrement(float target)
        {
            return target + 1;
        }


        internal static float OnDecrement(float target)
        {
            return target - 1;
        }

        internal static bool OnGreaterThan(float left, float right)
        {
            return left > right;
        }


        internal static bool OnGreaterThanOrEqual(float left, float right)
        {
            return left >= right;
        }


        internal static bool OnLessThan(float left, float right)
        {
            return left < right;
        }


        internal static bool OnLessThanOrEqual(float left, float right)
        {
            return left <= right;
        }


        internal static bool OnEquality(float left, float right)
        {
            return System.Math.Abs(left - right) < float.Epsilon;
        }


        internal static bool OnInequality(float left, float right)
        {
            return System.Math.Abs(left - right) > float.Epsilon;
        }
    }
}