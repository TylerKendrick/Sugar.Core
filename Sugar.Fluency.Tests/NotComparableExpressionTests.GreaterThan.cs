using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace System.Fluency.Tests
{
    public partial class NotComparableExpressionTests
    {
        [TestMethod]
        public void GreaterThanMethodFulfillsExpectationsWhenComparableIsLessThanConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(1);

            var result = Concern.GreaterThan(mockComparable.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }

        [TestMethod]
        public void GreaterThanMethodFulfillsExpectationsWhenComparableIsGreaterThanConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(-1);

            var result = Concern.GreaterThan(mockComparable.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }
        [TestMethod]
        public void GreaterThanMethodFulfillsExpectationsWhenComparableIsEqualToConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(0);

            var result = Concern.GreaterThan(mockComparable.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }

        [TestMethod]
        public void GreaterThanMethodFulfillsExpectationsWhenComparableIsLessThanConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object)).Returns(1);

            var result = Concern.GreaterThan(mockComparable.Object, _mockComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }

        [TestMethod]
        public void GreaterThanMethodFulfillsExpectationsWhenComparableIsGreaterThanConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object)).Returns(-1);

            var result = Concern.GreaterThan(mockComparable.Object, _mockComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }
        [TestMethod]
        public void GreaterThanMethodFulfillsExpectationsWhenComparableIsEqualToConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object)).Returns(0);

            var result = Concern.GreaterThan(mockComparable.Object, _mockComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }
    }
}