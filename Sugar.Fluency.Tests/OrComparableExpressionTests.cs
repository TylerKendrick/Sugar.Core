using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public partial class OrComparableExpressionTests : UnitTestOf<OrComparableExpression<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;
        private Mock<IComparer<IFakeConcern>> _mockComparer;
        private OrComparableExpression<IFakeConcern> _trueConcern;

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
            _mockComparer = Register<IComparer<IFakeConcern>>();
        }

        protected override OrComparableExpression<IFakeConcern> SetUpConcern()
        {
            _trueConcern = new OrComparableExpression<IFakeConcern>(_fakeConcern.Object, true);
            return new OrComparableExpression<IFakeConcern>(_fakeConcern.Object);
        }
    }
}