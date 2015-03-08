using System;
using System.Linq;
using NUnit.Framework;

namespace Sugar.Tests
{
    [TestFixture]
    public class RandomTests
    {
        [Test]
        public void RandomFromCollection()
        {
            var random = new Random();
            var collection = Enumerable.Range(1, 10).ToArray();

            Action logic = () =>
            {
                var result = random.From(collection);

                Assert.That(result, Is.InRange(1, 10));
                CollectionAssert.Contains(collection, result);
            };

            logic.Loop().Times(1000);
        }

        [Test]
        public void RandomFromCollectionExtension()
        {
            var collection = Enumerable.Range(1, 10).ToArray();

            Action logic = () =>
            {
                var result = collection.Random();

                Assert.That(result, Is.InRange(1, 10));
                CollectionAssert.Contains(collection, result);
            };

            logic.Loop().Times(1000);
        }

        public void RandomFromIntRangeExtension()
        {
            var range = Range.From(1, 10);

            Action logic = () =>
            {
                var result = range.Random();
                Assert.That(result, Is.InRange(1, 10));
            };

            logic.Loop().Times(1000);
        }

        [Test]
        public void RandomFromRangeExtension()
        {
            var range = Range.From("1", "11111");

            Action logic = () =>
            {
                var result = range.Random(x => x + "1");
                Assert.That(result, Is.InRange("1", "11111"));
            };

            logic.Loop().Times(1000);
        }

        [Test]
        public void RandomFromDateTimeExtension()
        {
            var random = new Random();
            Action logic = () =>
            {
                var result = random.Random(hourRange: Range.From(1, 24));
                Assert.That(result, Is.InRange(DateTime.MinValue, DateTime.MaxValue));
            };

            logic.Loop().Times(1000);
        }
    }
}