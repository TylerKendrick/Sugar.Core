namespace System
{
    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// Represents the null object.
    /// </summary>
    public class Nothing<T> : Nothing, IOption<T>
    {
        /// <summary>
        /// Creates a default instance to represent and return as the null object.
        /// </summary>
        public static readonly new IOption<T> Instance = new Nothing<T>();

        private Nothing()
        {
        }

        /// <summary>
        /// Attempts to retrieve the value of the option if it is not a null object.
        /// </summary>
        /// <param name="value">The attempted value to assign.</param>
        /// <returns>Returns true if the option is not a null object.</returns>
        public bool TryGetValue(out T value)
        {
            value = default;
            return false;
        }
    }

    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// Represents the null object.
    /// </summary>
    public class Nothing : Option
    {
        /// <summary>
        /// Creates a default instance to represent and return as the null object.
        /// </summary>
        internal static readonly Nothing Instance = new Nothing();

        /// <summary>
        /// Indicates whether or not the variable is a null object.
        /// </summary>
        public override bool HasValue => false;

        /// <summary>
        /// Exposes the constructor for extension by derived classes.
        /// </summary>
        protected Nothing()
        {
        }
    }
}