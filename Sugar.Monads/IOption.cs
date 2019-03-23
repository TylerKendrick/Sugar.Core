namespace System
{
    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// </summary>
    public interface IOption<T> : IOption
    {
        /// <summary>
        /// Attempts to retrieve the value of the option if it is not a null object.
        /// </summary>
        /// <param name="value">The attempted value to assign.</param>
        /// <returns>Returns true if the option is not a null object.</returns>
        bool TryGetValue(out T value);
    }

    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// </summary>
    public interface IOption
    {
        /// <summary>
        /// Indicates whether or not the variable is a null object.
        /// </summary>
        bool HasValue { get; }
    }
}