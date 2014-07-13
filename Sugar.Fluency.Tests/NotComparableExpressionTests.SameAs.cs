using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    public partial class NotComparableExpressionTests
    {
        [TestMethod]
        public void SameAsMethodFulfillsExpectationsWhenComparableIsSameAsConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(0);

            var result = Concern.SameAs(mockComparable.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }
        [TestMethod]
        public void SameAsMethodFulfillsExpectationsWhenComparableIsGreaterThanConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(-1);

            var result = Concern.SameAs(mockComparable.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }
        [TestMethod]
        public void SameAsMethodFulfillsExpectationsWhenComparableIsLessThanConcern()
        {
            var mockComparable = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockComparable.Object)).Returns(1);

            var result = Concern.SameAs(mockComparable.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _fakeConcern.Verify(x => x.CompareTo(mockComparable.Object), Times.Once);
        }
        [TestMethod]
        public void SameAsMethodFulfillsExpectationsWhenComparableIsSameAsConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object)).Returns(0);

            var result = Concern.SameAs(mockComparable.Object, _mockComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }
        [TestMethod]
        public void SameAsMethodFulfillsExpectationsWhenComparableIsGreaterThanConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object)).Returns(-1);

            var result = Concern.SameAs(mockComparable.Object, _mockComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }
        [TestMethod]
        public void SameAsMethodFulfillsExpectationsWhenComparableIsLessThanConcernWithCustomComparer()
        {
            var mockComparable = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockComparable.Object)).Returns(1);

            var result = Concern.SameAs(mockComparable.Object, _mockComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockComparable.Object), Times.Once);
        }
    }
}