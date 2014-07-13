namespace Sugar
{
    public static class IntComparableExtensions
    {
        public static FluentPredicate<int> Even(this IFluentExpression<int> self)
        {
            return self.Generate(x=> (x & 1) == 0);
        }
        public static FluentPredicate<int> Odd(this IFluentExpression<int> self)
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
