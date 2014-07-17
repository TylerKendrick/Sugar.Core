using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace System.Fluency.Tests
{
    [TestClass]
    public partial class NotComparableExpressionTests : UnitTestOf<FluentExpression<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;
        private Mock<IComparer<IFakeConcern>> _mockComparer;

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
            _mockComparer = Register<IComparer<IFakeConcern>>();
        }

        protected override FluentExpression<IFakeConcern> SetUpConcern()
        {
            return new NotFluentExpression<IFakeConcern>(_fakeConcern.Object);
        }
    }
}