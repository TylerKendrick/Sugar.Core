﻿using System;
using System.Linq;

namespace Sugar
{
    public static partial class Bitwise
    {
        /// <summary>
        /// Returns the bitwise and operation result between self and other.
        /// </summary>
        public static int And(this int self, int other)
        {
            return self & other;
        }

        /// <summary>
        /// Applies an aggregator function to the results of <paramref name="self"/> 
        /// applied against each item in <paramref name="others"/>
        /// with the bitwise & operator.
        /// </summary>
        /// <param name="self">The target int operand.</param>
        /// <param name="aggregator">The aggregation applied to each result.</param>
        /// <param name="others">A collection of ints to apply against <paramref name="self"/>.</param>
        /// <returns>A single <see cref="int"/> value representing </returns>
        public static int And(this int self, Func<int, int, int> aggregator, params int[] others)
        {
            return others
                .Select(x => And(self, x))
                .Aggregate(aggregator);
        }

        /// <summary>
        /// Returns the bitwise or operation result between self and other.
        /// </summary>
        public static int Or(this int self, int other)
        {
            return self | other;
        }

        /// <summary>
        /// Applies an aggregator function to the results of <paramref name="self"/> 
        /// applied against each item in <paramref name="others"/>
        /// with the bitwise | operator.
        /// </summary>
        /// <param name="self">The target int operand.</param>
        /// <param name="aggregator">The aggregation applied to each result.</param>
        /// <param name="others">A collection of ints to apply against <paramref name="self"/>.</param>
        /// <returns>A single int value representing </returns>
        public static int Or(this int self, Func<int, int, int> aggregator, params int[] others)
        {
            return others
                .Select(x => Or(self, x))
                .Aggregate(aggregator);
        }

        /// <summary>
        /// Returns the bitwise xor operation result between self and other.
        /// </summary>
        public static int XOr(this int self, int other)
        {
            return self ^ other;
        }

        /// <summary>
        /// Applies an aggregator function to the results of <paramref name="self"/> 
        /// applied against each item in <paramref name="others"/>
        /// with the bitwise ^ operator.
        /// </summary>
        /// <param name="self">The target int operand.</param>
        /// <param name="aggregator">The aggregation applied to each result.</param>
        /// <param name="others">A collection of ints to apply against <paramref name="self"/>.</param>
        /// <returns>A single int value representing </returns>
        public static int XOr(this int self, Func<int, int, int> aggregator, params int[] others)
        {
            return others
                .Select(x => XOr(self, x))
                .Aggregate(aggregator);
        }


        /// <summary>
        /// Returns the bitwise not operation result between self and other.
        /// </summary>
        public static int Not(this int self)
        {
            return ~self;
        }
    }
}