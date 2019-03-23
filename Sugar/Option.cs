using System.Linq.Expressions;
using System.Reflection;

namespace System
{
    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// </summary>
    public class Option : IEquatable<Option>, IOption
    {
        /// <summary>
        /// Makes sure that the wrapped value is not equal to the specified value Option.Nothing
        /// </summary>
        public virtual bool HasValue => !(this is Nothing);

        /// <summary>
        /// Only used by the "Nothing" comparable value.
        /// </summary>
        protected Option()
        {
        }

        /// <summary>
        /// Compares the HasValue property of an <see cref="Option"/> instance.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Uses reference comparison to determine if each option has a value.</returns>
        public virtual bool Equals(Option other) => HasValue == other.HasValue;
    }

    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// </summary>
    public sealed partial class Option<T>
    {
        /// <summary>
        /// Represents the null object.
        /// </summary>
        public static readonly IOption<T> Nothing = Nothing<T>.Instance;

        /// <summary>
        /// Creates a new instance of <see cref="Something"/>.
        /// </summary>
        public static readonly Func<T, IOption<T>> Something = value => Something<T>.Create(value);

        /// <summary>
        /// Exposes the maybe monad.
        /// Allows for cascading member expressions to return a potentially null value.
        /// </summary>
        /// <typeparam name="TOut">The target output type.</typeparam>
        /// <param name="context">The context for evaluation of the expression.</param>
        /// <param name="expression">The required member expression.</param>
        /// <returns>Returns null if any of the member index expressions return null;
        /// Otherwise, returns the expected value.</returns>
        public static IOption<TOut> Maybe<TOut>(T context, Expression<Func<T, TOut>> expression)
        {
            Require.That(expression.Body.NodeType == ExpressionType.MemberAccess);

            var value = EvaluateBody(context, expression.Body);

            return value == null
                ? Option<TOut>.Nothing
                : Option<TOut>.Something((TOut)value);
        }

        private static object EvaluateBody<TIn>(TIn context, Expression expression)
        {
            object result;
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    result = HandleMemberExpression(context, (MemberExpression)expression);
                    break;
                case ExpressionType.Parameter:
                    result = context;
                    break;
                default:
                    var message = "Expression type {0} is not supported.".Format(expression.NodeType);
                    throw new NotSupportedException(message);
            }

            return result;
        }

        private static object HandleMemberExpression<TIn>(TIn context, MemberExpression memberExpression)
        {
            var value = EvaluateBody(context, memberExpression.Expression);
            return value == null ? null : GetMemberValue(value, memberExpression.Member);
        }

        private static object GetMemberValue(object context, MemberInfo memberInfo)
        {
            object result;
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Property:
                    result = GetPropertyInfoValue(context, memberInfo);
                    break;
                case MemberTypes.Field:
                    result = GetFieldInfoValue(context, memberInfo);
                    break;
                default:
                    var message = "Expression of type {0} is not supported.  Only Member Access may be used."
                        .Format(memberInfo.MemberType);
                    throw new NotSupportedException(message);
            }
            return result;
        }

        private static object GetFieldInfoValue(object context, MemberInfo memberInfo)
            => ((FieldInfo)memberInfo).GetValue(context);

        private static object GetPropertyInfoValue(object context, MemberInfo memberInfo)
            => ((PropertyInfo)memberInfo).GetValue(context, null);
    }

    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// </summary>
    public partial class Option<T> : IOption<T>
    {
        private readonly IOption<T> _handle;

        /// <summary>
        /// Exposes the constructor as a delegate.
        /// </summary>
        public static readonly Func<IOption<T>, Option<T>> Create = option => new Option<T>(option);

        /// <summary>
        /// Makes sure that the wrapped value is not equal to the specified value Option.Nothing
        /// </summary>
        public bool HasValue => _handle.HasValue;

        private Option(IOption<T> handle) => _handle = handle;

        /// <summary>
        /// Attempts to retrieve the value of the option if it is not a null object.
        /// </summary>
        /// <param name="value">The attempted value to assign.</param>
        /// <returns>Returns true if the option is not a null object.</returns>
        public bool TryGetValue(out T value) => _handle.TryGetValue(out value);
    }
}