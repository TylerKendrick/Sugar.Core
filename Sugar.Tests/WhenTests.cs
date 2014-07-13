using System;
using Moq;
using NUnit.Framework;
namespace Sugar.Tests
{
    [TestFixture]
    public class WhenTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConcernReturnsExpectedInstanceWhenTrue()
        {
            Action action = new Mock<IFakeConcern>().Object.Action;
            var result = action.When(() => true);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<When>());
        }

        [Test]
        public void ConcernReturnsExpectedInstanceWhenFalse()
        {
            Action action = new Mock<IFakeConcern>().Object.Action;
            var result = action.When(() => false);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<When>());
        }

        [Test]
        public void ConcernReturnsExpectedInstanceWhenFalseAndOtherwiseTrue()
        {
            var mockOther = new Mock<IFakeConcern>();
            Action action = new Mock<IFakeConcern>().Object.Action;
            Action otherAction = mockOther.Object.Action;

            var result = action.When(() => false)
                .Otherwise(otherAction);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Otherwise>());
        }

        [Test]
        public void InvocationOfConcernRaisesExpectedBehaviorsWhenTrue()
        {
            const int expectedInvocations = 1;
            var actualIncovations = 0;
            var mockConcern = new Mock<IFakeConcern>();
            mockConcern.Setup(x => x.Action())
                .Callback(() => actualIncovations++);

            Action action = mockConcern.Object.Action;
            Action result = action.When(() => true);

            result();

            Assert.That(actualIncovations, Is.EqualTo(expectedInvocations));
        }

        [Test]
        public void InvocationOfConcernRaisesExpectedBehaviorsWhenFalse()
        {
            const int expectedInvocations = 0;
            var actualIncovations = 0;
            var mockConcern = new Mock<IFakeConcern>();
            mockConcern.Setup(x => x.Action())
                .Callback(() => actualIncovations++);

            Action action = mockConcern.Object.Action;
            Action result = action.When(() => false);

            result();

            Assert.That(actualIncovations, Is.EqualTo(expectedInvocations));
        }
    }
}
