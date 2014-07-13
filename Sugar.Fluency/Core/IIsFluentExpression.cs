namespace Sugar
{
    /// <summary>
    /// Provides additional expressions for fluent evaluation.
    /// </summary>
    public interface IIsFluentExpression<out T> : IFluentExpression<T>
    {
        IFluentExpression<T> Not { get; } 
    }
}