namespace System.Extensions
{
    /// <summary>
    /// Provides common operations with the Garbage collector as extension methods.
    /// </summary>
    public static class GCExtensions
    {
        /// <summary>
        /// Wraps the static method GC.GetGeneration as an extension method.
        /// </summary>
        public static int GetGeneration(this WeakReference self)
        {
            return GC.GetGeneration(self);
        }

        /// <summary>
        /// Wraps the static method GC.KeepAlive as an extension method.
        /// </summary>
        public static void KeepAlive(this object self)
        {
            GC.KeepAlive(self);
        }

        /// <summary>
        /// Wraps the static method GC.ReRegisterForFinalize as an extension method.
        /// </summary>
        public static void ReRegisterForFinalize(this object self)
        {
            GC.ReRegisterForFinalize(self);
        }

        /// <summary>
        /// Wraps the static method GC.SuppressFinalize as an extension method.
        /// </summary>
        public static void SuppressFinalize(this object self)
        {
            GC.SuppressFinalize(self);
        }
    }
}