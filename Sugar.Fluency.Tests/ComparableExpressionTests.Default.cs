using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Fluency.Tests
{
    public partial class ComparableExpressionTests
    {
        [TestMethod]
        public void DefaultPropertyFulfillsExpectationsWhenConcernIsDefault()
        {
            Concern = new FluentExpression<IFakeConcern>(null);
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