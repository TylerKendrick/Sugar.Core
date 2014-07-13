﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sugar.Fluency.Tests
{
    public partial class AndComparableExpressionTests
    {
        [TestMethod]
        public void DefaultPropertyFulfillsExpectationsWhenConcernIsDefault()
        {
            Concern = new AndFluentExpression<IFakeConcern>(null);
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