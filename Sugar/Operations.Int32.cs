internal static partial class Operations
{
    internal static class Int32
    {
        internal static int NotOperation(int target)
        {
            return ~target;
        }

        internal static int XOrOperation(int left, int right)
        {
            return left ^ right;
        }

        internal static int OrOperation(int left, int right)
        {
            return left | right;
        }

        internal static int AndOperation(int left, int right)
        {
            return left & right;
        }

        internal static int ShiftRightOperation(int left, int right)
        {
            return left >> right;
        }

        internal static int ShiftLeftOperation(int left, int right)
        {
            return left << right;
        }


        internal static bool LessThanOperation(int left, int right)
        {
            return left < right;
        }

        internal static bool LessThanOrEqualToOperation(int left, int right)
        {
            return left <= right;
        }

        internal static bool EqualityOperation(int left, int right)
        {
            return left == right;
        }

        internal static bool InequalityOperation(int left, int right)
        {
            return left != right;
        }

        internal static bool GreaterThanOrEqualOperation(int left, int right)
        {
            return left >= right;
        }

        internal static bool GreaterThanOperation(int left, int right)
        {
            return left > right;
        }

        internal static int AddOperation(int left, int right)
        {
            return left + right;
        }

        internal static int SubtractOperation(int left, int right)
        {
            return left - right;
        }

        internal static int MultiplyOperation(int left, int right)
        {
            return left * right;
        }

        internal static int DivideOperation(int left, int right)
        {
            return left / right;
        }

        internal static int ModuloOperation(int left, int right)
        {
            return left % right;
        }

        internal static int NegateOperation(int target)
        {
            return -target;
        }

        internal static int IncrementOperation(int target)
        {
            return target + 1;
        }

        internal static int DecrementOperation(int target)
        {
            return target - 1;
        }
    }
}