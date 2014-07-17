namespace System
{
    public static class DecimalComparableExtensions
    {
        public static FluentPredicate<decimal> Positive(this IFluentExpression<decimal> self)
        {
            return self.Generate(x => x.IsPositive());
        }
        public static FluentPredicate<decimal> Negative(this IFluentExpression<decimal> self)
        {
            return self.Generate(x => x.IsNegative());
        }
    }
}