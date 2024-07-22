namespace DA.Option.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Execute an action of the option if a value is not present.
    /// </summary>
    /// <param name="option">This option that the action should be performed on.</param>
    /// <param name="action">The action to perform.</param>
    public static void TapIfNone<TValue>(in this Option<TValue> option, Action action)
    {
        if (!option.TryGetValue(out var _))
        {
            action();
        }
    }

    /// <summary>
    /// Execute an action of the option if a value is not present.
    /// </summary>
    /// <param name="option">This option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapIfNoneAsync<TValue>(this Option<TValue> option, Func<Task> action)
    {
        if (!option.TryGetValue(out var _))
        {
            await action();
        }
    }

    /// <summary>
    /// Execute an action of the task of a option if a value will not be present.
    /// </summary>
    /// <param name="optionTask">This task that will return an option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapIfNoneAsync<TValue>(this Task<Option<TValue>> optionTask, Action action)
    {
        var option = await optionTask;
        option.TapIfNone(action);
    }

    /// <summary>
    /// Execute an action of the maybe if a value is not present.
    /// </summary>
    /// <param name="optionTask">This task that will return an option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapIfNoneAsync<TValue>(this Task<Option<TValue>> optionTask, Func<Task> action)
    {
        var option = await optionTask;
        await option.TapIfNoneAsync(action);
    }
}