using DA.Options.Extensions;

namespace DA.Options.Tests.Extensions;

public class BindTests : TestBase
{
    private readonly Func<int, Option<double>> _func = (int x) => Option.From(x * 1.5);
    private readonly Func<int, Task<Option<double>>> _taskfunc = (int x) => Task.FromResult(Option.From(x * 1.5));

    [Fact]
    public void Bind_Should_ReturnOptionWithCorrectValue_WhenInputIsSome()
    {
        var result = _option.Bind(_func);
        result.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(4.5);
    }

    [Fact]
    public void Bind_Should_ReturnNoneOption_WhenInputIsNone()
    {
        var result = _none.Bind(_func);
        result.TryGetValue(out var _).ShouldBeFalse();
    }

    [Fact]
    public async Task BindAsync_Should_ReturnOptionWithCorrectValue_WhenInputIsSome()
    {
        var result = await _option.BindAsync(_taskfunc);
        result.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(4.5);
    }

    [Fact]
    public async Task BindAsync_Should_ReturnNoneOption_WhenInputIsNone()
    {
        var result = await _none.BindAsync(_taskfunc);
        result.TryGetValue(out var _).ShouldBeFalse();
    }

    [Fact]
    public async Task BindAsync_Should_ReturnOptionWithCorrectValue_WhenInputIsSomeTask()
    {
        var result = await _optionTask.BindAsync(_func);
        result.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(4.5);
    }

    [Fact]
    public async Task BindAsync_Should_ReturnNoneOption_WhenInputIsNoneTask()
    {
        var result = await _noneTask.BindAsync(_func);
        result.TryGetValue(out var _).ShouldBeFalse();
    }

    [Fact]
    public async Task BindAsync_Should_ReturnOptionWithCorrectValue_WhenInputIsSomeTaskFromFunc()
    {
        var result = await _optionTask.BindAsync(_taskfunc);
        result.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(4.5);
    }

    [Fact]
    public async Task BindAsync_Should_ReturnNoneOption_WhenInputIsNoneTaskFromFunc()
    {
        var result = await _noneTask.BindAsync(_taskfunc);
        result.TryGetValue(out var _).ShouldBeFalse();
    }
}