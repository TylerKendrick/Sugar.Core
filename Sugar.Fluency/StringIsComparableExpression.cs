using System;
using System.Text.RegularExpressions;

namespace Sugar
{
    /// <summary>
    /// Wraps a string context as a comparable expression for fluent evaluation.
    /// </summary>
    public class StringIsComparableExpression : EnumerableIsComparableExpression<char, string>
    {
        private readonly Lazy<StringConditionalExpression> _empty;
        private readonly Lazy<StringConditionalExpression> _null;
        private readonly Lazy<StringConditionalExpression> _whitespace;
        private readonly Lazy<StringConditionalExpression> _uri;
        public StringConditionalExpression Empty { get { return _empty.Value; } }
        public StringConditionalExpression Null { get { return _null.Value; } }
        public StringConditionalExpression Whitespace { get { return _whitespace.Value; } }
        public StringConditionalExpression Uri { get { return _uri.Value; } }

        public StringIsComparableExpression(string context)
            : base(context)
        {
            _uri = new Lazy<StringConditionalExpression>(() =>
                new StringConditionalExpression(context, System.Uri.IsWellFormedUriString(context, UriKind.RelativeOrAbsolute)));
            _whitespace = new Lazy<StringConditionalExpression>(() =>
                new StringConditionalExpression(context, string.IsNullOrWhiteSpace(context) && context != null));
            _null = new Lazy<StringConditionalExpression>(() =>
                new StringConditionalExpression(context, context == null));
            _empty = new Lazy<StringConditionalExpression>(() =>
                new StringConditionalExpression(context, context == string.Empty));
        }

        public StringConditionalExpression Match(Regex regex)
        {
            return new StringConditionalExpression(Context, regex.IsMatch(Context));
        }
    }
}