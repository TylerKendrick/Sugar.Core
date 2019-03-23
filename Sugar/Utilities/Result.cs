namespace System.Utilities
{
    internal sealed class Result : IResult
    {
        public bool Success { get; }

        public static readonly Func<bool, IResult> Create = success => new Result(success);

        private Result(bool success) => Success = success;
    }
}