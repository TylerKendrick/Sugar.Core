namespace System
{
    /// <summary>
    /// Provides an extensible interface for overriding the default configuration of a Try/Catch/Finally block.
    /// Allows for detailed Results and retry behaviors.
    /// </summary>
    public interface ITryConfiguration : IConfiguration<ITryBlock>
    {
        /// <summary>
        /// Determines if a <see cref="TryBlock"/> should retry on failure.
        /// </summary>
        bool ShouldRetry(IInvocationResult result);

        /// <summary>
        /// Generates the value provided to ShouldRetry
        /// </summary>
        IResult GenerateResult(bool success, Exception exception);
    }
}