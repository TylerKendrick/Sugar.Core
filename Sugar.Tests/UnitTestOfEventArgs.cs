using System;
using NUnit.Framework;

namespace Sugar.Tests
{
    class UnitTestOfEventArgs : UnitTestOf<EventArgs<int>>
    {
        private const int Expectation = 4;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        protected override void SetUpDependencies()
        {
        }

        protected override EventArgs<int> SetUpConcern()
        {
            return EventArgs<int>.Create(Expectation);
        }

        [Test]
        public void WiringTest()
        {
            var result = Concern.Value;

            Assert.That(Concern, Is.InstanceOf<EventArgs>());
            Assert.That(result, Is.EqualTo(Expectation));
        }
    }
}