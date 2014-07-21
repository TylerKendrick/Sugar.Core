using System;
using NUnit.Framework;

namespace Sugar.Tests
{
    public partial class OperatorTests
    {
        [Test]
        public void NullaryToExpressionExtensionInvokesSameBehavior()
        {
            var count = 0;
            Operators.Nullary<int> nullaryInt = () => count++;
            var expression = nullaryInt.ToExpression();

            Assert.That(count, Is.EqualTo(0));

            nullaryInt();
            Assert.That(count, Is.EqualTo(1));

            var func = expression.Compile();
            func();
            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public void UnaryToExpressionExtensionInvokesSameBehavior()
        {
            var count = 0;
            Operators.Unary<int, int> nullaryInt = x => x + 1;
            var expression = nullaryInt.ToExpression();

            Assert.That(count, Is.EqualTo(0));

            count = nullaryInt(count);
            Assert.That(count, Is.EqualTo(1));

            var func = expression.Compile();
            count = func(count);
            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public void BinaryToExpressionExtensionInvokesSameBehavior()
        {
            var leftCount = 0;
            var rightCount = 0;
            Operators.Binary<int, int, int> nullaryInt = (left, right) =>
            {
                leftCount += left;
                rightCount -= right;
                return leftCount - rightCount;
            };

            var func = nullaryInt.ToFunc();

            var total = nullaryInt(1, 1);
            Assert.That(total, Is.EqualTo(2));
            Assert.That(leftCount, Is.EqualTo(1));
            Assert.That(rightCount, Is.EqualTo(-1));

            total = func(1, 1);
            Assert.That(total, Is.EqualTo(4));
            Assert.That(leftCount, Is.EqualTo(2));
            Assert.That(rightCount, Is.EqualTo(-2));
        }
    }
}
