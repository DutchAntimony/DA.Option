namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElse">The value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static TValue Reduce<TValue>(this Option<TValue> option, TValue orElse)
        where TValue : class => 
        option.TryGetValue(out var value) ? value : orElse;

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseFunction">The function to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static TValue Reduce<TValue>(this Option<TValue> option, Func<TValue> orElseFunction)
        where TValue : class =>
        option.TryGetValue(out var value) ? value : orElseFunction();

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseTask">The task to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> ReduceAsync<TValue>(this Option<TValue> option, Func<Task<TValue>> orElseTask)
        where TValue : class =>
        option.TryGetValue(out var value) ? value : await orElseTask();

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElse">The value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> Reduce<TValue>(this Task<Option<TValue>> optionTask, TValue orElse)
        where TValue : class
    {
        var option = await optionTask;
        return option.Reduce(orElse);
    }
    
    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseFunc">Function to calculate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> Reduce<TValue>(this Task<Option<TValue>> optionTask, Func<TValue> orElseFunc)
        where TValue : class
    {
        var option = await optionTask;
        return option.Reduce(orElseFunc);
    }

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseFunction">The function to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> ReduceAsync<TValue>(this Task<Option<TValue>> optionTask, Func<TValue> orElseFunction)
        where TValue : class
    {
        var option = await optionTask;
        return option.Reduce(orElseFunction);
    }

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseTask">The task to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> ReduceAsync<TValue>(this Task<Option<TValue>> optionTask, Func<Task<TValue>> orElseTask)
        where TValue : class
    {
        var option = await optionTask;
        return await option.ReduceAsync(orElseTask);
    }

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElse">The value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static TValue Reduce<TValue>(this ValueOption<TValue> option, TValue orElse)
        where TValue : struct =>
        option.TryGetValue(out var value) ? value : orElse;

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseFunction">The function to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static TValue Reduce<TValue>(this ValueOption<TValue> option, Func<TValue> orElseFunction)
        where TValue : struct =>
        option.TryGetValue(out var value) ? value : orElseFunction();

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseTask">The task to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> ReduceAsync<TValue>(this ValueOption<TValue> option, Func<Task<TValue>> orElseTask)
        where TValue : struct =>
        option.TryGetValue(out var value) ? value : await orElseTask();

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElse">The value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> Reduce<TValue>(this Task<ValueOption<TValue>> optionTask, TValue orElse)
        where TValue : struct
    {
        var option = await optionTask;
        return option.Reduce(orElse);
    }

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseFunc">The function to get the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> Reduce<TValue>(this Task<ValueOption<TValue>> optionTask, Func<TValue> orElseFunc)
        where TValue : struct
    {
        var option = await optionTask;
        return option.Reduce(orElseFunc);
    }
    
    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseFunction">The function to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> ReduceAsync<TValue>(this Task<ValueOption<TValue>> optionTask, Func<TValue> orElseFunction)
        where TValue : struct
    {
        var option = await optionTask;
        return option.Reduce(orElseFunction);
    }

    /// <summary>
    /// Reduce this to the inner <typeparamref name="TValue"/> be either taking the value or using the provided value.
    /// </summary>
    /// <param name="orElseTask">The task to generate the value to use if this is empty.</param>
    /// <returns>The value if provided, or the alternative if empty.</returns>
    public static async Task<TValue> ReduceAsync<TValue>(this Task<ValueOption<TValue>> optionTask, Func<Task<TValue>> orElseTask)
        where TValue : struct
    {
        var option = await optionTask;
        return await option.ReduceAsync(orElseTask);
    }
}