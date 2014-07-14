using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public class FluentStaticTests
    {
        private IFakeConcern _fakeConcern;
        [TestInitialize]
        public void Setup()
        {
            _fakeConcern = new Mock<IFakeConcern>().Object;
        }

        [TestMethod]
        public void ItExpressionWithoutComparableExpressionReturnsExpectedResult()
        {
            var result = Fluent.It(_fakeConcern);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(It<IFakeConcern>));
        }

        [TestMethod]
        public void ItExpressionWithComparableExpressionReturnsExpectedResult()
        {
            var expectation = new FluentPredicate<IFakeConcern>(_fakeConcern, true);
            var result = Fluent.It(_fakeConcern, x => expectation);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.AreEqual(expectation, result);
            Assert.IsTrue(result);
        }
    }
}