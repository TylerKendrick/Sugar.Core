using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sugar.Fluency.Tests
{
    public partial class NotComparableExpressionTests
    {
        [TestMethod]
        public void DefaultPropertyFulfillsExpectationsWhenConcernIsDefault()
        {
            Concern = new NotFluentExpression<IFakeConcern>(null);
            var result = Concern.Null();

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DefaultPropertyFulfillsExpectationsWhenConcernIsNotDefault()
        {
            var result = Concern.Null();

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }
    }
}