namespace System
{
    /// <summary>
    /// Wraps and generates calls to object with a public parameterless constructor.
    /// </summary>
    /// <typeparam name="T">Any type that implements a public parameterless constructor.</typeparam>
    public static class Factory<T>
        where T : new()
    {
        /// <summary>
        /// Invokes the constructor of a specified type <typeparamref name="T"/>.
        /// </summary>
        public static readonly Operators.Nullary<T> Create = () => new T();
    }

    /// <summary>
    /// Wraps and generates calls to object with a public, parameterless constructor.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Invokes the Factory{T}.Create delegate.
        /// </summary>
        /// <typeparam name="T">Any type that implements a public parameterless constructor.</typeparam>
        public static T Create<T>()
            where T : new() => Factory<T>.Create();
    }
}