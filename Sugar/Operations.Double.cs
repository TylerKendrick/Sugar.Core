internal static partial class Operations
{
    internal static class Double
    {
        internal static double OnAdd(double left, double right)
        {
            return left + right;
        }

        internal static double OnSubtract(double left, double right)
        {
            return left - right;
        }

        internal static double OnMultiply(double left, double right)
        {
            return left * right;
        }

        internal static double OnDivide(double left, double right)
        {
            return left / right;
        }

        internal static double OnModulo(double left, double right)
        {
            return left % right;
        }

        internal static double OnNegate(double target)
        {
            return -target;
        }

        internal static double OnIncrement(double target)
        {
            return target + 1;
        }

        internal static double OnDecrement(double target)
        {
            return target - 1;
        }

        internal static bool OnGreaterThan(double left, double right)
        {
            return left > right;
        }


        internal static bool OnGreaterThanOrEqual(double left, double right)
        {
            return left >= right;
        }


        internal static bool OnLessThan(double left, double right)
        {
            return left < right;
        }


        internal static bool OnLessThanOrEqual(double left, double right)
        {
            return left <= right;
        }


        internal static bool OnEquality(double left, double right)
        {
            return System.Math.Abs(left - right) < double.Epsilon;
        }


        internal static bool OnInequality(double left, double right)
        {
            return System.Math.Abs(left - right) > double.Epsilon;
        }
    }
}