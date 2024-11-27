namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Convert the <see cref="Option{TValue}"/> back to a <see cref="Nullable"/> object.
    /// </summary>
    /// <remarks>This is mostly useful for ORM's like EF Core that must work with nullable types </remarks>
    /// <returns>Returns the <see cref="Nullable{TValue}"/> equivalent to the <see cref="Option{TValue}"/>.</returns>
    public static TValue? AsNullable<TValue>(this Option<TValue> option) where TValue : class =>
        option.TryGetValue(out var value) ? value : null;

    /// <summary>
    /// Convert a Task of an option to a task of a nullable object.
    /// </summary>
    public static async Task<TValue?> AsNullable<TValue>(this Task<Option<TValue>> optionTask)
        where TValue : class
    {
        var option = await optionTask;
        return option.TryGetValue(out var value) ? value : null;
    }

    /// <summary>
    /// Convert the <see cref="Option{TValue}"/> back to a <see cref="Nullable"/> object.
    /// </summary>
    /// <remarks>This is mostly useful for ORM's like EF Core that must work with nullable types </remarks>
    /// <returns>Returns the <see cref="Nullable{TValue}"/> equivalent to the <see cref="Option{TValue}"/>.</returns>
    public static TValue? AsNullable<TValue>(this ValueOption<TValue> option) where TValue : struct =>
        option.TryGetValue(out var value) ? value : null;

    /// <summary>
    /// Convert a Task of an option to a task of a nullable object.
    /// </summary>
    public static async Task<TValue?> AsNullable<TValue>(this Task<ValueOption<TValue>> optionTask)
        where TValue : struct
    {
        var option = await optionTask;
        return option.TryGetValue(out var value) ? value : null;
    }
}
