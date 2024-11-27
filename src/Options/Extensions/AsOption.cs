namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Converts the <see cref="Task"/> of a class instance to a <see cref="Task"/> of a <see cref="Option{TValue}"/>.
    /// </summary>
    public static async Task<Option<TValue>> AsOption<TValue>(this Task<TValue?> task) where TValue : class 
    {
        var value = await task;
        return value;
    }

    /// <summary>
    /// Converts the <see cref="Task"/> of a <see cref="Nullable"/> struct to a <see cref="Task"/> of a <see cref="ValueOption{TValue}"/>.
    /// </summary>
    public static async Task<ValueOption<TValue>> AsOption<TValue>(this Task<TValue?> task) where TValue : struct
    {
        var value = await task;
        return value;
    }
}