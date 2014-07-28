namespace System
{
    /// <summary>
    /// Provides an extensible interface for generic configuration.
    /// </summary>
    public interface IConfiguration<out T>
    {
        /// <summary>
        /// Provides an instance of the specified <typeparamref name="T"/>.
        /// </summary>
        T Configure();
    }
}