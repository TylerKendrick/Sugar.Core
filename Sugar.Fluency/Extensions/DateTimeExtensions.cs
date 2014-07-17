using System;

namespace Sugar
{
    public static class DateTimeExtensions
    {
        public static FluentPredicate<DateTime> DaylightSavingTime(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.IsDaylightSavingTime());
        }

        public static FluentPredicate<DateTime> Today(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.IsToday());
        }

        public static FluentPredicate<DateTime> Yesterday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.IsYesterday());
        }

        public static FluentPredicate<DateTime> Tomorrow(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.IsTomorrow());
        }

        public static FluentPredicate<DateTime> SameTimeAs(this IFluentExpression<DateTime> self, DateTime other)
        {
            return self.Generate(x => x.IsSameTimeAs(other));
        }

        public static FluentPredicate<DateTime> SameDateAs(this IFluentExpression<DateTime> self, DateTime other)
        {
            return self.Generate(x => x.IsSameDateAs(other));
        }

        public static FluentPredicate<DateTime> SameYearAs(this IFluentExpression<DateTime> self, DateTime other)
        {
            return self.Generate(x => x.IsSameYearAs(other));
        }

        public static FluentPredicate<DateTime> SameMonthAs(this IFluentExpression<DateTime> self, DateTime other)
        {
            return self.Generate(x => x.IsSameMonthAs(other));
        }

        public static FluentPredicate<DateTime> DayOfWeek(this IFluentExpression<DateTime> self, DayOfWeek dayOfWeek)
        {
            return self.Generate(x => x.DayOfWeek == dayOfWeek);
        }

        public static FluentPredicate<DateTime> Monday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == System.DayOfWeek.Monday);
        }
        public static FluentPredicate<DateTime> Tuesday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == System.DayOfWeek.Tuesday);
        }
        public static FluentPredicate<DateTime> Wednesday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == System.DayOfWeek.Wednesday);
        }
        public static FluentPredicate<DateTime> Thursday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == System.DayOfWeek.Thursday);
        }
        public static FluentPredicate<DateTime> Friday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == System.DayOfWeek.Friday);
        }
        public static FluentPredicate<DateTime> Saturday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == System.DayOfWeek.Saturday);
        }
        public static FluentPredicate<DateTime> Sunday(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.DayOfWeek == System.DayOfWeek.Sunday);
        }

        public static FluentPredicate<DateTime> MonthOfYear(this IFluentExpression<DateTime> self, MonthOfYear monthOfYear)
        {
            return self.Generate(x => x.IsMonthOfYear(monthOfYear));
        }

        public static FluentPredicate<DateTime> January(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.January);
        }
        public static FluentPredicate<DateTime> February(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.February);
        }
        public static FluentPredicate<DateTime> March(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.March);
        }
        public static FluentPredicate<DateTime> April(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.April);
        }
        public static FluentPredicate<DateTime> May(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.May);
        }
        public static FluentPredicate<DateTime> June(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.June);
        }
        public static FluentPredicate<DateTime> July(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.July);
        }
        public static FluentPredicate<DateTime> August(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.August);
        }
        public static FluentPredicate<DateTime> September(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.September);
        }
        public static FluentPredicate<DateTime> October(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.October);
        }
        public static FluentPredicate<DateTime> November(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.November);
        }
        public static FluentPredicate<DateTime> December(this IFluentExpression<DateTime> self)
        {
            return MonthOfYear(self, Sugar.MonthOfYear.December);
        }

        public static FluentPredicate<DateTime> LeapYear(this IFluentExpression<DateTime> self)
        {
            return self.Generate(x => x.IsLeapYear());
        }
    }
}