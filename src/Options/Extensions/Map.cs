namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    #region Map Option to Option
    /// <summary>
    /// Map the option of <typeparamref name="TIn"/> to an option of <typeparamref name="TOut"/>
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="option">The option this method is applied to.</param>
    /// <param name="selector">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static Option<TOut> Map<TIn, TOut>(in this Option<TIn> option, Func<TIn, TOut> selector)
        where TIn : class
        where TOut : class =>
        option.TryGetValue(out var value) ? Option.From(selector(value)) : Option.None;

    /// <summary>
    /// Map the option of <typeparamref name="TIn"/> to an option of <typeparamref name="TOut"/>
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selectorTask">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<Option<TOut>> MapAsync<TIn, TOut>(this Option<TIn> option, Func<TIn, Task<TOut>> selectorTask)
        where TIn : class
        where TOut : class =>
        option.TryGetValue(out var value) ? Option.From(await selectorTask(value)) : Option.None;

    /// <summary>
    /// Map the <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TIn"/>}} to an <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selector">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>A <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}} that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<Option<TOut>> Map<TIn, TOut>(this Task<Option<TIn>> optionTask, Func<TIn, TOut> selector)
        where TIn : class
        where TOut : class
    {
        var option = await optionTask;
        return option.Map(selector);
    }

    /// <summary>
    /// Map the <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TIn"/>}} to an <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selectorTask">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<Option<TOut>> MapAsync<TIn, TOut>(this Task<Option<TIn>> optionTask, Func<TIn, Task<TOut>> selectorTask)
        where TIn : class
        where TOut : class
    {
        var option = await optionTask;
        return await option.MapAsync(selectorTask);
    }
    #endregion

    #region Map ValueOption to Option
    /// <summary>
    /// Map the option of <typeparamref name="TIn"/> to an option of <typeparamref name="TOut"/>
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="option">The option this method is applied to.</param>
    /// <param name="selector">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static Option<TOut> Map<TIn, TOut>(in this ValueOption<TIn> option, Func<TIn, TOut> selector)
        where TIn : struct
        where TOut : class =>
        option.TryGetValue(out var value) ? Option.From(selector(value)) : Option.None;

    /// <summary>
    /// Map the option of <typeparamref name="TIn"/> to an option of <typeparamref name="TOut"/>
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selectorTask">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<Option<TOut>> MapAsync<TIn, TOut>(this ValueOption<TIn> option, Func<TIn, Task<TOut>> selectorTask)
        where TIn : struct
        where TOut : class =>
        option.TryGetValue(out var value) ? Option.From(await selectorTask(value)) : Option.None;

    /// <summary>
    /// Map the <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TIn"/>}} to an <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selector">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>A <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}} that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<Option<TOut>> Map<TIn, TOut>(this Task<ValueOption<TIn>> optionTask, Func<TIn, TOut> selector)
        where TIn : struct
        where TOut : class
    {
        var option = await optionTask;
        return option.Map(selector);
    }

    /// <summary>
    /// Map the <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TIn"/>}} to an <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selectorTask">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<Option<TOut>> MapAsync<TIn, TOut>(this Task<ValueOption<TIn>> optionTask, Func<TIn, Task<TOut>> selectorTask)
        where TIn : struct
        where TOut : class
    {
        var option = await optionTask;
        return await option.MapAsync(selectorTask);
    }
    #endregion

    #region Map Option to ValueOption
    /// <summary>
    /// Map the option of <typeparamref name="TIn"/> to an option of <typeparamref name="TOut"/>
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="option">The option this method is applied to.</param>
    /// <param name="selector">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static ValueOption<TOut> MapValue<TIn, TOut>(in this Option<TIn> option, Func<TIn, TOut> selector)
        where TIn : class
        where TOut : struct =>
        option.TryGetValue(out var value) ? ValueOption.From(selector(value)) : ValueOption.None;

    /// <summary>
    /// Map the option of <typeparamref name="TIn"/> to an option of <typeparamref name="TOut"/>
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selectorTask">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<ValueOption<TOut>> MapValueAsync<TIn, TOut>(this Option<TIn> option, Func<TIn, Task<TOut>> selectorTask)
        where TIn : class
        where TOut : struct =>
        option.TryGetValue(out var value) ? ValueOption.From(await selectorTask(value)) : ValueOption.None;

    /// <summary>
    /// Map the <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TIn"/>}} to an <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selector">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>A <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}} that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<ValueOption<TOut>> MapValue<TIn, TOut>(this Task<Option<TIn>> optionTask, Func<TIn, TOut> selector)
        where TIn : class
        where TOut : struct
    {
        var option = await optionTask;
        return option.MapValue(selector);
    }

    /// <summary>
    /// Map the <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TIn"/>}} to an <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selectorTask">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<ValueOption<TOut>> MapValueAsync<TIn, TOut>(this Task<Option<TIn>> optionTask, Func<TIn, Task<TOut>> selectorTask)
        where TIn : class
        where TOut : struct
    {
        var option = await optionTask;
        return await option.MapValueAsync(selectorTask);
    }
    #endregion

    #region Map ValueOption to ValueOption
    /// <summary>
    /// Map the option of <typeparamref name="TIn"/> to an option of <typeparamref name="TOut"/>
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="option">The option this method is applied to.</param>
    /// <param name="selector">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static ValueOption<TOut> MapValue<TIn, TOut>(in this ValueOption<TIn> option, Func<TIn, TOut> selector)
        where TIn : struct
        where TOut : struct =>
        option.TryGetValue(out var value) ? ValueOption.From(selector(value)) : Option.None;

    /// <summary>
    /// Map the option of <typeparamref name="TIn"/> to an option of <typeparamref name="TOut"/>
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selectorTask">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<ValueOption<TOut>> MapValueAsync<TIn, TOut>(this ValueOption<TIn> option, Func<TIn, Task<TOut>> selectorTask)
        where TIn : struct
        where TOut : struct =>
        option.TryGetValue(out var value) ? ValueOption.From(await selectorTask(value)) : Option.None;

    /// <summary>
    /// Map the <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TIn"/>}} to an <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selector">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>A <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}} that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<ValueOption<TOut>> MapValue<TIn, TOut>(this Task<ValueOption<TIn>> optionTask, Func<TIn, TOut> selector)
        where TIn : struct
        where TOut : struct
    {
        var option = await optionTask;
        return option.MapValue(selector);
    }

    /// <summary>
    /// Map the <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TIn"/>}} to an <see cref="Task"/>{<see cref="Option"/>{<typeparamref name="TOut"/>}}
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="selectorTask">The function to convert from <typeparamref name="TIn"/> to <typeparamref name="TOut"/></param>
    /// <returns>An option of type <typeparamref name="TOut"/> that has a value depending on the original value and the result of the selector.</returns>
    public static async Task<ValueOption<TOut>> MapValueAsync<TIn, TOut>(this Task<ValueOption<TIn>> optionTask, Func<TIn, Task<TOut>> selectorTask)
        where TIn : struct
        where TOut : struct
    {
        var option = await optionTask;
        return await option.MapValueAsync(selectorTask);
    }
    #endregion
}