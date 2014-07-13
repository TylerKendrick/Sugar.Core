using Sugar.Extensions;

namespace Sugar
{
    public static class IntComparableExtensions
    {
        public static FluentPredicate<int> IsEven(this IFluentExpression<int> self)
        {
            return self.Generate(x=> (x & 1) == 0);
        }
        public static FluentPredicate<int> IsOdd(this IFluentExpression<int> self)
        {
            return self.Generate(x => (x & 1) != 0);
        }
        public static FluentPredicate<int> Positive(this IFluentExpression<int> self)
        {
            return self.Generate(x => x >= 0);
        }
        public static FluentPredicate<int> Negative(this IFluentExpression<int> self)
        {
            return self.Generate(x => x < 0);
        }
    }
}
