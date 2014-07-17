namespace System
{
    /// <summary>
    /// Exposes common operations with DateTime objects as extension methods.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Compares the Date property of the specified <see cref="DateTime"/>
        /// <paramref name="self"/> with the Date property of DateTime.Today
        /// </summary>
        public static bool IsToday(this DateTime self)
        {
            return self.Date == DateTime.Today.Date;
        }

        /// <summary>
        /// Compares the Date property of the specified <see cref="DateTime"/>
        /// <paramref name="self"/> with the Date property of DateTime.Today - 1 day
        /// </summary>
        public static bool IsYesterday(this DateTime self)
        {
            return self.Date == DateTime.Today.Date.AddDays(-1);
        }

        /// <summary>
        /// Compares the Date property of the specified <see cref="DateTime"/>
        /// <paramref name="self"/> with the Date property of DateTime.Today + 1 day
        /// </summary>
        public static bool IsTomorrow(this DateTime self)
        {
            return self.Date == DateTime.Today.Date.AddDays(1);
        }

        /// <summary>
        /// Compares the TimeOfDay property of the specified <see cref="DateTime"/>
        /// <paramref name="self"/> with the Date property of
        /// the specified comparable <paramref name="other"/>.
        /// </summary>
        public static bool IsSameTimeAs(this DateTime self, DateTime other)
        {
            return self.TimeOfDay == other.TimeOfDay;
        }

        /// <summary>
        /// Compares the Date property of the specified <see cref="DateTime"/>
        /// <paramref name="self"/> with the Date property of
        /// the specified comparable <paramref name="other"/>.
        /// </summary>
        public static bool IsSameDateAs(this DateTime self, DateTime other)
        {
            return self.Date == other.Date;
        }

        /// <summary>
        /// Compares the Year property of the specified <see cref="DateTime"/>
        /// <paramref name="self"/> with the Year property of
        /// the specified comparable <paramref name="other"/>.
        /// </summary>
        public static bool IsSameYearAs(this DateTime self, DateTime other)
        {
            return self.Year == other.Year;
        }


        /// <summary>
        /// Compares the Month property of the specified <see cref="DateTime"/>
        /// <paramref name="self"/> with the Month property of
        /// the specified comparable <paramref name="other"/>.
        /// </summary>
        public static bool IsSameMonthAs(this DateTime self, DateTime other)
        {
            return self.Month == other.Month;
        }

        /// <summary>
        /// Compares the DayOfWeek property of the specified <see cref="DateTime"/>
        /// <paramref name="self"/> with the specified comparable <paramref name="dayOfWeek"/>.
        /// </summary>
        public static bool IsDayOfWeek(this DateTime self, DayOfWeek dayOfWeek)
        {
            return self.DayOfWeek == dayOfWeek;
        }

        /// <summary>
        /// Compares the Month property of the specified <see cref="DateTime"/>
        /// <paramref name="self"/> with the specified comparable <paramref name="monthOfYear"/>.
        /// </summary>
        public static bool IsMonthOfYear(this DateTime self, MonthOfYear monthOfYear)
        {
            return self.Month == (int)monthOfYear;
        }

        /// <summary>
        /// Exposes the static method DateTime.IsLeapYear as an exextsion to <see cref="DateTime"/> instances.
        /// </summary>
        public static bool IsLeapYear(this DateTime self)
        {
            return DateTime.IsLeapYear(self.Year);
        }
    }
}
