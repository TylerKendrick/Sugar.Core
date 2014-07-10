using System.Text.RegularExpressions;

namespace Sugar
{
    public interface IStringComparableExpression : ILogicalComparableExpression<string>
    {
        StringConditionalExpression Empty();
        StringConditionalExpression Null();
        StringConditionalExpression Whitespace();
        StringConditionalExpression Uri();

        StringConditionalExpression Match(Regex regex);
        StringConditionalExpression StartsWith(string match);
        StringConditionalExpression EndsWith(string match);
    }
}