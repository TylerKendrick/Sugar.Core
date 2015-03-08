using System;
using NUnit.Framework;

namespace Sugar.Tests
{
    class UnitTestOfRange : UnitTestOf<IRange<int>>
    {
        [Test]
        public void AsEnumerableExludesMaximum()
        {
            var expectation = new[] {2, 3};
            var enumerable = Concern.AsEnumerable(i => i+1);

            Assert.That(enumerable, Is.EqualTo(expectation));
        }

        [Test]
        public void StartMatchesExpectation()
        {
            Assert.That(Concern.Start, Is.EqualTo(2));
        }

        [Test]
        public void EndMatchesExpectation()
        {
            Assert.That(Concern.End, Is.EqualTo(4));
        }

        [Test]
        public void ContainsExpectation()
        {
            Assert.That(Concern.Contains(3), Is.True);
        }

        [Test]
        public void DoesNotContainExpectation()
        {
            Assert.That(Concern.Contains(Concern.End), Is.False);
        }

        protected override IRange<int> SetUpConcern()
        {
            return Range.From(2, 4);
        }
    }
}