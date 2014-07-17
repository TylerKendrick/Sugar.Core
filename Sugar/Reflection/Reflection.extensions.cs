namespace System.Reflection
{
    using Linq.Expressions;

    /// <summary>
    /// Simplifies invocations of common reflection methods.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Returns the string literal name of a member in a <see cref="MemberExpression"/>.
        /// </summary>
        /// <typeparam name="TCaller">The instance type selected for evaluation with the provided <see cref="MemberExpression"/>.</typeparam>
        /// <typeparam name="TMember">The expected member type</typeparam>
        /// <param name="self">The instance selected for evaluation with the provided <see cref="MemberExpression"/>.</param>
        /// <param name="expression">The <see cref="MemberExpression"/> used to evaluate against the TCaller.</param>
        public static string NameOf<TCaller, TMember>(this TCaller self, Expression<Func<TCaller, TMember>> expression)
        {
            expression.Body.NodeType.Require(x => x == ExpressionType.MemberAccess);

            return expression
                .Cast<MemberExpression>()
                .Member.Name;
        }
        
        /// <summary>
        /// Simplifies the Type.IsSubclassOf invocation.
        /// </summary>
        public static bool IsSubclassOf<TIn, TOut>(this TIn self)
        {
            var callerType = typeof(TIn);
            var targetType = typeof(TOut);
            return callerType.IsSubclassOf(targetType);
        }

        /// <summary>
        /// Simplifies the Type.IsAssignableFrom invocation.
        /// </summary>
        public static bool IsAssignableFrom<TIn, TOut>(this TIn self)
        {
            var callerType = typeof(TIn);
            var targetType = typeof(TOut);
            return callerType.IsAssignableFrom(targetType);
        }

        /// <summary>
        /// Simplifies the Type.IsInstanceOf invocation.
        /// </summary>
        public static bool IsInstanceOf<TIn, TOut>(this TIn self)
        {
            var callerType = typeof(TIn);
            var targetType = typeof(TOut);
            return callerType.IsInstanceOfType(targetType);
        }
    }
}