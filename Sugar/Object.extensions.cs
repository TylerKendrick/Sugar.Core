﻿using System;
using System.IO;
using Sugar.Utilities;

namespace Sugar
{
    public static class ObjectExtensions
    {
        public static T Cast<T>(this object self, T fallbackValue = default(T))
        {
            return self is T ? (T)self : fallbackValue;
        }

        public static TOut ConvertTo<TOut>(this object self, TOut fallbackValue = default(TOut))
        {
            return Convert.ChangeType(self, typeof (TOut)).Cast(fallbackValue);
        }

        public static void Require<T>(this T self, Func<T, bool> predicate)
        {
            if (!predicate(self))
            {
                var value = predicate.ToString();
                var message = "Predicate \"{0}\" evaluated as false.";
                message = string.Format(message, value);
                var exception = Error.Argument("predicate", message);
                throw Error.Failure(message, exception);
            }
        }

        public static void Require<T>(this T self, FluentPredicate<T> predicate)
        {
            if (!predicate)
            {
                throw new InvalidDataException();
            }
        }

        public static void Require<T>(this T self, Func<IIt<T>, FluentPredicate<T>> predicate)
        {
            if (!Fluent.It(self, predicate))
            {
                throw new InvalidDataException();
            }
        }

        public static void Require<T>(this T self, Func<T, bool> predicate, string errorMessage)
        {
            if (!predicate(self))
            {
                throw new InvalidDataException(errorMessage);
            }
        }

        public static void Require<T>(this T self, Func<T, bool> predicate, Exception innerException)
        {
            if (!predicate(self))
            {
                throw innerException;
            }
        }
    }
}