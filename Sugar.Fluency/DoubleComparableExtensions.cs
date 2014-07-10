using System;

namespace Sugar
{
    public static class DoubleComparableExtensions
    {
        public static ConditionalExpression<double> Positive(this IComparableExpression<double> self)
        {
            return self.Generate(x => x >= 0);
        }
        public static ConditionalExpression<double> Negative(this IComparableExpression<double> self)
        {
            return self.Generate(x => x < 0);
        }
        public static ConditionalExpression<double> PositiveInfinity(this IComparableExpression<double> self)
        {
            return self.Generate(double.IsPositiveInfinity);
        }
        public static ConditionalExpression<double> NegativeInfinity(this IComparableExpression<double> self)
        {
            return self.Generate(double.IsNegativeInfinity);
        }
        public static ConditionalExpression<double> Infinity(this IComparableExpression<double> self)
        {
            return self.Generate(double.IsInfinity);
        }
        public static ConditionalExpression<double> NaN(this IComparableExpression<double> self)
        {
            return self.Generate(double.IsNaN);
        }

        public static ConditionalExpression<double> Generate(this IComparableExpression<double, ConditionalExpression<double>> self,
            Func<double, bool> predicate)
        {
            return new ConditionalExpression<double>(self.Context, predicate(self.Context));
        }
    }
}