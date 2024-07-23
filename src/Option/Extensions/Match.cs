namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Match the method to generate the <typeparamref name="TOut"/> depending on whether this option has a value or not.
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="option">this option to work on.</param>
    /// <param name="whenSome">Function to generate the <typeparamref name="TOut"/> when this option has a value.</param>
    /// <param name="whenNone">Function to generate the <typeparamref name="TOut"/> when this option has no value.</param>
    /// <returns>An instance of <typeparamref name="TOut"/> created depending on the status of the option.</returns>
    public static TOut Match<TIn, TOut>(this Option<TIn> option, Func<TIn, TOut> whenSome, Func<TOut> whenNone) =>
        option.TryGetValue(out var value) ? whenSome(value) : whenNone();

    /// <summary>
    /// Match the method to generate the <typeparamref name="TOut"/> depending on whether this option has a value or not.
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="option">The task that will result in the option to convert.</param>
    /// <param name="whenSome">Function to generate the <typeparamref name="TOut"/> when this option has a value.</param>
    /// <param name="whenNone">Function to generate the <typeparamref name="TOut"/> when this option has no value.</param>
    /// <returns>An Task of an instance of <typeparamref name="TOut"/> created depending on the status of the option.</returns>
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Option<TIn> option, Func<TIn, Task<TOut>> whenSome, Task<TOut> whenNone) =>
        option.TryGetValue(out var value) ? await whenSome(value) : await whenNone;

    /// <summary>
    /// Match the method to generate the <typeparamref name="TOut"/> depending on whether this option has a value or not.
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="whenSome">Function to generate the <typeparamref name="TOut"/> when this option has a value.</param>
    /// <param name="whenNone">Function to generate the <typeparamref name="TOut"/> when this option has no value.</param>
    /// <returns>An Task of an instance of <typeparamref name="TOut"/> created depending on the status of the option.</returns>
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<Option<TIn>> optionTask, Func<TIn, TOut> whenSome, Func<TOut> whenNone)
    {
        var option = await optionTask;
        return option.Match(whenSome, whenNone);
    }

    /// <summary>
    /// Match the method to generate the <typeparamref name="TOut"/> depending on whether this option has a value or not.
    /// </summary>
    /// <typeparam name="TIn">The type of the original optional value.</typeparam>
    /// <typeparam name="TOut">The type of the resulting optional value.</typeparam>
    /// <param name="optionTask">The task that will result in the option to convert.</param>
    /// <param name="whenSome">Function to generate the <typeparamref name="TOut"/> when this option has a value.</param>
    /// <param name="whenNone">Function to generate the <typeparamref name="TOut"/> when this option has no value.</param>
    /// <returns>An Task of an instance of <typeparamref name="TOut"/> created depending on the status of the option.</returns>
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<Option<TIn>> optionTask, Func<TIn, Task<TOut>> whenSome, Task<TOut> whenNone)
    {
        var option = await optionTask;
        return await option.MatchAsync(whenSome, whenNone);
    }
}
