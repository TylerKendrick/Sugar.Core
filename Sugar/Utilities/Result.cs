namespace System.Utilities
{
    internal class Result : IResult
    {
        public bool Success { get; private set; }

        public Result(bool success)
        {
            Success = success;
        }
    }
}