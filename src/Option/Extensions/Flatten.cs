namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Flattens nested <see cref="Option{TValue}"/>s into a single <see cref="Option{TValue}"/>
    /// </summary>
    /// <param name="option">this option the method is applied on.</param>
    /// <returns>The flattened <see cref="Option{TValue}"/></returns>
    public static Option<TValue> Flatten<TValue>(this Option<Option<TValue>> option) =>
        option.TryGetValue(out var value) ? value : Option.None;

    /// <summary>
    /// Flattens a task of nested <see cref="Option{TValue}"/>s into a single <see cref="Option{TValue}"/>
    /// </summary>
    /// <param name="optionTask">this option the method is applied on.</param>
    /// <returns>The flattened <see cref="Option{TValue}"/></returns>
    public static async Task<Option<TValue>> FlattenAsync<TValue>(this Task<Option<Option<TValue>>> optionTask)
    {
        var option = await optionTask;
        return option.Flatten();
    }
}
