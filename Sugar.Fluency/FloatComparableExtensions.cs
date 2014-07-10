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
        public static ConditionalExpression<float> PositiveInfinity(this IComparableExpression<float> self)
        {
            return self.Generate(float.IsPositiveInfinity);
        }
        public static ConditionalExpression<float> NegativeInfinity(this IComparableExpression<float> self)
        {
            return self.Generate(float.IsNegativeInfinity);
        }
        public static ConditionalExpression<float> Infinity(this IComparableExpression<float> self)
        {
            return self.Generate(float.IsInfinity);
        }
        public static ConditionalExpression<float> NaN(this IComparableExpression<float> self)
        {
            return self.Generate(float.IsNaN);
        }


        public static ConditionalExpression<float> Generate(this IComparableExpression<float, ConditionalExpression<float>> self,
            Func<float, bool> predicate)
        {
            return new ConditionalExpression<float>(self.Context, predicate(self.Context));
        }
    }
}