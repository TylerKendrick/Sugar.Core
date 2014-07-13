namespace Sugar
{
    public static class BooleanFluentExtesions
    {
        public static FluentPredicate<bool> True(this IFluentExpression<bool> self)
        {
            return self.Generate(x => x);
        }

        public static FluentPredicate<bool> False(this IFluentExpression<bool> self)
        {
            return self.Generate(x => !x);
        }
    }
}
