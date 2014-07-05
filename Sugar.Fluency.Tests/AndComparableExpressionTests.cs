using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sugar.Fluency.Tests
{
    [TestClass]
    public partial class AndComparableExpressionTests : UnitTestOf<AndComparableExpression<IFakeConcern>>
    {
        private Mock<IFakeConcern> _fakeConcern;
        private Mock<IComparer<IFakeConcern>> _mockComparer;
        private AndComparableExpression<IFakeConcern> _falseConcern;

        protected override void SetUpMocks()
        {
            _fakeConcern = Register<IFakeConcern>();
            _mockComparer = Register<IComparer<IFakeConcern>>();
        }

        protected override AndComparableExpression<IFakeConcern> SetUpConcern()
        {
            _falseConcern = new AndComparableExpression<IFakeConcern>(_fakeConcern.Object, false);
            return new AndComparableExpression<IFakeConcern>(_fakeConcern.Object);
        }
    }
}