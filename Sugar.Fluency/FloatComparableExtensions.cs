using System;

namespace Sugar
{
    public static class FloatComparableExtensions
    {
        public static ConditionalExpression<float> Positive(this IComparableExpression<float> self)
        {
            return self.Generate(x => x >= 0);
        }
        public static ConditionalExpression<float> Negative(this IComparableExpression<float> self)
        {
            return self.Generate(x => x < 0);
        }

        public static ConditionalExpression<float> Generate(this IComparableExpression<float, ConditionalExpression<float>> self,
            Func<float, bool> predicate)
        {
            return new ConditionalExpression<float>(self.Context, predicate(self.Context));
        }
    }
}