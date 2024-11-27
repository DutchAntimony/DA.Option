namespace DA.Options;

/// <summary>
/// Static methods to make working with the Option{T} easier.
/// </summary>
public readonly struct Option
{
    /// <summary>
    /// Create a none option, a generic option with no value usable for any type argument.
    /// </summary>
    public static Option None => new();

    public static Option<TValue> From<TValue>(TValue value) where TValue : class => 
        Option<TValue>.From(value);
}
