using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;

namespace Sugar.Tests
{
    [TestFixture]
    public class GenericDictionaryStaticExtensionMethods
    {
        private KeyValuePair<string, string> _keyValuePair1;
        private KeyValuePair<string, string> _keyValuePair2;

        [Test]
        public void NameValueCollectionToDictionaryMatchesExpectationsForConversion()
        {
            const string key1 = "Key1";
            const string key2 = "Key2";
            const string value1 = "Value1";
            const string value2 = "Value2";

            var expectation = new Dictionary<string, string>
            {
                {key1, value1},
                {key2, value2},
            };

            var nameValueCollection = new NameValueCollection();
            foreach (var pair in expectation)
            {
                nameValueCollection.Add(pair.Key, pair.Value);
            }

            Assert.That(nameValueCollection, Has.Count.EqualTo(2));
            Assert.That(nameValueCollection[0], Is.EqualTo(value1));
            Assert.That(nameValueCollection[key1], Is.EqualTo(value1));
            Assert.That(nameValueCollection[1], Is.EqualTo(value2));
            Assert.That(nameValueCollection[key2], Is.EqualTo(value2));
            Assert.That(nameValueCollection, Is.Not.EqualTo(expectation));

            var actual = nameValueCollection.ToDictionary();
            Assert.That(actual, Is.EqualTo(expectation));
        }


        [Test]
        public void DictionaryToNameValueCollectionMatchesExpectationsForConversion()
        {
            const string key1 = "Key1";
            const string key2 = "Key2";
            const string value1 = "Value1";
            const string value2 = "Value2";

            var seed = new Dictionary<string, string>
            {
                {key1, value1},
                {key2, value2},
            };

            var nameValueCollection = new NameValueCollection();
            foreach (var pair in seed)
            {
                nameValueCollection.Add(pair.Key, pair.Value);
            }

            Assert.That(nameValueCollection, Has.Count.EqualTo(2));
            Assert.That(nameValueCollection[0], Is.EqualTo(value1));
            Assert.That(nameValueCollection[key1], Is.EqualTo(value1));
            Assert.That(nameValueCollection[1], Is.EqualTo(value2));
            Assert.That(nameValueCollection[key2], Is.EqualTo(value2));
            Assert.That(nameValueCollection, Is.Not.EqualTo(seed));

            var expectation = nameValueCollection.ToDictionary();
            Assert.That(expectation, Is.EqualTo(seed));

            var actual = seed.ToNameValueCollection();
            Assert.That(actual, Is.EqualTo(nameValueCollection));
        }

        [Test]
        public void EnumerableKeyValuePairToDictionaryMatchesExpectationsForConversion()
        {
            const string key1 = "Key1";
            const string key2 = "Key2";
            const string value1 = "Value1";
            const string value2 = "Value2";

            var expectation = new Dictionary<string, string>
            {
                {key1, value1},
                {key2, value2},
            };

            _keyValuePair1 = new KeyValuePair<string, string>(key1, value1);
            _keyValuePair2 = new KeyValuePair<string, string>(key2, value2);
            var keyValuePairs = new[]
            {
                _keyValuePair1,
                _keyValuePair2 
            };

            Assert.That(keyValuePairs, Has.Length.EqualTo(2));
            Assert.That(keyValuePairs[0], Is.EqualTo(_keyValuePair1));
            Assert.That(keyValuePairs[1], Is.EqualTo(_keyValuePair2));
            Assert.That(keyValuePairs, Is.EqualTo(expectation));

            var actual = keyValuePairs.ToDictionary();
            Assert.That(actual, Is.EqualTo(expectation));
        }
    }
}