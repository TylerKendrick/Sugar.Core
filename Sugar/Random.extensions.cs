using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Sugar.Utilities;

namespace Sugar
{
    /// <summary>
    /// Provides random values from numeric types, collections, and datetime objects.
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
            collection.Require();

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
        public static T From<T>(this Random self, params T[] collection)
        {
            return collection.Random(self);
        }

        /// <summary>
        /// Returns a random item from a collection
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="self">The target collection.</param>
        /// <param name="randomGenerator">The optional generator for random number selection.</param>
        /// <returns>The item selected from the randomly generated index.</returns>
        public static T Random<T>(this IEnumerable<T> self, Random randomGenerator = null)
        {
            randomGenerator = randomGenerator ?? RandomGenerator;
            return randomGenerator.From(self);
        }

        /// <summary>
        /// Returns a random item from a range.
        /// </summary>
        /// <param name="self">The target collection.</param>
        /// <param name="randomGenerator">The optional generator for random number selection.</param>
        /// <returns>The item selected from the randomly generated index.</returns>
        public static int Random(this IRange<int> self, Random randomGenerator = null)
        {
            self.Require();
            randomGenerator = randomGenerator ?? RandomGenerator;
            return randomGenerator.Next(self.Start, self.End);
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
            return new Range<T>(min, max).Random(factoryMethod, randomGenerator);
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
        /// <param name="calendar">Defaults to the gregorian calendar.</param>
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
            var result = new DateTime();
            
            yearRange = yearRange ?? Range.From(min.Year, max.Year);
            yearRange.Start.Require(Is.AtLeast(min.Year));
            result = result.AddYears(yearRange.Random(randomGenerator));

            monthRange = monthRange ?? Range.From(1, 12);
            monthRange.Start.Require(Is.GreaterThan(0));
            monthRange.Start.Require(Is.LessThan(13));
            result = result.AddMonths(monthRange.Random(randomGenerator));

            var daysInMonth = DateTime.DaysInMonth(result.Year, result.Month);
            dayRange = dayRange ?? Range.From(1, daysInMonth);
            dayRange.Start.Require(Is.GreaterThan(0));
            dayRange.Start.Require(Is.LessThan(daysInMonth));
            result = result.AddDays(dayRange.Random(randomGenerator));

            hourRange = hourRange ?? Range.From(1, 24);
            hourRange.Start.Require(Is.GreaterThan(0));
            hourRange.Start.Require(Is.LessThan(24));
            result = result.AddHours(hourRange.Random(randomGenerator));

            minuteRange = minuteRange ?? Range.From(0, 60);
            minuteRange.Start.Require(Is.GreaterThan(-1));
            minuteRange.Start.Require(Is.LessThan(60));
            result = result.AddMinutes(minuteRange.Random(randomGenerator));

            secondRange = secondRange ?? Range.From(0, 60);
            secondRange.Start.Require(Is.GreaterThan(-1));
            secondRange.Start.Require(Is.LessThan(60));
            result = result.AddSeconds(secondRange.Random(randomGenerator));

            millisecondRange = millisecondRange ?? Range.From(0, 1000);
            millisecondRange.Start.Require(Is.GreaterThan(-1));
            millisecondRange.Start.Require(Is.LessThan(1000));
            result = result.AddMilliseconds(millisecondRange.Random(randomGenerator));

            return result;
        }
    }
}
