using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    public partial class AndComparableExpressionTests
    {
        [TestMethod]
        public void BetweenMethodFulfillsExpectationsWhenMinimumIsGreaterThanConcernAndMaximumIsGreaterThanConcern()
        {
            var mockMinimum = Register<IFakeConcern>();
            var mockMaximum = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockMinimum.Object)).Returns(1);
            _fakeConcern.Setup(x => x.CompareTo(mockMaximum.Object)).Returns(1);

            var result = Concern.Between(mockMinimum.Object, mockMaximum.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);

            _fakeConcern.Verify(x => x.CompareTo(mockMinimum.Object), Times.Once);
            _fakeConcern.Verify(x => x.CompareTo(mockMaximum.Object), Times.Once);
        }

        [TestMethod]
        public void BetweenMethodFulfillsExpectationsWhenMinimumIsLessThanConcernAndMaximumIsGreaterThanConcern()
        {
            var mockMinimum = Register<IFakeConcern>();
            var mockMaximum = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockMinimum.Object)).Returns(-1);
            _fakeConcern.Setup(x => x.CompareTo(mockMaximum.Object)).Returns(1);

            var result = Concern.Between(mockMinimum.Object, mockMaximum.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _fakeConcern.Verify(x => x.CompareTo(mockMinimum.Object), Times.Once);
            _fakeConcern.Verify(x => x.CompareTo(mockMaximum.Object), Times.Once);
        }

        [TestMethod]
        public void BetweenMethodFulfillsExpectationsWhenMinimumIsGreaterThanConcernAndMaximumIsLessThanConcern()
        {
            var mockMinimum = Register<IFakeConcern>();
            var mockMaximum = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockMinimum.Object)).Returns(1);
            _fakeConcern.Setup(x => x.CompareTo(mockMaximum.Object)).Returns(-1);

            var result = Concern.Between(mockMinimum.Object, mockMaximum.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _fakeConcern.Verify(x => x.CompareTo(mockMinimum.Object), Times.Once);
            _fakeConcern.Verify(x => x.CompareTo(mockMaximum.Object), Times.Once);
        }

        [TestMethod]
        public void BetweenMethodFulfillsExpectationsWhenMinimumIsLessThanConcernAndMaximumIsLessThanConcern()
        {
            var mockMinimum = Register<IFakeConcern>();
            var mockMaximum = Register<IFakeConcern>();
            _fakeConcern.Setup(x => x.CompareTo(mockMinimum.Object)).Returns(-1);
            _fakeConcern.Setup(x => x.CompareTo(mockMaximum.Object)).Returns(-1);

            var result = Concern.Between(mockMinimum.Object, mockMaximum.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);

            _fakeConcern.Verify(x => x.CompareTo(mockMinimum.Object), Times.Once);
            _fakeConcern.Verify(x => x.CompareTo(mockMaximum.Object), Times.Once);
        }
        [TestMethod]
        public void BetweenMethodFulfillsExpectationsWhenMinimumIsGreaterThanConcernAndMaximumIsGreaterThanConcernWithCustomComparer()
        {
            var mockMinimum = Register<IFakeConcern>();
            var mockMaximum = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockMinimum.Object)).Returns(1);
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockMaximum.Object)).Returns(1);

            var result = Concern.Between(mockMinimum.Object, mockMaximum.Object, _mockComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockMinimum.Object), Times.Once);
            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockMaximum.Object), Times.Once);
        }

        [TestMethod]
        public void BetweenMethodFulfillsExpectationsWhenMinimumIsLessThanConcernAndMaximumIsGreaterThanConcernWithCustomComparer()
        {
            var mockMinimum = Register<IFakeConcern>();
            var mockMaximum = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockMinimum.Object)).Returns(-1);
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockMaximum.Object)).Returns(1);

            var result = Concern.Between(mockMinimum.Object, mockMaximum.Object, _mockComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockMinimum.Object), Times.Once);
            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockMaximum.Object), Times.Once);
        }

        [TestMethod]
        public void BetweenMethodFulfillsExpectationsWhenMinimumIsGreaterThanConcernAndMaximumIsLessThanConcernWithCustomComparer()
        {
            var mockMinimum = Register<IFakeConcern>();
            var mockMaximum = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockMinimum.Object)).Returns(1);
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockMaximum.Object)).Returns(-1);

            var result = Concern.Between(mockMinimum.Object, mockMaximum.Object, _mockComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockMinimum.Object), Times.Once);
            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockMaximum.Object), Times.Once);
        }

        [TestMethod]
        public void BetweenMethodFulfillsExpectationsWhenMinimumIsLessThanConcernAndMaximumIsLessThanConcernWithCustomComparer()
        {
            var mockMinimum = Register<IFakeConcern>();
            var mockMaximum = Register<IFakeConcern>();
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockMinimum.Object)).Returns(-1);
            _mockComparer.Setup(x => x.Compare(_fakeConcern.Object, mockMaximum.Object)).Returns(-1);

            var result = Concern.Between(mockMinimum.Object, mockMaximum.Object, _mockComparer.Object);

            Assert.IsInstanceOfType(result, typeof(FluentPredicate<IFakeConcern>));
            Assert.IsNotNull(result);
            Assert.IsFalse(result);

            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockMinimum.Object), Times.Once);
            _mockComparer.Verify(x => x.Compare(_fakeConcern.Object, mockMaximum.Object), Times.Once);
        }
    }
}