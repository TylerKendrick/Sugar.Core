using System;

namespace Sugar
{
    public static class DecimalComparableExtensions
    {
        public static FluentPredicate<decimal> Positive(this IFluentExpression<decimal> self)
        {
            return self.Generate(x => x >= 0);
        }
        public static FluentPredicate<decimal> Negative(this IFluentExpression<decimal> self)
        {
            return self.Generate(x => x < 0);
        }

        public static FluentPredicate<decimal> Generate(this IFluentExpression<decimal, FluentPredicate<decimal>> self,
            Func<decimal, bool> predicate)
        {
            return new FluentPredicate<decimal>(self.Context, predicate(self.Context));
        }
    }
}