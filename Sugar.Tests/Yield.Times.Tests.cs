using System;
using System.Linq;
using NUnit.Framework;

namespace Sugar.Tests
{
    [TestFixture]
    public class YieldTests
    {
        [Test]
        public void TimesMethodThrowsArgumentExceptionWhenHasInvalidGeneratorMethod()
        {
            var result = Yield.Times(1, (Func<int, int>)null);

            Assert.Throws<ArgumentNullException>(() => result.ToArray());
        }

        [Test]
        public void TimesMethodThrowsArgumentExceptionWhenCountIsLessThanZero()
        {
            var result = Yield.Times<int>(-1, (i, x) => i);

            Assert.Throws<InvalidOperationException>(() => result.ToArray());
        }

        [Test]
        public void TimesMethodThrowsArgumentExceptionWhenCountIsZero()
        {
            var result = Yield.Times<int>(0, (i, x) => x);

            Assert.Throws<InvalidOperationException>(() => result.ToArray());
        }

        [Test]
        public void TimesMethodReturnsExpectedValuesFromValidInput()
        {
            var result = Yield.Times(1, x => x);

            Assert.That(result, Is.EqualTo(new []{0}));
        }

        [Test]
        public void TimesMethodReturnsExpectedValuesFromValidInputWithInitialValue()
        {
            var result = Yield.Times(3, 1, (i, x) => x);

            Assert.That(result, Is.EqualTo(new[] { 1, 1, 1 }));
        }


        [Test]
        public void TimesMethodReturnsExpectedIteratorValuesFromValidInputWithInitialValue()
        {
            var result = Yield.Times(3, 1, (i, x) => i);

            Assert.That(result, Is.EqualTo(new[] { 0, 1, 2 }));
        }
    }
}