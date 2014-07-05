using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public class ConditionalExpressionTests : UnitTestOf<ConditionalExpression<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;
        private readonly bool? _offset = null; 

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
        }

        protected override ConditionalExpression<IFakeConcern> SetUpConcern()
        {
            return new ConditionalExpression<IFakeConcern>(_fakeConcern.Object, _offset);
        }

        [TestMethod, TestCategory("Wiring Test")]
        public void AndExpressionReturnsNewInstanceFromConcern()
        {
            var result = Concern.And;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AndComparableExpression<IFakeConcern>));
        }

        [TestMethod, TestCategory("Wiring Test")]
        public void OrExpressionReturnsNewInstanceFromConcern()
        {
            var result = Concern.Or;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OrComparableExpression<IFakeConcern>));
        }

        [TestMethod, TestCategory("Wiring Test")]
        public void NotExpressionReturnsNewInstanceFromConcern()
        {
            var result = Concern.Not;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotComparableExpression<IFakeConcern>));
        }
    }
}