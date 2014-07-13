using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    public partial class NotComparableExpressionTests
    {
        [TestMethod]
        public void AtLeastMethodFulfillsExpectationsWhenComparableIsLessThanConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(-1);

            var result = Concern.AtLeast(mockComparable.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsTrue(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }

        [TestMethod]
        public void AtLeastMethodFulfillsExpectationsWhenComparableIsEqualToConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(0);

            var result = Concern.AtLeast(mockComparable.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsFalse(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }

        [TestMethod]
        public void AtLeastMethodFulfillsExpectationsWhenComparableIsGreaterThanConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(1);

            var result = Concern.AtLeast(mockComparable.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsFalse(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }

        [TestMethod]
        public void AtLeastMethodFulfillsExpectationsWhenComparableIsGreaterThanConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object))
                .Returns(1);

            var result = Concern.AtLeast(mockComparable.Object, _mockComparer.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsFalse(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }

        [TestMethod]
        public void AtLeastMethodFulfillsExpectationsWhenComparableIsLessThanConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object))
                .Returns(-1);

            var result = Concern.AtLeast(mockComparable.Object, _mockComparer.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsTrue(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }

        [TestMethod]
        public void AtLeastMethodFulfillsExpectationsWhenComparableIsEqualToConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object))
                .Returns(0);

            var result = Concern.AtLeast(mockComparable.Object, _mockComparer.Object);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsFalse(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }
    }
}