using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public partial class NotComparableExpressionTests : UnitTestOf<ComparableExpression<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;
        private Mock<IComparer<IFakeConcern>> _mockComparer;

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
            _mockComparer = Register<IComparer<IFakeConcern>>();
        }

        protected override ComparableExpression<IFakeConcern> SetUpConcern()
        {
            return new NotComparableExpression<IFakeConcern>(_fakeConcern.Object);
        }
    }
}