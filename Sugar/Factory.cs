namespace System
{
    public static class Factory<T>
        where T : new()
    {
        public static readonly Operators.Nullary<T> Create = () => new T();
    }

    public static class Factory
    {
        public static T Create<T>()
            where T : new()
        {
            return Factory<T>.Create();
        }
    }
}