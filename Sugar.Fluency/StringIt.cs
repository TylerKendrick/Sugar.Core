namespace Sugar
{
    public class StringIt : It<string, StringIsComparableExpression>
    {
        public StringIt(string handle)
            : base(() => new StringIsComparableExpression(handle))
        {
        }
    }
}