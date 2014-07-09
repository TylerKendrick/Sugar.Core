using System;
using NUnit.Framework;

namespace Sugar.Core.Tests
{
    [TestFixture]
    public class LooperTests
    {
        [Test]
        public void RaiseWithAction()
        {
            var i = 0;
            Action action = () => i++;
            var looper = new Looper(action);

            looper.Raise();
            Assert.That(i, NUnit.Framework.Is.EqualTo(1));
        }
        [Test]
        public void TimesWithIncrementalAction()
        {
            var i = 0;
            Action increment = () => i++;
            var looper = new Looper(increment);

            looper.Times(20);
            Assert.That(i, NUnit.Framework.Is.EqualTo(20));
        }
    }
}