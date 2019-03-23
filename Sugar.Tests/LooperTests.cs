using System;
using NUnit.Framework;

namespace Sugar.Tests
{
    [TestFixture]
    public class LooperTests
    {
        private int _count;
        private Looper _looper;
        private Action _action;

        [SetUp]
        public void Setup()
        {
            _count = 0;
            _action = () => _count++;
            _looper = _action.Loop();
        }

        [Test]
        public void LoopExtensionMethodReturnsNewInstanceOfLooper()
        {
            Action action = delegate{};
            var looper1 = action.Loop();
            var looper2 = action.Loop();

            Assert.That(looper1, Is.InstanceOf<Looper>());
            Assert.That(looper2, Is.InstanceOf<Looper>());
            Assert.That(looper1, Is.Not.SameAs(looper2));
        }

        [Test]
        public void RaiseWithValidAction()
        {
            _looper.Raise();

            Assert.That(_count, Is.EqualTo(1));
        }

        [Test]
        public void RaiseWithInvalidAction()
        {
            _action = null;
            Assert.That(() => _action.Loop(), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void TimesWithValidIncrementalAction()
        {
            _looper.Times(20);
            Assert.That(_count, Is.EqualTo(20));
        }

        [Test]
        public void TimesWithInvalidIncrementalAction()
        {
            Assert.That(() => _looper.Times(-20), Throws.InvalidOperationException);
        }

        [Test]
        public void WhileConditionIsTrue()
        {
            _looper.While(() => _count < 5);

            Assert.That(_count, Is.EqualTo(5));
        }

        [Test]
        public void UntilConditionIsTrue()
        {
            _looper.Until(() => _count == 5);

            Assert.That(_count, Is.EqualTo(5));
        }
    }
}