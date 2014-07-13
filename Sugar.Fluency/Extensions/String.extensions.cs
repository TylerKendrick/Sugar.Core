using System.Text;
using Sugar.Extensions;

namespace Sugar
{
    public static class StringComparableExtensions
    {
        public static FluentPredicate<string> Empty(this IFluentExpression<string> self)
        {
            return self.Generate(x => x == string.Empty);
        }

        public static FluentPredicate<string> Null(this IFluentExpression<string> self)
        {
            return self.Generate(x => x == null);
        }

        public static FluentPredicate<string> Whitespace(this IFluentExpression<string> self)
        {
            return self.Generate(x => x != null && string.IsNullOrEmpty(x.Trim()));
        }
        
        public static FluentPredicate<string> StartsWith(this IFluentExpression<string> self, string match)
        {
            return self.Generate(x => x.StartsWith(match));
        }

        public static FluentPredicate<string> EndsWith(this IFluentExpression<string> self, string match)
        {
            return self.Generate(x => x.EndsWith(match));
        }

        public static FluentPredicate<string> Normalized(this IFluentExpression<string> self)
        {
            return self.Generate(x => x.IsNormalized());
        }
        public static FluentPredicate<string> Normalized(this IFluentExpression<string> self,
            NormalizationForm normalizationForm)
        {
            return self.Generate(x => x.IsNormalized(normalizationForm));
        }
        public static FluentPredicate<string> Contains(this IFluentExpression<string> self, string value)
        {
            return self.Generate(x => x.Contains(value));
        }
    }
}