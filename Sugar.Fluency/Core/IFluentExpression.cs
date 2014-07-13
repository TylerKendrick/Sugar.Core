namespace Sugar
{
    /// <summary>
    /// Provides a new instance of a <see cref="FluentPredicate{T}"/> for expressions common to all object types.
    /// </summary>
    public interface IFluentExpression<out T>
    {
        T Context { get; }
        bool Evaluate(bool isEqual);
    }
}