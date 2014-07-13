namespace Sugar
{
    public static class FloatComparableExtensions
    {
        public static FluentPredicate<float> Positive(this IFluentExpression<float> self)
        {
            return self.Generate(x => x >= 0);
        }
        public static FluentPredicate<float> Negative(this IFluentExpression<float> self)
        {
            return self.Generate(x => x < 0);
        }
        public static FluentPredicate<float> PositiveInfinity(this IFluentExpression<float> self)
        {
            return self.Generate(float.IsPositiveInfinity);
        }
        public static FluentPredicate<float> NegativeInfinity(this IFluentExpression<float> self)
        {
            return self.Generate(float.IsNegativeInfinity);
        }
        public static FluentPredicate<float> Infinity(this IFluentExpression<float> self)
        {
            return self.Generate(float.IsInfinity);
        }
        public static FluentPredicate<float> NaN(this IFluentExpression<float> self)
        {
            return self.Generate(float.IsNaN);
        }
    }
}