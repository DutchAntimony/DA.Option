namespace DA.Options;

/// <summary>
/// Static methods to make working with the ValueOption{T} easier.
/// </summary>
public readonly struct ValueOption
{
    /// <summary>
    /// Create an none option, a generic option with no value usable for any type argument.
    /// </summary>
    public static Option None => new();

    public static ValueOption<TValue> From<TValue>(TValue value) where TValue : struct =>
        ValueOption<TValue>.From(value);
}