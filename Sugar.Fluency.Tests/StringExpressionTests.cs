using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Fluency.Tests
{
    [TestClass]
    public partial class StringExpressionTests : UnitTestOf<IFluentExpression<string>>
    {
        private const string StartString = "Expect";
        private const string EndString = "ation";
        private const string StringContext = StartString + EndString;
        private bool _evaluationResult = true;

        protected override void SetUpMocks()
        {
            _evaluationResult = true;
        }

        protected override IFluentExpression<string> SetUpConcern()
        {
            return new FluentExpression<string>(StringContext, EvaluationFunction);
        }

        private bool EvaluationFunction(bool arg)
        {
            return _evaluationResult;
        }
    }

    public partial class StringExpressionTests
    {
        [TestMethod]
        public void WhenConcernContainsSubstringAndEvaluationIsTrueReturnsTrue()
        {
            _evaluationResult = true;
            var result = Concern.Contains(StringContext.Trim());

            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void WhenConcernContainsSubstringAndEvaluationIsFalseReturnsTrue()
        {
            _evaluationResult = false;
            var result = Concern.Contains(StringContext.Trim());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenConcernDoesNotContainSubstringAndEvaluationIsTrueReturnsTrue()
        {
            _evaluationResult = true;
            var result = Concern.Contains(StringContext.Trim());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenConcernDoesNotContainSubstringAndEvaluationIsFalseReturnsTrue()
        {
            _evaluationResult = false;
            var result = Concern.Contains(StringContext.Trim());

            Assert.IsTrue(result);
        }
    }

    public partial class StringExpressionTests
    {
        [TestMethod]
        public void WhenConcernIsEmptyAndEvaluationIsTrueReturnsTrue()
        {
            _evaluationResult = true;
            var emptyConcern = new FluentExpression<string>(string.Empty, EvaluationFunction);
            var result = emptyConcern.Empty();

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void WhenConcernIsEmptyAndEvaluationIsFalseReturnsTrue()
        {
            _evaluationResult = false;
            var emptyConcern = new FluentExpression<string>(string.Empty, EvaluationFunction);
            var result = emptyConcern.Empty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenConcernIsNotEmptyAndEvaluationIsTrueReturnsFalse()
        {
            _evaluationResult = true;
            var result = Concern.Empty();

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void WhenConcernIsNotEmptyAndEvaluationIsFalseReturnsFalse()
        {
            _evaluationResult = false;
            var result = Concern.Empty();

            Assert.IsFalse(result);
        }
    }
    public partial class StringExpressionTests
    {
        [TestMethod]
        public void WhenConcernEndsWithSubstringAndEvaluationIsTrueReturnsTrue()
        {
            _evaluationResult = true;
            var result = Concern.EndsWith(EndString);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void WhenConcernEndsWithSubstringAndEvaluationIsFalseReturnsTrue()
        {
            _evaluationResult = false;
            var result = Concern.EndsWith(EndString);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenConcernDoesNotEndWithSubstringAndEvaluationIsTrueReturnsFalse()
        {
            _evaluationResult = true;
            var result = Concern.EndsWith(StartString);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void WhenConcernDoesNotEndWithSubstringAndEvaluationIsFalseReturnsFalse()
        {
            _evaluationResult = false;
            var result = Concern.EndsWith(StartString);

            Assert.IsFalse(result);
        }
    }
    public partial class StringExpressionTests
    {
        [TestMethod]
        public void WhenConcernIsNormalizedAndEvaluationIsTrueReturnsTrue()
        {
            _evaluationResult = true;
            var result = Concern.Normalized();

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void WhenConcernIsNormalizedAndEvaluationIsFalseReturnsTrue()
        {
            _evaluationResult = false;
            var result = Concern.Normalized();

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void WhenConcernIsNormalizedAndEvaluationIsTrueReturnsFalse()
        {
            _evaluationResult = true;
            var newConcern = new FluentExpression<string>(
                "CONCERNá".Normalize(NormalizationForm.FormD),
                EvaluationFunction);
            var result = newConcern.Normalized();

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void WhenConcernIsNormalizedAndEvaluationIsFalseReturnsFalse()
        {
            _evaluationResult = false;
            var newConcern = new FluentExpression<string>(
                "CONCERNá".Normalize(NormalizationForm.FormD),
                EvaluationFunction);
            var result = newConcern.Normalized();

            Assert.IsFalse(result);
        }
    }
    public partial class StringExpressionTests
    {
        [TestMethod]
        public void WhenConcernIsNullAndEvaluationIsTrueReturnsTrue()
        {
            _evaluationResult = true;
            var nullConcern = new FluentExpression<string>(null, EvaluationFunction);
            var result = nullConcern.Null();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenConcernIsNullAndEvaluationIsFalseReturnsTrue()
        {
            _evaluationResult = false;
            var nullConcern = new FluentExpression<string>(null, EvaluationFunction);
            var result = nullConcern.Null();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenConcernIsNotNullAndEvaluationIsTrueReturnsFalse()
        {
            _evaluationResult = true;
            var result = Concern.Null();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenConcernIsNotNullAndEvaluationIsFalseReturnsFalse()
        {
            _evaluationResult = false;
            var result = Concern.Null();

            Assert.IsFalse(result);
        }
    }
    public partial class StringExpressionTests
    {
        [TestMethod]
        public void WhenConcernStartsWithSubstringAndEvaluationIsTrueReturnsTrue()
        {
            _evaluationResult = true;
            var result = Concern.StartsWith(StartString);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenConcernStartsWithSubstringAndEvaluationIsFalseReturnsTrue()
        {
            _evaluationResult = false;
            var result = Concern.StartsWith(StartString);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenConcernDoesNotStartWithSubstringAndEvaluationIsTrueReturnsFalse()
        {
            _evaluationResult = true;
            var result = Concern.StartsWith(EndString);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenConcernDoesNotStartWithSubstringAndEvaluationIsFalseReturnsFalse()
        {
            _evaluationResult = false;
            var result = Concern.StartsWith(EndString);

            Assert.IsFalse(result);
        }
    }
    public partial class StringExpressionTests
    {
        [TestMethod]
        public void WhenConcernIsWhitespaceAndEvaluationIsTrueReturnsTrue()
        {
            _evaluationResult = true;
            var whitespaceConcern = new FluentExpression<string>(" ", EvaluationFunction);
            var result = whitespaceConcern.Whitespace();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenConcernIsWhitespaceAndEvaluationIsFalseReturnsTrue()
        {
            _evaluationResult = false;
            var whitespaceConcern = new FluentExpression<string>(" ", EvaluationFunction);
            var result = whitespaceConcern.Whitespace();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenConcernIsNotWhitespaceAndEvaluationIsTrueReturnsFalse()
        {
            _evaluationResult = true;
            var result = Concern.Whitespace();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenConcernIsNotWhitespaceAndEvaluationIsFalseReturnsFalse()
        {
            _evaluationResult = false;
            var result = Concern.Whitespace();

            Assert.IsFalse(result);
        }
    }
}