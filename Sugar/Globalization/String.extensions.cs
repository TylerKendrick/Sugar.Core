namespace System.Globalization
{
    using Threading;

    /// <summary>
    /// Provides extensions to simplify string formatting.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Simplifies invocation of CultureInfo.TextInfo.ToTitleCase.
        /// </summary>
        /// <param name="self">The target string.</param>
        /// <param name="textInfo">Uses Thread.CurrentThread.CurrentCulture.TextInfo if null.</param>
        public static string ToTitleCase(this string self, TextInfo textInfo = null)
        {
            var thread = Thread.CurrentThread;
            textInfo = textInfo ?? thread.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(self);
        }

        /// <summary>
        /// Parses the string with Double.TryParse.
        /// </summary>
        /// <param name="self">The target string</param>
        /// <param name="cultureInfo">Uses Thread.CurrentThread.CurrentUICulture if null.</param>
        public static bool IsNumber(this string self, CultureInfo cultureInfo = null)
        {
            cultureInfo = cultureInfo ?? Thread.CurrentThread.CurrentUICulture;
            return double.TryParse(self, NumberStyles.Any,
                cultureInfo, out double result);
        }
    }
}
