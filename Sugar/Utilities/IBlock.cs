namespace System
{
    public interface IBlock : IBlock<IResult> { }

    public interface IBlock<out TResult>
        where TResult : IResult
    {
        TResult Raise();
    }
}