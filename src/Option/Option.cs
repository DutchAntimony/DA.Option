namespace DA.Option;

/// <summary>
/// Static methods to make working with the Option{T} easier.
/// </summary>
public readonly struct Option
{
    /// <summary>
    /// Create an none option, a generic option with no value useable for any type argument.
    /// </summary>
    public static Option None => new();
    public static Option<TValue> From<TValue>(TValue value) => Option<TValue>.From(value);
}
