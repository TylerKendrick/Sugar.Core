using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    public partial class NotComparableExpressionTests
    {
        [TestMethod]
        public void EqualToMethodFulfillsExpectationsWhenComparableIsEqualToConcern()
        {
            var result = Concern.EqualTo(_fakeConcern.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualToMethodFulfillsExpectationsWhenComparableIsNotEqualToConcern()
        {
            var mockComparable = Register<IFakeConcern>();

            var result = Concern.EqualTo(mockComparable.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualToMethodFulfillsExpectationsWhenComparableIsEqualToConcernWithCustomComparer()
        {
            var mockEqualityComparer = Register<IEqualityComparer<IFakeConcern>>();
            var mockComparable = Register<IFakeConcern>();

            mockEqualityComparer
                .Setup(x => x.Equals(_fakeConcern.Object, mockComparable.Object))
                .Returns(true);

            var result = Concern.EqualTo(mockComparable.Object, mockEqualityComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);

            mockEqualityComparer.Verify(x => x.Equals(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }
        
        [TestMethod]
        public void EqualToMethodFulfillsExpectationsWhenComparableIsNotEqualToConcernWithCustomComparer()
        {
            var mockEqualityComparer = Register<IEqualityComparer<IFakeConcern>>();
            var mockComparable = Register<IFakeConcern>();

            mockEqualityComparer
                .Setup(x => x.Equals(_fakeConcern.Object, mockComparable.Object))
                .Returns(false);

            var result = Concern.EqualTo(mockComparable.Object, mockEqualityComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            mockEqualityComparer.Verify(x => x.Equals(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }
    }
}