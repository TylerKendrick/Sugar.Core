namespace System
{
    /// <summary>
    /// Provides an extensible interface for generic configuration.
    /// </summary>
    public interface IConfiguration<out T>
    {
        T Configure();
    }
}