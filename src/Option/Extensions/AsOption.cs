namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Converts the <see cref="Nullable"/> struct to a <see cref="Option{TValue}"/>.
    /// </summary>
    public static Option<TValue> AsOption<TValue>(this TValue? value) where TValue : struct => 
        value is null ? Option.None : Option.From(value.Value);

    /// <summary>
    /// Converts the class instance in a <see cref="Option{TValue}"/>.
    /// </summary>
    public static Option<TValue> AsOption<TValue>(this TValue? value) where TValue : class => 
        value is null ? Option.None : Option.From(value);

    /// <summary>
    /// Converts the <see cref="Task"/> of a <see cref="Nullable"/> struct to a <see cref="Task"/> of a <see cref="Option{TValue}"/>.
    /// </summary>
    public static async Task<Option<TValue>> AsOptionAsync<TValue>(this Task<TValue?> task) where TValue : struct 
    {
        var value = await task;
        return value.AsOption();
    }

    /// <summary>
    /// Converts the <see cref="Task"/> of a class instance to a <see cref="Task"/> of a <see cref="Option{TValue}"/>.
    /// </summary>
    public static async Task<Option<TValue>> AsOptionAsync<TValue>(this Task<TValue?> task) where TValue : class
    {
        var value = await task;
        return value.AsOption();
    }
}