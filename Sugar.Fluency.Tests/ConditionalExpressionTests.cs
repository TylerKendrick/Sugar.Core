using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace System.Fluency.Tests
{
    [TestClass]
    public class ConditionalExpressionTests : UnitTestOf<FluentPredicate<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;
        private readonly bool? _offset = null; 

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
        }

        protected override FluentPredicate<IFakeConcern> SetUpConcern()
        {
            return new FluentPredicate<IFakeConcern>(_fakeConcern.Object, _offset);
        }

        [TestMethod, TestCategory("Wiring Test")]
        public void AndExpressionReturnsNewInstanceFromConcern()
        {
            var result = Concern.And;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AndFluentExpression<IFakeConcern>));
        }

        [TestMethod, TestCategory("Wiring Test")]
        public void OrExpressionReturnsNewInstanceFromConcern()
        {
            var result = Concern.Or;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OrFluentExpression<IFakeConcern>));
        }

        [TestMethod, TestCategory("Wiring Test")]
        public void NotExpressionReturnsNewInstanceFromConcern()
        {
            var result = Concern.Not;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFluentExpression<IFakeConcern>));
        }
    }
}