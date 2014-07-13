using System;

namespace Sugar
{
    public static class DoubleComparableExtensions
    {
        public static FluentPredicate<double> Positive(this IFluentExpression<double> self)
        {
            return self.Generate(x => x >= 0);
        }
        public static FluentPredicate<double> Negative(this IFluentExpression<double> self)
        {
            return self.Generate(x => x < 0);
        }
        public static FluentPredicate<double> PositiveInfinity(this IFluentExpression<double> self)
        {
            return self.Generate(double.IsPositiveInfinity);
        }
        public static FluentPredicate<double> NegativeInfinity(this IFluentExpression<double> self)
        {
            return self.Generate(double.IsNegativeInfinity);
        }
        public static FluentPredicate<double> Infinity(this IFluentExpression<double> self)
        {
            return self.Generate(double.IsInfinity);
        }
        public static FluentPredicate<double> NaN(this IFluentExpression<double> self)
        {
            return self.Generate(double.IsNaN);
        }

        public static FluentPredicate<double> Generate(this IFluentExpression<double, FluentPredicate<double>> self,
            Func<double, bool> predicate)
        {
            return new FluentPredicate<double>(self.Context, predicate(self.Context));
        }
    }
}