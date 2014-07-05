using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public class ItTests : UnitTestOf<It<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
        }

        protected override It<IFakeConcern> SetUpConcern()
        {
            return new It<IFakeConcern>(_fakeConcern.Object);
        }

        [TestMethod, TestCategory("Wiring Test")]
        public void FluentMethodsReturnNonNullResults()
        {
            var result = Concern.Is;
            Assert.IsInstanceOfType(result, typeof(IsComparableExpression<IFakeConcern>));
            Assert.IsNotNull(result);
        }
    }
}