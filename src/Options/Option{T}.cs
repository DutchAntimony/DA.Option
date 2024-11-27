using System.Diagnostics.CodeAnalysis;

namespace DA.Options;

/// <summary>
/// An Option is a monad around a <typeparamref name="TValue"/>.
/// The option can either be Some(), e.g. have a value, or None(), e.g. does not have a value.
/// </summary>
/// <typeparam name="TValue">The class type of the monad.</typeparam>
public readonly struct Option<TValue> : IEquatable<Option<TValue>>, IEquatable<object>
    where TValue : class
{
    /// <summary>
    /// The value of the option, can be null if the option is none.
    /// </summary>
    private readonly TValue? _value;

    /// <summary>
    /// Boolean indicating whether the option has a value.
    /// </summary>
    public bool HasValue { get; }

    /// <summary>
    /// Option can only be constructed privately by providing a value or None.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="hasValue"></param>
    private Option(TValue? value, bool hasValue) => (_value, HasValue) = (value, hasValue);

    /// <summary>
    /// Initialize the option with a value
    /// </summary>
    /// <param name="value">The value of the option.</param>
    /// <exception cref="ArgumentNullException">Thrown if the provided value is null.</exception>
    public static Option<TValue> Some(TValue value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        return new Option<TValue>(value, true);
    }

    /// <summary>
    /// Initialize the option without a value
    /// </summary>
    public static Option<TValue> None() => new(null, false);

    /// <summary>
    /// Explicitly create an option from a nullable value.
    /// </summary>
    /// <param name="value">The nullable value to convert to an option.</param>
    /// <remarks>This should usually not be necessary, implicit conversion also does this.</remarks>
    /// <returns>Option.None if the value is null, Option.Some(value) if not null.</returns>
    public static Option<TValue> From(TValue? value) => value is null ? None() : Some(value);

    /// <summary>
    /// Implicitly convert any class option to a none option of <typeparamref name="TValue"/>
    /// Works because the only non-generic option that can be constructed is none option.
    /// </summary>
    public static implicit operator Option<TValue>(Option _) => None();

    /// <summary>
    /// Implicitly convert any struct option to a none option of <typeparamref name="TValue"/>
    /// Works because the only non-generic option that can be constructed is none option.
    /// </summary>
    public static implicit operator Option<TValue>(ValueOption _) => None();
    
    /// <summary>
    /// Implicitly convert a TValue? to a Option{TValue}
    /// </summary>
    public static implicit operator Option<TValue>(TValue? value) => From(value);

    /// <summary>
    /// Try to get the underlying value of the option.
    /// </summary>
    /// <param name="value">out parameter giving the value.</param>
    /// <returns>Boolean indicating if the option has a set value.</returns>
    public bool TryGetValue([NotNullWhen(true)] out TValue? value)
    {
        value = _value;
        return HasValue;
    }

    /// <summary>
    /// Override the toString method to return the objects ToString if the Option has a value, and an empty string if not.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => TryGetValue(out var value) ? value.ToString() ?? typeof(TValue).Name : string.Empty;

    #region IEquatable
    public static bool operator ==(Option<TValue> option, TValue value)
    {
        return option.TryGetValue(out var myValue) && myValue.Equals(value);
    }
    public static bool operator !=(Option<TValue> option, TValue value) => !(option == value);
    public static bool operator ==(Option<TValue> option, object other) => option.Equals(other);
    public static bool operator !=(Option<TValue> option, object other) => !(option == other);
    public static bool operator ==(Option<TValue> first, Option<TValue> second) => first.Equals(second);
    public static bool operator !=(Option<TValue> first, Option<TValue> second) => !(first == second);

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj switch
        {
            null => false,
            Option<TValue> other => Equals(other),
            TValue value => Equals(value),
            _ => false
        };
    }

    private bool Equals(TValue value)
    {
        return HasValue && value.Equals(_value);
    }
    public bool Equals(Option<TValue> other)
    {
        if (!HasValue && !other.HasValue) return true;  // both have no value => are equal.
        if (!HasValue || !other.HasValue) return false; // one has value, other not => not equal.
        return EqualityComparer<TValue>.Default.Equals(_value, other._value);
    }

    public override int GetHashCode() => TryGetValue(out var value) ? value.GetHashCode() : 0;
    #endregion
}
