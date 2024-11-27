namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Apply a predicate on the option and only remain the filling if the current value matches the predicate
    /// </summary>
    /// <param name="predicate">The predicate to match against</param>
    public static Option<TValue> Check<TValue>(this Option<TValue> option, Func<TValue, bool> predicate)
        where TValue : class =>
        !option.TryGetValue(out var value) ? Option.None : predicate(value) ? option : Option.None;

    /// <summary>
    /// Apply a predicate on the option and only remain the filling if the current value matches the predicate
    /// </summary>
    /// <param name="predicate">The predicate to match against</param>
    public static async Task<Option<TValue>> CheckAsync<TValue>(this Option<TValue> option, Func<TValue, Task<bool>> predicate)
        where TValue : class =>
        !option.TryGetValue(out var value) ? Option.None : await predicate(value) ? option : Option.None;

    /// <summary>
    /// Apply a predicate on the option and only remain the filling if the current value matches the predicate
    /// </summary>
    /// <param name="predicate">The predicate to match against</param>
    public static async Task<Option<TValue>> Check<TValue>(this Task<Option<TValue>> optionTask, Func<TValue, bool> predicate)
        where TValue : class 
    {
        var option = await optionTask;
        return option.Check(predicate);
    }

    /// <summary>
    /// Apply a predicate on the option and only remain the filling if the current value matches the predicate
    /// </summary>
    /// <param name="predicate">The predicate to match against</param>
    public static async Task<Option<TValue>> CheckAsync<TValue>(this Task<Option<TValue>> optionTask, Func<TValue, Task<bool>> predicate)
        where TValue : class
    {
        var option = await optionTask;
        return await option.CheckAsync(predicate);
    }

    /// <summary>
    /// Apply a predicate on the option and only remain the filling if the current value matches the predicate
    /// </summary>
    /// <param name="predicate">The predicate to match against</param>
    public static ValueOption<TValue> Check<TValue>(this ValueOption<TValue> option, Func<TValue, bool> predicate)
        where TValue : struct =>
        !option.TryGetValue(out var value) ? Option.None : predicate(value) ? option : Option.None;

    /// <summary>
    /// Apply a predicate on the option and only remain the filling if the current value matches the predicate
    /// </summary>
    /// <param name="predicate">The predicate to match against</param>
    public static async Task<ValueOption<TValue>> CheckAsync<TValue>(this ValueOption<TValue> option, Func<TValue, Task<bool>> predicate)
        where TValue : struct =>
        !option.TryGetValue(out var value) ? Option.None : await predicate(value) ? option : Option.None;

    /// <summary>
    /// Apply a predicate on the option and only remain the filling if the current value matches the predicate
    /// </summary>
    /// <param name="predicate">The predicate to match against</param>
    public static async Task<ValueOption<TValue>> Check<TValue>(this Task<ValueOption<TValue>> optionTask, Func<TValue, bool> predicate)
        where TValue : struct
    {
        var option = await optionTask;
        return option.Check(predicate);
    }

    /// <summary>
    /// Apply a predicate on the option and only remain the filling if the current value matches the predicate
    /// </summary>
    /// <param name="predicate">The predicate to match against</param>
    public static async Task<ValueOption<TValue>> CheckAsync<TValue>(this Task<ValueOption<TValue>> optionTask, Func<TValue, Task<bool>> predicate)
        where TValue : struct
    {
        var option = await optionTask;
        return await option.CheckAsync(predicate);
    }
}
