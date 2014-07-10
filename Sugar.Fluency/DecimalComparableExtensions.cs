using System;

namespace Sugar
{
    public static class DecimalComparableExtensions
    {
        public static ConditionalExpression<decimal> Positive(this IComparableExpression<decimal> self)
        {
            return self.Generate(x => x >= 0);
        }
        public static ConditionalExpression<decimal> Negative(this IComparableExpression<decimal> self)
        {
            return self.Generate(x => x < 0);
        }

        public static ConditionalExpression<decimal> Generate(this IComparableExpression<decimal, ConditionalExpression<decimal>> self,
            Func<decimal, bool> predicate)
        {
            return new ConditionalExpression<decimal>(self.Context, predicate(self.Context));
        }
    }
}