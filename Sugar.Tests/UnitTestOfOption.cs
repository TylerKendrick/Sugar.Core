using System;
using Moq;
using NUnit.Framework;

namespace Sugar.Tests
{
    public interface INode
    {
        INode Previous { get; }
        int Value { get; }
        int? Nullable { get; }
        INode Next { get; }
    }
    [TestFixture]
    public class UnitTestOfOption : UnitTestOf<INode>
    {
        private Mock<INode> _mockContext;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        protected override void SetUpDependencies()
        {
            _mockContext = Register<INode>();
        }

        protected override INode SetUpConcern()
        {
            return _mockContext.Object;
        }

        [Test]
        public void MaybeClassAccessesNext()
        {
            var mockNext = Register<INode>();
            _mockContext.Setup(x => x.Next)
                .Returns(mockNext.Object);

            var result = Concern.Maybe(x => x.Next);

            Assert.That(result.HasValue, Is.True);
            Assert.That(result, Is.InstanceOf<Something>());
            INode tryResult;
            Assert.That(result.TryGetValue(out tryResult), Is.True);
            Assert.That(tryResult, Is.EqualTo(mockNext.Object));
        }

        [Test]
        public void MaybeClassAccessesNextThenPreviousReturnsNext()
        {
            var mockNext = Register<INode>();
            _mockContext.Setup(x => x.Next)
                .Returns(mockNext.Object);
            mockNext.Setup(x => x.Previous)
                .Returns(_mockContext.Object);

            var result = Concern.Maybe(x => x.Next.Previous.Next);

            Assert.That(result.HasValue, Is.True);
            Assert.That(result, Is.InstanceOf<Something>());
            INode tryResult;
            Assert.That(result.TryGetValue(out tryResult), Is.True);
            Assert.That(tryResult, Is.EqualTo(mockNext.Object));
        }

        [Test]
        public void MaybeClassAccessesPreviousReturnsNull()
        {
            var mockNext = Register<INode>();
            _mockContext.Setup(x => x.Next)
                .Returns(mockNext.Object);

            var result = Concern.Maybe(x => x.Next.Previous.Next);

            Assert.That(result.HasValue, Is.False);
            Assert.That(result, Is.InstanceOf<Nothing>());
        }

        [Test]
        public void MaybeStructAccessesNext()
        {
            const int expectation = 3;
            var mockNext = Register<INode>();
            _mockContext.Setup(x => x.Next)
                .Returns(mockNext.Object);
            mockNext.Setup(x => x.Value)
                .Returns(expectation);

            var result = Concern.Maybe(x => x.Next.Value);

            Assert.That(result.HasValue, Is.True);
            Assert.That(result, Is.InstanceOf<Something>());
            int tryResult;
            Assert.That(result.TryGetValue(out tryResult), Is.True);
            Assert.That(tryResult, Is.EqualTo(expectation));
        }

        [Test]
        public void MaybeStructAccessesNextThenPreviousReturnsNext()
        {
            const int expectation = 5;
            var mockNext = Register<INode>();
            _mockContext.Setup(x => x.Next)
                .Returns(mockNext.Object);
            mockNext.Setup(x => x.Previous)
                .Returns(_mockContext.Object);
            mockNext.Setup(x => x.Value)
                .Returns(expectation);

            var result = Concern.Maybe(x => x.Next.Previous.Next.Value);

            Assert.That(result.HasValue, Is.True);
            Assert.That(result, Is.InstanceOf<Something>());
            int tryResult;
            Assert.That(result.TryGetValue(out tryResult), Is.True);
            Assert.That(tryResult, Is.EqualTo(expectation));
        }

        [Test]
        public void MaybeStructAccessesPreviousReturnsNull()
        {
            var mockNext = Register<INode>();
            _mockContext.Setup(x => x.Next)
                .Returns(mockNext.Object);

            var result = Concern.Maybe(x => x.Next.Previous.Next.Value);

            Assert.That(result.HasValue, Is.False);
            Assert.That(result, Is.InstanceOf<Nothing>());
        }

        [Test]
        public void MaybeNullableStructAccessesNextWhenNotNull()
        {
            const int expectation = 3;
            var mockNext = Register<INode>();
            _mockContext.Setup(x => x.Next)
                .Returns(mockNext.Object);
            mockNext.Setup(x => x.Nullable)
                .Returns(expectation);

            var result = Concern.Maybe(x => x.Next.Nullable);

            Assert.That(result.HasValue, Is.True);
            Assert.That(result, Is.InstanceOf<Something>());
            int? tryResult;
            Assert.That(result.TryGetValue(out tryResult), Is.True);
            Assert.That(tryResult, Is.EqualTo(expectation));
        }

        [Test]
        public void MaybeNullableStructAccessesNextThenPreviousReturnsNextWhenNotNull()
        {
            const int expectation = 5;
            var mockNext = Register<INode>();
            _mockContext.Setup(x => x.Next)
                .Returns(mockNext.Object);
            mockNext.Setup(x => x.Previous)
                .Returns(_mockContext.Object);
            mockNext.Setup(x => x.Nullable)
                .Returns(expectation);

            var result = Concern.Maybe(x => x.Next.Previous.Next.Nullable);

            Assert.That(result.HasValue, Is.True);
            Assert.That(result, Is.InstanceOf<Something>());
            int? tryResult;
            Assert.That(result.TryGetValue(out tryResult), Is.True);
            Assert.That(tryResult, Is.EqualTo(expectation));
        }

        [Test]
        public void MaybeNullableStructAccessesPreviousReturnsNullWhenNotNull()
        {
            var mockNext = Register<INode>();
            _mockContext.Setup(x => x.Next)
                .Returns(mockNext.Object);

            var result = Concern.Maybe(x => x.Next.Previous.Next.Nullable);

            Assert.That(result.HasValue, Is.False);
            Assert.That(result, Is.InstanceOf<Nothing>());
        }
    }
}