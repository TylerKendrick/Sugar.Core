﻿public static partial class Operators
{
    /// <summary>
    /// Provides the operators implemented by System.Core on the <see cref="Long"/> 
    /// datatype as delegates for use as first-class objects.
    /// </summary>
    public static class Long
    {
        public static readonly Binary<long, int, long> ShiftLeft = (left, right) => left << right;
        public static readonly Binary<long, int, long> ShiftRight = (left, right) => left >> right;
        public static readonly Binary<long, long, long> And = (left, right) => left & right;
        public static readonly Binary<long, long, long> Or = (left, right) => left | right;
        public static readonly Binary<long, long, long> XOr = (left, right) => left ^ right;
        public static readonly Unary<long, long> Not = target => ~target;

        public static readonly Binary<long, long, long> Add = (left, right) => left + right;
        public static readonly Binary<long, long, long> Subtract = (left, right) => left - right;
        public static readonly Binary<long, long, long> Multiply = (left, right) => left * right;
        public static readonly Binary<long, long, long> Divide = (left, right) => left / right;
        public static readonly Binary<long, long, long> Modulo = (left, right) => left % right;
        public static readonly Unary<long, long> Negate = target => -target;
        public static readonly Unary<long, long> Increment = target => target + 1;
        public static readonly Unary<long, long> Decrement = target => target - 1;

        public static readonly Binary<long, long, bool> GreaterThan = (left, right) => left > right;
        public static readonly Binary<long, long, bool> GreaterThanOrEqual = (left, right) => left >= right;
        public static readonly Binary<long, long, bool> LessThan = (left, right) => left < right;
        public static readonly Binary<long, long, bool> LessThanOrEqual = (left, right) => left <= right;
        public static readonly Binary<long, long, bool> Equality = (left, right) => left == right;
        public static readonly Binary<long, long, bool> Inequality = (left, right) => left != right;
    }
}