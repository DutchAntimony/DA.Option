namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Bind the <see cref="Option"/>{<typeparamref name="TIn"/>} to an <see cref="Option"/>{<typeparamref name="TOut"/>}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="option">The option this method is applied to.</param>
    /// <param name="selector">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static Option<TOut> Bind<TIn, TOut>(in this Option<TIn> option, Func<TIn, Option<TOut>> selector) =>
        option.TryGetValue(out var value) ? selector(value) : Option.None;

    /// <summary>
    /// Bind the option of <typeparamref name="TIn"/> to an option of <typeparamref name="TOut"/>
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selectorTask">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<Option<TOut>> BindAsync<TIn, TOut>(this Option<TIn> option, Func<TIn, Task<Option<TOut>>> selectorTask) =>
        option.TryGetValue(out var value) ? await selectorTask(value) : Option.None;

    /// <summary>
    /// Bind the <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TIn"/>}} to an <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selector">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>A <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}} that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<Option<TOut>> BindAsync<TIn, TOut>(this Task<Option<TIn>> optionTask, Func<TIn, Option<TOut>> selector)
    {
        var option = await optionTask;
        return option.Bind(selector);
    }

    /// <summary>
    /// Bind the <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TIn"/>}} to an <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selectorTask">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<Option<TOut>> BindAsync<TIn, TOut>(this Task<Option<TIn>> optionTask, Func<TIn, Task<Option<TOut>>> selectorTask)
    {
        var option = await optionTask;
        return await option.BindAsync(selectorTask);
    }
}
