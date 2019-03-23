namespace System
{
    /// <summary>
    /// Provides an extensible interface for handling the results of function invocation.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Indicates if the invocation had errors.
        /// </summary>
        bool Success { get; }
    }
}