using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public partial class OrComparableExpressionTests : UnitTestOf<FluentExpression<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;
        private Mock<IComparer<IFakeConcern>> _mockComparer;
        private OrFluentExpression<IFakeConcern> _trueConcern;

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
            _mockComparer = Register<IComparer<IFakeConcern>>();
        }

        protected override FluentExpression<IFakeConcern> SetUpConcern()
        {
            _trueConcern = new OrFluentExpression<IFakeConcern>(_fakeConcern.Object, true);
            return new OrFluentExpression<IFakeConcern>(_fakeConcern.Object);
        }
    }
}