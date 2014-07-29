using System.Collections.Generic;
using System.Utilities;

namespace System
{
    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// </summary>
    public class Option : IEquatable<Option>
    {
        /// <summary>
        /// A comparable value to represent no-value for a given type.
        /// </summary>
        public static readonly Option Nothing = new Option();

        /// <summary>
        /// Makes sure that the wrapped value is not equal to the specified value Option.Nothing
        /// </summary>
        public bool HasValue { get { return !Equals(Nothing); } }

        private readonly object _value;


        /// <summary>
        /// Only used by the "Nothing" comparable value.
        /// </summary>
        private Option()
        {
            
        }

        /// <summary>
        /// Used by typed derived class <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="value"></param>
        protected Option(object value)
        {
            _value = value;
        }

        public bool Equals(Option other)
        {
            return HasValue == other.HasValue
                ? _value.Equals(other._value)
                : HasValue && other.HasValue;
        }

        protected internal static Option Create(object value)
        {
            return new Option(value);
        }
    }

    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// </summary>
    /// <typeparam name="T">The specified type to wrap.</typeparam>
    public class Option<T> : Option
    {
        private readonly T _value;

        private Option(T value)
            : base(value)
        {
            _value = value;
        }

        /// <summary>
        /// Exposes the constructor as a delegate.
        /// </summary>
        public static readonly Func<T, Option<T>> From = value => new Option<T>(value);

        /// <summary>
        /// Exposes the wrapped value if one is specified.
        /// </summary>
        public T Value
        {
            get
            {
                if (!HasValue) throw Error.Null("No value was matched.");

                return _value;
            }
        }

        public override int GetHashCode()
        {
            return HasValue
                ? EqualityComparer<T>.Default.GetHashCode()
                : EqualityComparer<T>.Default.GetHashCode(_value);
        }

        public override bool Equals(object obj)
        {
            var option = obj as Option<T> ?? Create(obj);
            return option.Equals(this);
        }

        /// <summary>
        /// Exposes an implicit conversion for speficied types.
        /// </summary>
        public static implicit operator Option<T>(T value)
        {
            return From(value);
        }
    }
}