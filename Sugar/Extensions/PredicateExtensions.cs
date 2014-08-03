namespace System
{
    public static class PredicateExtensions
    {
        public static Func<T, bool> And<T>(this Func<T, bool> self, Func<T, bool> other)
        {
            return x => self(x) && other(x);
        }
        public static Func<T, bool> Or<T>(this Func<T, bool> self, Func<T, bool> other)
        {
            return x => self(x) || other(x);
        }
        public static Func<T, bool> Not<T>(this Func<T, bool> self)
        {
            return x => !self(x);
        }

        public static Func<T, bool> And<T>(this Func<T, bool> self, Predicate<T> other)
        {
            return x => self(x) && other(x);
        }
        public static Func<T, bool> Or<T>(this Func<T, bool> self, Predicate<T> other)
        {
            return x => self(x) || other(x);
        }

        public static Func<T, bool> And<T>(this Func<T, bool> self, bool other)
        {
            return x => self(x) && other;
        }
        public static Func<T, bool> Or<T>(this Func<T, bool> self, bool other)
        {
            return x => self(x) || other;
        }
        public static Func<T, bool> Not<T>(this Predicate<T> self)
        {
            return x => !self(x);
        }

        public static Func<T, bool> And<T>(this Predicate<T> self, Func<T, bool> other)
        {
            return x => self(x) && other(x);
        }
        public static Func<T, bool> Or<T>(this Predicate<T> self, Func<T, bool> other)
        {
            return x => self(x) || other(x);
        }

        public static Func<T, bool> And<T>(this Predicate<T> self, Predicate<T> other)
        {
            return x => self(x) && other(x);
        }
        public static Func<T, bool> Or<T>(this Predicate<T> self, Predicate<T> other)
        {
            return x => self(x) || other(x);
        }

        public static Func<T, bool> And<T>(this Predicate<T> self, bool other)
        {
            return x => self(x) && other;
        }
        public static Func<T, bool> Or<T>(this Predicate<T> self, bool other)
        {
            return x => self(x) || other;
        }
    }
}