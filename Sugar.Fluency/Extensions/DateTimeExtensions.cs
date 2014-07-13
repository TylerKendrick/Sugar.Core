using System;

namespace Sugar
{
    public static class DateTimeExtensions
    {
        public static FluentPredicate<DateTime> IsDaylightSavingTime(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.IsDaylightSavingTime());
        }

        public static FluentPredicate<DateTime> Monday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == DayOfWeek.Monday);
        }
        public static FluentPredicate<DateTime> Tuesday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == DayOfWeek.Tuesday);
        }
        public static FluentPredicate<DateTime> Wednesday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == DayOfWeek.Wednesday);
        }
        public static FluentPredicate<DateTime> Thursday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == DayOfWeek.Thursday);
        }
        public static FluentPredicate<DateTime> Friday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == DayOfWeek.Friday);
        }
        public static FluentPredicate<DateTime> Saturday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == DayOfWeek.Saturday);
        }
        public static FluentPredicate<DateTime> Sunday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == DayOfWeek.Sunday);
        }

        public static FluentPredicate<DateTime> LeapYear(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => DateTime.IsLeapYear(x.Year));
        }
    }
}
