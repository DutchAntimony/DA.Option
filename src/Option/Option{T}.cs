using System.Diagnostics.CodeAnalysis;

namespace DA.Option;

/// <summary>
/// An Option is a monat around a <typeparamref name="TValue"/>.
/// The option can either be Some(), e.g. have a value, or None(), e.g. does not have a value.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public readonly struct Option<TValue> : IEquatable<Option<TValue>>, IEquatable<object>
{
    /// <summary>
    /// The value of the option, can be null if the option is none.
    /// </summary>
    private readonly TValue? _value;

    /// <summary>
    /// Boolean indicating whether or not the option has a value.
    /// </summary>
    public bool HasValue { get; }
    public bool HasNoValue => !HasValue;

    /// <summary>
    /// Option can only be constructed privataly by providing a value or None.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="hasValue"></param>
    private Option(TValue? value, bool hasValue) => (_value, HasValue) = (value, hasValue);

    /// <summary>
    /// Initialize the option with a value
    /// </summary>
    /// <param name="value">The value of the option.</param>
    public static Option<TValue> Some(TValue value) => value is null ? None() : new(value, true);

    /// <summary>
    /// Initialize the option without a value
    /// </summary>
    public static Option<TValue> None() => new(default, false);

    /// <summary>
    /// Explicitly create a option from a nullable value.
    /// </summary>
    /// <param name="value">The nullable value to convert to an option.</param>
    /// <returns>Option.None if the value is null, Option.Some(value) if not null.</returns>
    public static Option<TValue> From(TValue? value) => value is null ? None() : Some(value);

    /// <summary>
    /// Implicitly convert any option option to an none option of <typeparamref name="TValue"/>
    /// Works because the only non-generic option that can be constructed is none option.
    /// </summary>
    public static implicit operator Option<TValue>(Option _) => None();

    /// <summary>
    /// Try to get the underlying value of the option.
    /// </summary>
    /// <param name="value">out parameter giving the value.</param>
    /// <returns>Boolean indicating if the option has a set value.</returns>
    public bool TryGetValue([NotNullWhen(true), MaybeNullWhen(false)] out TValue value)
    {
        value = _value;
        return HasValue;
    }

    /// <summary>
    /// Override the toString method to return the objects ToString if the Option has a value, and a empty string if not.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => HasValue ? _value!.ToString()! : string.Empty;

    #region IEquatable
    public static bool operator ==(Option<TValue> option, TValue value)
    {
        if (option.HasNoValue) return value is null;
        return option._value!.Equals(value);
    }
    public static bool operator !=(Option<TValue> option, TValue value) => !(option == value);
    public static bool operator ==(Option<TValue> option, object other) => option.Equals(other);
    public static bool operator !=(Option<TValue> option, object other) => !(option == other);
    public static bool operator ==(Option<TValue> first, Option<TValue> second) => first.Equals(second);
    public static bool operator !=(Option<TValue> first, Option<TValue> second) => !(first == second);

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is null) return false;
        if (obj is Option<TValue> other) return Equals(other);
        if (obj is TValue value) return Equals(value);
        return false;
    }

    public bool Equals(TValue value)
    {
        if (HasNoValue) return value is null;
        return value?.Equals(_value) ?? false;
    }
    public bool Equals(Option<TValue> other)
    {
        if (HasNoValue && other.HasNoValue) return true;
        if (HasNoValue || other.HasNoValue) return false;
        return EqualityComparer<TValue>.Default.Equals(_value, other._value);
    }

    public override int GetHashCode() => HasValue ? _value!.GetHashCode() : 0;
    #endregion
}
