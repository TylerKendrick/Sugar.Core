using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public partial class AndComparableExpressionTests : UnitTestOf<FluentExpression<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;
        private Mock<IComparer<IFakeConcern>> _mockComparer;
        private AndFluentExpression<IFakeConcern> _falseConcern;

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
            _mockComparer = Register<IComparer<IFakeConcern>>();
        }

        protected override FluentExpression<IFakeConcern> SetUpConcern()
        {
            _falseConcern = new AndFluentExpression<IFakeConcern>(_fakeConcern.Object, false);
            return new AndFluentExpression<IFakeConcern>(_fakeConcern.Object);
        }
    }
}