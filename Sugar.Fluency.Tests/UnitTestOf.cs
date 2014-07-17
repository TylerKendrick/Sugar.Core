﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace System.Fluency.Tests
{
    public abstract class UnitTestOf<T>
    {
        private MockRepository _mockRepository;
        protected T Concern;

        [TestInitialize]
        public virtual void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
            SetUpMocks();
            Concern = SetUpConcern();
        }

        [TestCleanup]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        protected abstract void SetUpMocks();
        protected abstract T SetUpConcern();

        protected Mock<TMock> Register<TMock>()
            where TMock : class
        {
            return _mockRepository.Create<TMock>();
        }

        protected Mock<IEnumerable<TMock>> RegisterMany<TMock>(IEnumerable<TMock> results = null)
        {
            results = results ?? Enumerable.Empty<TMock>();
            var result = _mockRepository.Create<IEnumerable<TMock>>();
            result
                .Setup(x => x.GetEnumerator())
                .Returns(results.GetEnumerator);
            return result;
        }
    }
}