using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    public partial class ComparableExpressionTests
    {
        [TestMethod]
        public void AtMostMethodFulfillsExpectationsWhenComparableIsLessThanConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(-1);

            var result = Concern.AtMost(mockComparable.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ConditionalExpression<IFakeConcern>));
            Assert.IsTrue(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }


        [TestMethod]
        public void AtMostMethodFulfillsExpectationsWhenComparableIsEqualToConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(0);

            var result = Concern.AtMost(mockComparable.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ConditionalExpression<IFakeConcern>));
            Assert.IsTrue(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }


        [TestMethod]
        public void AtMostMethodFulfillsExpectationsWhenComparableIsGreaterThanConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(1);

            var result = Concern.AtMost(mockComparable.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ConditionalExpression<IFakeConcern>));
            Assert.IsFalse(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }

        [TestMethod]
        public void AtMostMethodFulfillsExpectationsWhenComparableIsLessThanConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object))
                .Returns(-1);
            var result = Concern.AtMost(mockComparable.Object, _mockComparer.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ConditionalExpression<IFakeConcern>));
            Assert.IsTrue(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }


        [TestMethod]
        public void AtMostMethodFulfillsExpectationsWhenComparableIsEqualToConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object))
                .Returns(0);
            var result = Concern.AtMost(mockComparable.Object, _mockComparer.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ConditionalExpression<IFakeConcern>));
            Assert.IsTrue(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }


        [TestMethod]
        public void AtMostMethodFulfillsExpectationsWhenComparableIsGreaterThanConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object))
                .Returns(1);
            var result = Concern.AtMost(mockComparable.Object, _mockComparer.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ConditionalExpression<IFakeConcern>));
            Assert.IsFalse(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }
    }
}