using System.Collections.Generic;
using System.Utilities;

namespace System
{
    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// Represents a non-null value.
    /// </summary>
    public class Something : Option, IEquatable<Something>
    {
        /// <summary>
        /// Exposes the constructor as a delegate.
        /// </summary>
        public static Func<object, Something> Create = value => new Something(value);

        /// <summary>
        /// The value wrapped by the <see cref="Option"/> instance.
        /// </summary>
        protected readonly object Value;

        /// <summary>
        /// Indicates whether or not the variable is a null object.
        /// </summary>
        public override bool HasValue => true;

        /// <summary>
        /// Exposes the constructor for extension by derived classes.
        /// </summary>
        protected Something(object value) => Value = value;

        /// <summary>
        /// Compares Value properties.
        /// </summary>
        public bool Equals(Something other) => HasValue == other.HasValue
            ? Value.Equals(other.Value)
            : HasValue && other.HasValue;

        /// <summary>
        /// Calls custom comparison for <see cref="Something"/> instances.
        /// </summary>
        public override bool Equals(object obj) => obj is Something something
            ? Equals(something)
            // ReSharper disable once BaseObjectEqualsIsObjectEquals
            : base.Equals(obj);

        /// <summary>
        /// Returns the hash code of the wrapped value.
        /// </summary>
        public override int GetHashCode() => HasValue
            ? EqualityComparer<object>.Default.GetHashCode()
            : EqualityComparer<object>.Default.GetHashCode(Value);
    }

    /// <summary>
    /// Exposes the null object pattern for both reference and value types.
    /// Represents a non-null value.
    /// </summary>
    /// <typeparam name="T">The specified type to wrap.</typeparam>
    public sealed class Something<T> : Something, IOption<T>
    {
        private readonly T _value;

        private Something(T value)
            : base(value) => _value = value;

        /// <summary>
        /// Exposes the constructor as a delegate.
        /// </summary>
        public static readonly new Func<T, Something<T>> Create = value => new Something<T>(value);

        /// <summary>
        /// Exposes the wrapped value if one is specified.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public new T Value => !HasValue ? throw Error.Null("No value was matched.") : _value;

        /// <summary>
        /// Returns the hash code of the wrapped value.
        /// </summary>
        public override int GetHashCode() => HasValue
            ? EqualityComparer<T>.Default.GetHashCode()
            : EqualityComparer<T>.Default.GetHashCode(_value);

        /// <summary>
        /// Attempts to retrieve the value of the option if it is not a null object.
        /// </summary>
        /// <param name="value">The attempted value to assign.</param>
        /// <returns>Returns true if the option is not a null object.</returns>
        public bool TryGetValue(out T value)
        {
            value = _value;
            return true;
        }

        /// <summary>
        /// Calls custom comparison for <see cref="Something"/> instances.
        /// </summary>
        public override bool Equals(object obj)
        {
            var option = obj as Something<T> ?? Something.Create(obj);
            return option.Equals(this);
        }

        /// <summary>
        /// Exposes an implicit conversion for specified types.
        /// </summary>
        public static implicit operator Something<T>(T value) => Create(value);
    }
}