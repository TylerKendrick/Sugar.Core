namespace System
{
    using Calculator = Math;
    public static class MathExtensions
    {
        public static decimal Round(this decimal self, ushort precision)
        {
            return Calculator.Round(self, precision);
        }
        public static double Round(this double self, ushort precision)
        {
            return Calculator.Round(self, precision);
        }

        public static decimal ToAbs(this decimal self)
        {
            return Calculator.Abs(self);
        }
        public static double ToAbs(this double self)
        {
            return Calculator.Abs(self);
        }
        public static float ToAbs(this float self)
        {
            return Calculator.Abs(self);
        }
        public static int ToAbs(this int self)
        {
            return Calculator.Abs(self);
        }
        public static long ToAbs(this long self)
        {
            return Calculator.Abs(self);
        }
        public static sbyte ToAbs(this sbyte self)
        {
            return Calculator.Abs(self);
        }
        public static short ToAbs(this short self)
        {
            return Calculator.Abs(self);
        }

        public static decimal ToCeiling(this decimal self)
        {
            return Calculator.Ceiling(self);
        }
        public static double ToCeiling(this double self)
        {
            return Calculator.Ceiling(self);
        }

        public static decimal ToFloor(this decimal self)
        {
            return Calculator.Floor(self);
        }
        public static double ToFloor(this double self)
        {
            return Calculator.Floor(self);
        }

        public static double ToLog(this double self, ushort @base = 10)
        {
            return Calculator.Log(self, @base);
        }

        public static double ToPow(this double self, int power)
        {
            return Calculator.Pow(self, power);
        }

        public static int Sign(this int self)
        {
            return Calculator.Sign(self);
        }

        public static int Sign(this decimal self)
        {
            return Calculator.Sign(self);
        }

        public static int Sign(this double self)
        {
            return Calculator.Sign(self);
        }

        public static int Sign(this float self)
        {
            return Calculator.Sign(self);
        }

        public static int Sign(this long self)
        {
            return Calculator.Sign(self);
        }
    }
}