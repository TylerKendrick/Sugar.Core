using System;
using System.Collections.Generic;

namespace Sugar
{
    public static class NumberExtensions
    {
        public static bool IsEven(this int self)
        {
            return self % 2 == 0;
        }
        public static bool IsOdd(this int self)
        {
            return self % 2 != 0;
        }

        public static bool IsNegative(this int self)
        {
            return self < 0;
        }
        public static bool IsPositive(this int self)
        {
            return self >= 0;
        }
        
        public static bool InRange<T>(this T value, T minValue, T maxValue)
            where T : IComparable<T>
        {
            return InRange(value, minValue, maxValue, Comparer<T>.Default);
        }
        public static bool InRange<T>(this T value, T minValue, T maxValue, IComparer<T> comparer) 
            where T : IComparable<T>
        {
            comparer.Require("comparer");

            var greaterThanMin = comparer.Compare(value, maxValue) >= 0;
            var lessThanMax = comparer.Compare(value, minValue) <= 0;
            return greaterThanMin && lessThanMax;
        }
    }
}