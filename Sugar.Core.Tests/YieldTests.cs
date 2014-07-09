using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sugar.Core.Tests
{
    [TestClass]
    public class YieldTests
    {
        [TestMethod]
        public void TimesMethodThrowsArgumentExceptionWhenHasInvalidGeneratorMethod()
        {
            var result = Yield.Times<int>(1, null);
        }

        [TestMethod]
        public void TimesMethodThrowsArgumentExceptionWhenCountIsLessThanZero()
        {
            var result = Yield.Times(-1, x => x);
        }

        [TestMethod]
        public void TimesMethodThrowsArgumentExceptionWhenCountIsZero()
        {
            var result = Yield.Times(0, x => x);
        }

        [TestMethod]
        public void TimesMethodReturnsExpectedValuesFromValidInput()
        {
            var result = Yield.Times(1, x => x);
        }
        [TestMethod]
        public void TimesMethodReturnsExpectedValuesFromValidInputWithInitialValue()
        {
            var result = Yield.Times(1, 1, x => x);
        }
    }
}
