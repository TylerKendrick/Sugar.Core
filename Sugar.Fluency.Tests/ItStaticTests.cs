using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public class ItStaticTests
    {
        private IFakeConcern _fakeConcern;
        private IIt<IFakeConcern> _it;

        [TestInitialize]
        public void Setup()
        {
            _fakeConcern = new Mock<IFakeConcern>().Object;
            _it = Fluent.It(_fakeConcern);
        }

        [TestMethod]
        public void IsPropertyReturnsSameInstance()
        {
            var expectation = _it.Is;
            var actual = _it.Is;

            Assert.AreSame(expectation, actual);
        }
    }
}