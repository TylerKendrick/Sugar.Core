using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public partial class ComparableExpressionTests : UnitTestOf<ComparableExpression<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;
        private Mock<IComparer<IFakeConcern>> _mockComparer;
        private readonly Func<bool, bool> _offset = null; 

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
            _mockComparer = Register<IComparer<IFakeConcern>>();
        }

        protected override ComparableExpression<IFakeConcern> SetUpConcern()
        {
            return new ComparableExpression<IFakeConcern>(_fakeConcern.Object, _offset);
        }
    }
}