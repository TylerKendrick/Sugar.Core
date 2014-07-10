using System;
using System.Text.RegularExpressions;

namespace Sugar
{
    public static class StringComparableExtensions
    {
        public static ConditionalExpression<string> Empty(this IComparableExpression<string> self)
        {
            return self.Generate(x => x == string.Empty);
        }

        public static ConditionalExpression<string> Null(this IComparableExpression<string> self)
        {
            return self.Generate(x => x == null);
        }

        public static ConditionalExpression<string> Whitespace(this IComparableExpression<string> self)
        {
            return self.Generate(x => x != null && string.IsNullOrEmpty(x.Trim()));
        }

        public static ConditionalExpression<string> Uri(this IComparableExpression<string> self)
        {
            return self.Generate(x => System.Uri.IsWellFormedUriString(x, UriKind.RelativeOrAbsolute));
        }

        public static ConditionalExpression<string> Match(this IComparableExpression<string> self, Regex regex)
        {
            return self.Generate(regex.IsMatch);
        }

        public static ConditionalExpression<string> StartsWith(this IComparableExpression<string> self, string match)
        {
            return self.Generate(x => x.StartsWith(match));
        }

        public static ConditionalExpression<string> EndsWith(this IComparableExpression<string> self, string match)
        {
            return self.Generate(x => x.EndsWith(match));
        }

        private static ConditionalExpression<string> Generate(this IComparableExpression<string, ConditionalExpression<string>> self, 
            Func<string, bool> predicate)
        {
            return new ConditionalExpression<string>(self.Context, predicate(self.Context));
        }
    }
}