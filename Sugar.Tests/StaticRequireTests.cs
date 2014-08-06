using System;
using NUnit.Framework;

namespace Sugar.Tests
{
    [TestFixture, Category("Unit Test")]
    public class StaticRequireTests
    {
        private readonly object _concern = new object();

        [Test]
        public void ThatMethodThrowsExceptionWithFalseCondition()
        {
            Assert.That(() => Require.That(false),
                Throws.InvalidOperationException);
        }


        [Test]
        public void ThatMethodDoesNotThrowExceptionWithTrueCondition()
        {
            Assert.That(() => Require.That(true),
                Throws.Nothing);
        }


        [Test]
        public void ThatMethodThrowsExceptionWithFalsePredicate()
        {
            Assert.That(() => Require.That(_concern, o => false),
                Throws.InvalidOperationException);
        }


        [Test]
        public void ThatMethodDoesNotThrowExceptionWithTruePredicate()
        {
            Assert.That(() => Require.That(_concern, o => true),
                Throws.Nothing);
        }
    }
}