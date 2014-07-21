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

        [Test]
        public void UnaryApplyExtensionInvokesUnmodifiedBehavior()
        {
            var input = 0;
            Operators.Unary<int, int> unaryOperator = x =>
            {
                input = x;
                return x + 1;
            };
            
            var output = unaryOperator(input);
            Assert.That(input, Is.EqualTo(0));
            Assert.That(output, Is.EqualTo(1));

            input = 1;
            var applier = unaryOperator.Apply(input);
            output = applier();
            Assert.That(input, Is.EqualTo(1));
            Assert.That(output, Is.EqualTo(2));
        }

        [Test]
        public void BinaryApplyExtensionInvokesUnmodifiedBehavior()
        {
            var leftInput = 0;
            var rightInput = 0;
            Operators.Binary<int, int, int> binaryOperator = (left, right) =>
            {
                leftInput = left;
                rightInput = right;
                return left + right;
            };

            var output = binaryOperator(1, 2);
            Assert.That(leftInput, Is.EqualTo(1));
            Assert.That(rightInput, Is.EqualTo(2));
            Assert.That(output, Is.EqualTo(leftInput + rightInput));

            var applier = binaryOperator.Apply(3, 4);
            output = applier();
            Assert.That(leftInput, Is.EqualTo(3));
            Assert.That(rightInput, Is.EqualTo(4));
            Assert.That(output, Is.EqualTo(leftInput + rightInput));
        }

        [Test]
        public void BinaryApplyLeftExtensionInvokesUnmodifiedBehavior()
        {
            var leftInput = 0;
            var rightInput = 0;
            Operators.Binary<int, int, int> binaryOperator = (left, right) =>
            {
                leftInput = left;
                rightInput = right;
                return left + right;
            };

            var output = binaryOperator(1, 2);
            Assert.That(leftInput, Is.EqualTo(1));
            Assert.That(rightInput, Is.EqualTo(2));
            Assert.That(output, Is.EqualTo(leftInput + rightInput));

            var applier = binaryOperator.ApplyLeft(3);
            output = applier(4);
            Assert.That(leftInput, Is.EqualTo(3));
            Assert.That(rightInput, Is.EqualTo(4));
            Assert.That(output, Is.EqualTo(leftInput + rightInput));
        }

        [Test]
        public void BinaryApplyRightExtensionInvokesUnmodifiedBehavior()
        {
            var leftInput = 0;
            var rightInput = 0;
            Operators.Binary<int, int, int> binaryOperator = (left, right) =>
            {
                leftInput = left;
                rightInput = right;
                return left + right;
            };

            var output = binaryOperator(1, 2);
            Assert.That(leftInput, Is.EqualTo(1));
            Assert.That(rightInput, Is.EqualTo(2));
            Assert.That(output, Is.EqualTo(leftInput + rightInput));

            var applier = binaryOperator.ApplyRight(4);
            output = applier(3);
            Assert.That(leftInput, Is.EqualTo(3));
            Assert.That(rightInput, Is.EqualTo(4));
            Assert.That(output, Is.EqualTo(leftInput + rightInput));
        }

        [Test]
        public void BinaryCurryExtensionsReturnExpectedCurriedResults()
        {
            var invocationCount = 0;
            Operators.Binary<int, int, int> binaryOperator = (left, right) => invocationCount++;

            var curried = binaryOperator.Curry();
            Assert.That(curried, Is.InstanceOf<Func<int, Func<int, int>>>().And.Not.Null);
            Assert.That(invocationCount, Is.EqualTo(0));
            
            var x = curried(3);
            Assert.That(x, Is.InstanceOf<Func<int, int>>().And.Not.Null);
            Assert.That(invocationCount, Is.EqualTo(0));

            var y = x(4);
            Assert.That(y, Is.EqualTo(0));
            Assert.That(invocationCount, Is.EqualTo(1));
        }
    }
}
