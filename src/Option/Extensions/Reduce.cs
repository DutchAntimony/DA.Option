namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElse">The value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static TValue Reduce<TValue>(this Option<TValue> option, TValue orElse) => 
        option.TryGetValue(out var value) ? value : orElse;

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseFunction">The function to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static TValue Reduce<TValue>(this Option<TValue> option, Func<TValue> orElseFunction) =>
        option.TryGetValue(out var value) ? value : orElseFunction();

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseTask">The task to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> ReduceAsync<TValue>(this Option<TValue> option, Task<TValue> orElseTask) =>
        option.TryGetValue(out var value) ? value : await orElseTask;

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElse">The value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> ReduceAsync<TValue>(this Task<Option<TValue>> optionTask, TValue orElse)
    {
        var option = await optionTask;
        return option.Reduce(orElse);
    }

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseFunction">The function to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> ReduceAsync<TValue>(this Task<Option<TValue>> optionTask, Func<TValue> orElseFunction)
    {
        var option = await optionTask;
        return option.Reduce(orElseFunction);
    }

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseTask">The task to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> ReduceAsync<TValue>(this Task<Option<TValue>> optionTask, Task<TValue> orElseTask)
    {
        var option = await optionTask;
        return await option.ReduceAsync(orElseTask);
    }
}