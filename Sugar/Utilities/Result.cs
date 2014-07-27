namespace System.Utilities
{
    internal class Result : IResult
    {
        public bool Success { get; private set; }

        public static readonly Func<bool, IResult> Create = success => new Result(success);

        private Result(bool success)
        {
            Success = success;
        }
    }
}