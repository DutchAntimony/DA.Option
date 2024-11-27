namespace DA.Options.Extensions;

public static partial class OptionExtensions
{
    /// <summary>
    /// Execute an action of the option if a value is present.
    /// </summary>
    /// <param name="option">This option that the action should be performed on.</param>
    /// <param name="action">The action to perform.</param>
    public static void Tap<TValue>(in this Option<TValue> option, Action<TValue> action)
        where TValue : class
    {
        if (option.TryGetValue(out var value))
        {
            action(value);
        }
    }

    /// <summary>
    /// Execute an action of the option if a value is present.
    /// </summary>
    /// <param name="option">This option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapAsync<TValue>(this Option<TValue> option, Func<TValue, Task> action)
        where TValue : class
    {
        if (option.TryGetValue(out var value))
        {
            await action(value);
        }
    }

    /// <summary>
    /// Execute an action of the task of a option if a value will be present.
    /// </summary>
    /// <param name="optionTask">This task that will return an option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task Tap<TValue>(this Task<Option<TValue>> optionTask, Action<TValue> action)
        where TValue : class
    {
        var option = await optionTask;
        option.Tap(action);
    }

    /// <summary>
    /// Execute an action of the maybe if a value is present.
    /// </summary>
    /// <param name="optionTask">This task that will return an option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapAsync<TValue>(this Task<Option<TValue>> optionTask, Func<TValue, Task> action)
        where TValue : class
    {
        var option = await optionTask;
        await option.TapAsync(action);
    }

    /// <summary>
    /// Execute an action of the option if a value is present.
    /// </summary>
    /// <param name="option">This option that the action should be performed on.</param>
    /// <param name="action">The action to perform.</param>
    public static void Tap<TValue>(in this ValueOption<TValue> option, Action<TValue> action)
        where TValue : struct
    {
        if (option.TryGetValue(out var value))
        {
            action(value);
        }
    }

    /// <summary>
    /// Execute an action of the option if a value is present.
    /// </summary>
    /// <param name="option">This option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapAsync<TValue>(this ValueOption<TValue> option, Func<TValue, Task> action)
        where TValue : struct
    {
        if (option.TryGetValue(out var value))
        {
            await action(value);
        }
    }

    /// <summary>
    /// Execute an action of the task of a option if a value will be present.
    /// </summary>
    /// <param name="optionTask">This task that will return an option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task Tap<TValue>(this Task<ValueOption<TValue>> optionTask, Action<TValue> action)
        where TValue : struct
    {
        var option = await optionTask;
        option.Tap(action);
    }

    /// <summary>
    /// Execute an action of the maybe if a value is present.
    /// </summary>
    /// <param name="optionTask">This task that will return an option on which the action should be applied.</param>
    /// <param name="action">The action to perform.</param>
    public static async Task TapAsync<TValue>(this Task<ValueOption<TValue>> optionTask, Func<TValue, Task> action)
        where TValue : struct
    {
        var option = await optionTask;
        await option.TapAsync(action);
    }
}
