namespace Sugar
{
    /// <summary>
    /// Provides common operations with struct objects as extention methods.
    /// </summary>
    public static class StructExtensions
    {
        /// <summary>
        /// Converts a provided struct instance to <see cref="System.Nullable{T}"/>.
        /// </summary>
        public static T? AsNullable<T>(this T self)
            where T : struct
        {
            return self;
        }
    }
}
