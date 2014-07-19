﻿public static partial class Operators
{
    public static class Byte
    {
        public static readonly Binary<byte, int, int> ShiftLeft = (left, right) => left << right;
        public static readonly Binary<byte, int, int> ShiftRight = (left, right) => left >> right;
        public static readonly Binary<byte, byte, int> And = (left, right) => left & right;
        public static readonly Binary<byte, byte, int> Or = (left, right) => left | right;
        public static readonly Binary<byte, byte, int> XOr = (left, right) => left ^ right;
        public static readonly Unary<byte, int> Not = target => ~target;

        public static readonly Binary<byte, byte, bool> GreaterThan = (left, right) => left > right;
        public static readonly Binary<byte, byte, bool> GreaterThanOrEqual = (left, right) => left >= right;
        public static readonly Binary<byte, byte, bool> LessThan = (left, right) => left < right;
        public static readonly Binary<byte, byte, bool> LessThanOrEqual = (left, right) => left <= right;
        public static readonly Binary<byte, byte, bool> Equal = (left, right) => left == right;
        public static readonly Binary<byte, byte, bool> NotEqual = (left, right) => left != right;
    }
}