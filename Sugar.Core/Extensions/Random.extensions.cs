namespace System
{
    using Collections.Generic;
    using Globalization;
    using Linq;

    /// <summary>
    /// Provides random values from numeric types, collections, and date-time objects.
    /// </summary>
    public static class RandomExtensions
    {
        private static readonly Random RandomGenerator = new Random();

        /// <summary>
        /// Generates a random item from a collection.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="self">The required random generator.</param>
        /// <param name="collection">The required collection.</param>
        /// <returns>The selected random item from the collection.</returns>
        public static T From<T>(this Random self, IEnumerable<T> collection)
        {
            self.Require();
            Require.That(collection != null);

            var array = collection.ToArray();
            var index = self.Next(0, array.Length);
            return array[index];
        }

        /// <summary>
        /// Generates a random item from a collection.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="self">The required random generator.</param>
        /// <param name="collection">The required collection.</param>
        /// <returns>The selected random item from the collection.</returns>
        public static T From<T>(this Random self, params T[] collection) => collection.Random(self);

        /// <summary>
        /// Returns a random item from a collection
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="self">The target collection.</param>
        /// <param name="randomGenerator">The optional generator for random number selection.</param>
        /// <returns>The item selected from the randomly generated index.</returns>
        public static T Random<T>(this IEnumerable<T> self, Random randomGenerator = null) => randomGenerator
            .Ensure(RandomGenerator)
            .From(self);

        /// <summary>
        /// Returns a random item from a range.
        /// </summary>
        /// <param name="self">The target collection.</param>
        /// <param name="randomGenerator">The optional generator for random number selection.</param>
        /// <returns>The item selected from the randomly generated index.</returns>
        public static int Random(this IRange<int> self, Random randomGenerator = null)
        {
            self.Require();
            return randomGenerator
                .Ensure(RandomGenerator)
                .Next(self.Start, self.End);
        }

        /// <summary>
        /// Returns a random item from a range.
        /// </summary>
        /// <param name="self">The target collection.</param>
        /// <param name="factoryMethod">The method for generating the range items.</param>
        /// <param name="randomGenerator">The optional generator for random number selection.</param>
        /// <returns>The item selected from the randomly generated index.</returns>
        public static T Random<T>(this IRange<T> self, Func<T, T> factoryMethod, Random randomGenerator = null)
            where T : IComparable<T>
        {
            self.Require();
            factoryMethod.Require();
            randomGenerator = randomGenerator ?? RandomGenerator;
            return self.AsEnumerable(factoryMethod).Random(randomGenerator);
        }

        /// <summary>
        /// Returns a random item from a range.
        /// </summary>
        /// <param name="self">The target collection.</param>
        /// <param name="max"></param>
        /// <param name="factoryMethod">The method for generating the range items.</param>
        /// <param name="randomGenerator">The optional generator for random number selection.</param>
        /// <param name="min"></param>
        /// <returns>The item selected from the randomly generated index.</returns>
        public static T Random<T>(this Random self, T min, T max, Func<T, T> factoryMethod, Random randomGenerator = null)
            where T : IComparable<T>
        {
            self.Require();
            factoryMethod.Require();

            randomGenerator = randomGenerator ?? RandomGenerator;
            return Range.From(min, max)
                .Random(factoryMethod, randomGenerator);
        }

        /// <summary>
        /// Returns a random <see cref="DateTime"/> from the provided parameters.
        /// </summary>
        /// <param name="self">The generator for providing values.</param>
        /// <param name="yearRange">A unbounded maximum integer that defaults to 1.</param>
        /// <param name="monthRange">A value between 1 and 12</param>
        /// <param name="dayRange">A value between 1 and 31</param>
        /// <param name="hourRange">A value between 1 and 60</param>
        /// <param name="minuteRange">A value between 1 and 60</param>
        /// <param name="secondRange">A value between 1 and 60</param>
        /// <param name="millisecondRange">A value between 1 and 1000</param>
        /// <param name="calendar">Defaults to the Gregorian calendar.</param>
        /// <param name="kind">Defaults to DateTimeKind.Unspecified.</param>
        /// <param name="randomGenerator">Defaults to the caller random number generator.</param>
        /// <returns>A randomly generated DateTime.</returns>
        public static DateTime Random(this Random self, IRange<int> yearRange = null, IRange<int> monthRange = null,
            IRange<int> dayRange = null, IRange<int> hourRange = null, IRange<int> minuteRange = null, IRange<int> secondRange = null,
            IRange<int> millisecondRange = null, Calendar calendar = null, DateTimeKind kind = DateTimeKind.Unspecified, Random randomGenerator = null)
        {
            self.Require();
            calendar = calendar ?? new GregorianCalendar();
            var max = calendar.MaxSupportedDateTime;
            var min = calendar.MinSupportedDateTime;

            randomGenerator = randomGenerator ?? self;

            return GetRandomDateTime(yearRange, monthRange, dayRange,
                hourRange, minuteRange, secondRange, millisecondRange,
                calendar, kind, randomGenerator, min, max);
        }

        private static DateTime GetRandomDateTime(IRange<int> yearRange, IRange<int> monthRange, IRange<int> dayRange, IRange<int> hourRange,
            IRange<int> minuteRange, IRange<int> secondRange, IRange<int> millisecondRange, Calendar calendar, DateTimeKind kind,
            Random randomGenerator, DateTime min, DateTime max)
        {
            var years = GetRandomYears(yearRange, randomGenerator, min, max);
            var months = GetRandomMonths(monthRange, randomGenerator);
            var daysInMonth = DateTime.DaysInMonth(years, months);
            var days = GetRandomDays(dayRange, randomGenerator, daysInMonth);

            var hours = GetRandomHours(hourRange, randomGenerator);
            var minutes = GetRandomMinutes(minuteRange, randomGenerator);
            var seconds = GetRandomSeconds(secondRange, randomGenerator);
            var milliseconds = GetRandomMilliseconds(millisecondRange, randomGenerator);

            return new DateTime(years, months, days, hours,
                minutes, seconds, milliseconds, calendar, kind);
        }

        private static int GetRandomMilliseconds(IRange<int> millisecondRange, Random randomGenerator)
        {
            millisecondRange = millisecondRange ?? Range.From(0, 1000);
            millisecondRange.Start.Require(x => x.IsGreaterThan(-1));
            millisecondRange.Start.Require(x => x.IsLessThan(1000));
            return millisecondRange.Random(randomGenerator);
        }

        private static int GetRandomSeconds(IRange<int> secondRange, Random randomGenerator)
        {
            secondRange = secondRange ?? Range.From(0, 60);
            secondRange.Start.Require(x => x.IsGreaterThan(-1));
            secondRange.Start.Require(x => x.IsLessThan(60));
            return secondRange.Random(randomGenerator);
        }

        private static int GetRandomMinutes(IRange<int> minuteRange, Random randomGenerator)
        {
            minuteRange = minuteRange ?? Range.From(0, 60);
            minuteRange.Start.Require(x => x.IsGreaterThan(-1));
            minuteRange.Start.Require(x => x.IsLessThan(60));
            return minuteRange.Random(randomGenerator);
        }

        private static int GetRandomHours(IRange<int> hourRange, Random randomGenerator)
        {
            hourRange = hourRange ?? Range.From(1, 24);
            hourRange.Start.Require(x => x.IsGreaterThan(0));
            hourRange.Start.Require(x => x.IsLessThan(24));
            return hourRange.Random(randomGenerator);
        }

        private static int GetRandomDays(IRange<int> dayRange, Random randomGenerator, int daysInMonth)
        {
            dayRange = dayRange ?? Range.From(1, daysInMonth);
            dayRange.Start.Require(x => x.IsGreaterThan(0));
            dayRange.Start.Require(x => x.IsLessThan(daysInMonth));
            return dayRange.Random(randomGenerator);
        }

        private static int GetRandomMonths(IRange<int> monthRange, Random randomGenerator)
        {
            monthRange = monthRange ?? Range.From(1, 12);
            monthRange.Start.Require(x => x.IsGreaterThan(0));
            monthRange.Start.Require(x => x.IsLessThan(13));
            return monthRange.Random(randomGenerator);
        }

        private static int GetRandomYears(IRange<int> yearRange, Random randomGenerator, DateTime min, DateTime max)
        {
            yearRange = yearRange ?? Range.From(min.Year, max.Year);
            yearRange.Start.Require(x => x.IsAtLeast(min.Year));
            return yearRange.Random(randomGenerator);
        }
    }
}
