namespace Sugar
{
    public static class IntExtensions
    {
        public static int And(this int self, int other)
        {
            return self & other;
        }

        public static int Or(this int self, int other)
        {
            return self | other;
        }
        public static int XOr(this int self, int other)
        {
            return self ^ other;
        }
        public static int Not(this int self)
        {
            return ~self;
        }
    }
}