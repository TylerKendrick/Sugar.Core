using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public class IsComparableExpressionTests : UnitTestOf<IsComparableExpression<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
        }

        protected override IsComparableExpression<IFakeConcern> SetUpConcern()
        {
            return new IsComparableExpression<IFakeConcern>(_fakeConcern.Object);
        }

        [TestMethod, TestCategory("Wiring Test")]
        public void NotPropertyFulfillsExpectations()
        {
            var result = Concern.Not;

            Assert.IsInstanceOfType(result, typeof(NotComparableExpression<IFakeConcern>));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void InMethodFulfillsExpectationsWhenCollectionDoesContainConcern()
        {
            var result = Concern.In(new[] { _fakeConcern.Object });

            Assert.IsInstanceOfType(result, typeof(ConditionalExpression<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void InMethodFulfillsExpectationsWhenCollectionDoesNotContainConcern()
        {
            var result = Concern.In(new IFakeConcern[0]);

            Assert.IsInstanceOfType(result, typeof(ConditionalExpression<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }
    }
}