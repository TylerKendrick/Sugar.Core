/// <summary>
/// Wraps the predefined operators in the BCL as delegates. Allows for operators to be passed as first class functions.
/// </summary>
public static partial class Operators
{
    /// <summary>
    /// An operator that takes no operands
    /// </summary>
    /// <typeparam name="T">The output type of the operation.</typeparam>
    public delegate T Nullary<out T>();

    /// <summary>
    /// An operator that takes one operand.
    /// </summary>
    /// <typeparam name="TIn">The input type of the operator.</typeparam>
    /// <typeparam name="TOut">The output type of the operator.</typeparam>
    /// <param name="target">The operand to which the operation will apply.</param>
    public delegate TOut Unary<in TIn, out TOut>(TIn target);

    /// <summary>
    /// An operator that takes two operands.
    /// </summary>
    /// <typeparam name="TLeft">The input type of the left operand.</typeparam>
    /// <typeparam name="TRight">The input type of the right operand.</typeparam>
    /// <typeparam name="TResult">The output type of the operation.</typeparam>
    /// <param name="left">The left operand to which the operation will apply.</param>
    /// <param name="right">The right operand to which the operation will apply./</param>
    public delegate TResult Binary<in TLeft, in TRight, out TResult>(TLeft left, TRight right);

    /// <summary>
    /// Returns an operator that takes three arguments in the form (condition ? left : right).
    /// Uses lazy evaluation of the parameters based on the specified condition,
    /// allowing the use of cascading ternary operations.
    /// </summary>
    public static System.Func<bool, System.Func<T>, System.Func<T>, T> Ternary<T>()
        => (condition, left, right) => condition ? left() : right();

    /// <summary>
    /// Returns an operator that takes two nullable operators.
    /// Uses lazy evaluation of the parameters to allow the use of cascading coalesce operations.
    /// Resolves to the first non-null value.
    /// </summary>
    public static Binary<T, System.Func<T>, T> Coalesce<T>()
        where T : class => (left, right) => left ?? right();

    /// <summary>
    /// Returns an operator that takes two nullable operators.
    /// Uses lazy evaluation of the parameters to allow the use of cascading coalesce operations.
    /// Resolves to the first non-null value.
    /// </summary>
    public static Binary<T?, System.Func<T?>, T?> NullCoalesce<T>()
        where T : struct => (left, right) => left ?? right();

    /// <summary>
    /// Returns an operator that checks to see if an instance is of the specified type.
    /// </summary>
    public static Unary<object, bool> Is<T>() => instance => instance is T;

    /// <summary>
    /// Returns an operator that attempts to cast a nullable instance to a nullable type.
    /// </summary>
    public static Unary<object, T> As<T>()
        where T : class => instance => instance as T;

    /// <summary>
    /// Returns an operator that returns an instance of <see cref="System.Type"/> for the specified type.
    /// </summary>
    public static Nullary<System.Type> Typeof<T>() => () => typeof(T);

    /// <summary>
    /// Returns an operator that returns the default value of an instance of <typeparamref name="T"/>.
    /// </summary>
    public static Nullary<T> Default<T>() => () => default;
}