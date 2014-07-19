namespace System
{
    using Collections.Generic;
    using Globalization;
    using Linq;

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
            return randomGenerator
                .Ensure(RandomGenerator)
                .From(self);
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
            
            yearRange = yearRange ?? Range.From(min.Year, max.Year);
            yearRange.Start.Require(x => x.IsAtLeast(min.Year));
            var years = yearRange.Random(randomGenerator);

            monthRange = monthRange ?? Range.From(1, 12);
            monthRange.Start.Require(x => x.IsGreaterThan(0));
            monthRange.Start.Require(x => x.IsLessThan(13));
            var months = monthRange.Random(randomGenerator);

            var daysInMonth = DateTime.DaysInMonth(years, months);
            dayRange = dayRange ?? Range.From(1, daysInMonth);
            dayRange.Start.Require(x => x.IsGreaterThan(0));
            dayRange.Start.Require(x => x.IsLessThan(daysInMonth));
            var days = dayRange.Random(randomGenerator);

            hourRange = hourRange ?? Range.From(1, 24);
            hourRange.Start.Require(x => x.IsGreaterThan(0));
            hourRange.Start.Require(x => x.IsLessThan(24));
            var hours = hourRange.Random(randomGenerator);

            minuteRange = minuteRange ?? Range.From(0, 60);
            minuteRange.Start.Require(x => x.IsGreaterThan(-1));
            minuteRange.Start.Require(x => x.IsLessThan(60));
            var minutes = minuteRange.Random(randomGenerator);

            secondRange = secondRange ?? Range.From(0, 60);
            secondRange.Start.Require(x => x.IsGreaterThan(-1));
            secondRange.Start.Require(x => x.IsLessThan(60));
            var seconds = secondRange.Random(randomGenerator);

            millisecondRange = millisecondRange ?? Range.From(0, 1000);
            millisecondRange.Start.Require(x => x.IsGreaterThan(-1));
            millisecondRange.Start.Require(x => x.IsLessThan(1000));
            var milliseconds = millisecondRange.Random(randomGenerator);

            return new DateTime(years, months, days, hours, 
                minutes, seconds, milliseconds, calendar, kind);
        }
    }
}
