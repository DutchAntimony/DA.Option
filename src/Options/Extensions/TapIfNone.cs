namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Execute an action of the option if a value is not present.
    /// </summary>
    /// <param name="option">This option that the action should be performed on.</param>
    /// <param name="action">The action to perform.</param>
    public static void TapIfNone<TValue>(in this Option<TValue> option, Action action)
        where TValue : class
    {
        if (!option.TryGetValue(out _))
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
        where TValue : class
    {
        if (!option.TryGetValue(out _))
        {
            await action();
        }
    }

    /// <summary>
    /// Execute an action of the task of a option if a value will not be present.
    /// </summary>
    /// <param name="optionTask">This task that will return an option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapIfNone<TValue>(this Task<Option<TValue>> optionTask, Action action)
        where TValue : class
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
        where TValue : class
    {
        var option = await optionTask;
        await option.TapIfNoneAsync(action);
    }

    /// <summary>
    /// Execute an action of the option if a value is not present.
    /// </summary>
    /// <param name="option">This option that the action should be performed on.</param>
    /// <param name="action">The action to perform.</param>
    public static void TapIfNone<TValue>(in this ValueOption<TValue> option, Action action)
        where TValue : struct
    {
        if (!option.TryGetValue(out _))
        {
            action();
        }
    }

    /// <summary>
    /// Execute an action of the option if a value is not present.
    /// </summary>
    /// <param name="option">This option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapIfNoneAsync<TValue>(this ValueOption<TValue> option, Func<Task> action)
        where TValue : struct
    {
        if (!option.TryGetValue(out _))
        {
            await action();
        }
    }

    /// <summary>
    /// Execute an action of the task of a option if a value will not be present.
    /// </summary>
    /// <param name="optionTask">This task that will return an option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapIfNone<TValue>(this Task<ValueOption<TValue>> optionTask, Action action)
        where TValue : struct
    {
        var option = await optionTask;
        option.TapIfNone(action);
    }

    /// <summary>
    /// Execute an action of the maybe if a value is not present.
    /// </summary>
    /// <param name="optionTask">This task that will return an option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapIfNoneAsync<TValue>(this Task<ValueOption<TValue>> optionTask, Func<Task> action)
        where TValue : struct
    {
        var option = await optionTask;
        await option.TapIfNoneAsync(action);
    }
}