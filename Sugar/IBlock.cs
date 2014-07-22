namespace System
{
    /// <summary>
    /// Provides a common interface for wrapping Execution of application logic.
    /// </summary>
    public interface IBlock : IBlock<IResult> { }

    /// <summary>
    /// Provides a common interface for wrapping Execution of application logic.
    /// </summary>
    public interface IBlock<out TResult>
        where TResult : IResult
    {
        /// <summary>
        /// Invokes the try block with the specified configurations.
        /// </summary>
        TResult Raise();
    }
}