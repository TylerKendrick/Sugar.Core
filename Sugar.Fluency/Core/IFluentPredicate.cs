namespace System
{
    public interface IFluentPredicate
    {
        bool Resolve();
    }
    /// <summary>
    /// Provides predicate comparable expressions for fluent evaluation.
    /// </summary>
    /// <typeparam name="T">The kind of object being used for evaluation.</typeparam>
    /// <typeparam name="TComparable">The type used to negate logical expressions.</typeparam>
    /// <typeparam name="TLogical">The type used for logical expressions.</typeparam>
    public interface IFluentPredicate<out T, out TComparable, out TLogical> : IFluentPredicate
        where TComparable : IFluentExpression<T>
        where TLogical : ILogicalFluentExpression<T>, TComparable
    {
        /// <summary>
        /// The object used for evaluating the predicate.
        /// </summary>
        T Context { get; }

        /// <summary>
        /// Negates the preceeding comparable expressions during evaluation.
        /// </summary>
        TComparable Not { get; }

        /// <summary>
        /// Compounds the preceeding comparable expressions during evaluation.
        /// </summary>
        TLogical And { get; }

        /// <summary>
        /// Substitutes preceeding comparables epressions that evaluate to false.
        /// </summary>
        TLogical Or { get; }
    }

    /// <summary>
    /// Provides predicate comparable expressions for fluent evaluation.
    /// </summary>
    /// <typeparam name="T">The kind of object being used for evaluation.</typeparam>
    public interface IFluentPredicate<T> : 
        IFluentPredicate<T, FluentExpression<T>, LogicalFluentExpression<T>>
    {
    }
}