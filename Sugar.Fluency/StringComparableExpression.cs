using System;
using System.Text.RegularExpressions;

namespace Sugar
{
    public class StringComparableExpression : LogicalComparableExpression<string>, IStringComparableExpression
    {
        private readonly Lazy<StringConditionalExpression> _empty;
        private readonly Lazy<StringConditionalExpression> _null;
        private readonly Lazy<StringConditionalExpression> _whitespace;
        private readonly Lazy<StringConditionalExpression> _uri;

        public StringConditionalExpression Empty()
        {
            return _empty.Value;
        }

        public StringConditionalExpression Null()
        {
            return _null.Value;
        }

        public StringConditionalExpression Whitespace()
        {
            return _whitespace.Value;
        }

        public StringConditionalExpression Uri()
        {
            return _uri.Value;
        }

        public StringComparableExpression(string context, Func<bool, bool> evaluate = null)
            : base(context, evaluate)
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

        public StringConditionalExpression StartsWith(string match)
        {
            return new StringConditionalExpression(Context, Context.StartsWith(match));
        }
        public StringConditionalExpression EndsWith(string match)
        {
            return new StringConditionalExpression(Context, Context.EndsWith(match));
        }
    }
}