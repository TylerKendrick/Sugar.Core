using System;
using NUnit.Framework;

namespace Sugar.Tests
{
    [TestFixture, Category("Unit Test")]
    public class CustomComparerTests
    {
        [Test]
        public void ToComparisonExtensionReturnsSameResult()
        {
            Func<int, int, int> func = (x, y) => x + y;
            var comparison = func.ToComparison();

            AssertComparisonEquals(-3, 5, func, comparison);
            AssertComparisonEquals(3, -5, func, comparison);
            AssertComparisonEquals(-3, -5, func, comparison);
            AssertComparisonEquals(3, 5, func, comparison);
        }

        [Test]
        public void ToFuncExtensionReturnsSameResult()
        {
            Comparison<int> comparison = (x, y) => x + y;
            var func = comparison.ToFunc();

            AssertComparisonEquals(-3, 5, func, comparison);
            AssertComparisonEquals(3, -5, func, comparison);
            AssertComparisonEquals(-3, -5, func, comparison);
            AssertComparisonEquals(3, 5, func, comparison);
        }

        private static void AssertComparisonEquals(int x, int y, 
            Func<int, int, int> func, Comparison<int> comparison)
        {
            var funcResult = func(x, y);
            var comparisonResult = comparison(x, y);
            Assert.That(funcResult, Is.EqualTo(comparisonResult));
        }
    }
}