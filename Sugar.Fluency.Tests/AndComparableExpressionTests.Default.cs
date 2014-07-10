using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sugar.Fluency.Tests
{
    public partial class AndComparableExpressionTests
    {
        [TestMethod]
        public void DefaultPropertyFulfillsExpectationsWhenConcernIsDefault()
        {
            Concern = new AndComparableExpression<IFakeConcern>(null);
            var result = Concern.Default();

            Assert.IsInstanceOfType(result, typeof(ConditionalExpression<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DefaultPropertyFulfillsExpectationsWhenConcernIsNotDefault()
        {
            var result = Concern.Default();

            Assert.IsInstanceOfType(result, typeof(ConditionalExpression<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }
    }
}