using System;

namespace Sugar
{
    public static class IntComparableExtensions
    {
        public static ConditionalExpression<int> IsEven(this IComparableExpression<int> self)
        {
            return self.Generate(x=> (x & 1) == 0);
        }
        public static ConditionalExpression<int> IsOdd(this IComparableExpression<int> self)
        {
            return self.Generate(x => (x & 1) != 0);
        }
        public static ConditionalExpression<int> Positive(this IComparableExpression<int> self)
        {
            return self.Generate(x => x >= 0);
        }
        public static ConditionalExpression<int> Negative(this IComparableExpression<int> self)
        {
            return self.Generate(x => x < 0);
        }

        public static ConditionalExpression<int> Generate(this IComparableExpression<int, ConditionalExpression<int>> self,
            Func<int, bool> predicate)
        {
            return new ConditionalExpression<int>(self.Context, predicate(self.Context));
        }
    }
}
