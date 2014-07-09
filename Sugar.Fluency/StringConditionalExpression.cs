using System;

namespace Sugar
{
    /// <summary>
    /// Provides conditional expressions for fluent evaluation for string objects.
    /// </summary>
    public class StringConditionalExpression : ConditionalExpression<string, StringComparableExpression, StringComparableExpression>
    {
        /// <summary>
        /// Wraps the specified string for evaluation with fluent expressions.
        /// </summary>
        public StringConditionalExpression(string handle, bool? offset = null)
            : base(handle, offset)
        {
        }

        protected override StringComparableExpression CreateOrExpression(string handle, bool? offset)
        {
            return new StringComparableExpression(handle, x =>
                offset.HasValue ? offset.Value || x : x);
        }

        protected override StringComparableExpression CreateAndExpression(string handle, bool? offset)
        {
            return new StringComparableExpression(handle, x =>
                offset.HasValue ? offset.Value && x : x);
        }

        protected override StringComparableExpression CreateNotExpression(string handle, bool? offset)
        {
            return new StringComparableExpression(handle, x =>
                offset.HasValue ? offset.Value || !x : !x);
        }

        /// <summary>
        /// Evaluates the expression tree and returns the result as a single bool.
        /// </summary>
        public static implicit operator bool(StringConditionalExpression handle)
        {
            var result = handle.Offset;
            return result.HasValue && result.Value;
        }

        /// <summary>
        /// Returns the expression as a function for evaluation.  Useful for compatibility with linq extensions.
        /// </summary>
        public static implicit operator Func<string, bool>(StringConditionalExpression handle)
        {
            return x => handle;
        }

        /// <summary>
        /// Returns the expression as a function for evaluation.  Useful for compatibility with linq extensions.
        /// </summary>
        public static implicit operator Predicate<string>(StringConditionalExpression handle)
        {
            return x => handle;
        }
    }
}