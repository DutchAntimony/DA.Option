using DA.Options.Extensions;

namespace DA.Options.Tests.Extensions;

public class MapTests : TestBase
{
    private readonly Func<int, double> _func = (int x) => x * 1.5;
    private readonly Func<int, Task<double>> _taskfunc = (int x) => Task.FromResult(x * 1.5);

    [Fact]
    public void Map_Should_ReturnOptionWithCorrectValue_WhenInputIsSome()
    {
        var result = _option.Map(_func);
        result.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(4.5);
    } 

    [Fact]
    public void Map_Should_ReturnNoneOption_WhenInputIsNone()
    {
        var result = _none.Map(_func);
        result.TryGetValue(out var _).ShouldBeFalse();
    }

    [Fact]
    public async Task MapAsync_Should_ReturnOptionWithCorrectValue_WhenInputIsSome()
    {
        var result = await _option.MapAsync(_taskfunc);
        result.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(4.5);
    }

    [Fact]
    public async Task MapAsync_Should_ReturnNoneOption_WhenInputIsNone()
    {
        var result = await _none.MapAsync(_taskfunc);
        result.TryGetValue(out var _).ShouldBeFalse();
    }

    [Fact]
    public async Task MapAsync_Should_ReturnOptionWithCorrectValue_WhenInputIsSomeTask()
    {
        var result = await _optionTask.MapAsync(_func);
        result.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(4.5);
    }

    [Fact]
    public async Task MapAsync_Should_ReturnNoneOption_WhenInputIsNoneTask()
    {
        var result = await _noneTask.MapAsync(_func);
        result.TryGetValue(out var _).ShouldBeFalse();
    }

    [Fact]
    public async Task MapAsync_Should_ReturnOptionWithCorrectValue_WhenInputIsSomeTaskFromFunc()
    {
        var result = await _optionTask.MapAsync(_taskfunc);
        result.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(4.5);
    }

    [Fact]
    public async Task MapAsync_Should_ReturnNoneOption_WhenInputIsNoneTaskFromFunc()
    {
        var result = await _noneTask.MapAsync(_taskfunc);
        result.TryGetValue(out var _).ShouldBeFalse();
    }
}