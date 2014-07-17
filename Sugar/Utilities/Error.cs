namespace System.Utilities
{
    internal static class Error
    {
        public static NullReferenceException Null(string message)
        {
            return new NullReferenceException(message);
        }

        public static ArgumentNullException NullArgument(string paramName = null, string message = null)
        {
            return message.IsNotNull()
                ? new ArgumentNullException(paramName)
                : new ArgumentNullException(paramName, message);
        }

        public static ArgumentException Argument(string paramName = null, string message = null)
        {
            return message.IsNotNull()
                ? new ArgumentException(paramName)
                : new ArgumentException(paramName, message);
        }
        public static Exception NotSupported<T>(string message = null)
        {
            return NotSupported(typeof(T), message);
        }

        public static Exception NotSupported<T>(T value, string message = null)
        {
            return NotSupported(value.GetType(), message);
        }
        public static Exception NotSupported(Type type, string message = null)
        {
            message = message ?? string.Format("Type {0} is not supported.", type);
            var exception = new NotSupportedException(message);
            return exception;
        }

        public static Exception Failure(string message, Exception exception)
        {
            throw new InvalidOperationException(message, exception);
        }
    }
}
