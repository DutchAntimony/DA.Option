using DA.Option.Extensions;

namespace DA.Option.Tests.Extensions;

public class TapTests : TestBase
{
    private int _checkCounter = 0;

    [Fact]
    public void Tap_Should_ExecuteFunction_WhenHasValue()
    {
        _checkCounter = 0;
        _option.Tap(x => _checkCounter += x);
        _checkCounter.ShouldBe(3);
    }

    [Fact]
    public void Tap_Should_NotExecuteFunction_WhenHasNoValue()
    {
        _checkCounter = 0;
        _none.Tap(x => _checkCounter += 3);
        _checkCounter.ShouldBe(0);
    }

    [Fact]
    public async Task TapAsync_Should_ExecuteTask_WhenHasValue()
    {
        _checkCounter = 0;
        await _option.TapAsync(x => Task.FromResult(_checkCounter += x));
        _checkCounter.ShouldBe(3);
    }

    [Fact]
    public async Task TapAsync_Should_NotExecuteTask_WhenHasNoValue()
    {
        _checkCounter = 0;
        await _none.TapAsync(x => Task.FromResult(_checkCounter += 3));
        _checkCounter.ShouldBe(0);
    }

    [Fact]
    public async Task TapAsync_Should_ExecuteFunction_WhenTaskHasValue()
    {
        _checkCounter = 0;
        await _optionTask.TapAsync(x => _checkCounter += x);
        _checkCounter.ShouldBe(3);
    }

    [Fact]
    public async Task TapAsync_Should_NotExecuteFunction_WhenTaskHasNoValue()
    {
        _checkCounter = 0;
        await _noneTask.TapAsync(x => _checkCounter += 3);
        _checkCounter.ShouldBe(0);
    }

    [Fact]
    public async Task TapAsync_Should_ExecuteTask_WhenTaskHasValue()
    {
        _checkCounter = 0;
        await _optionTask.TapAsync(x => Task.FromResult(_checkCounter += x));
        _checkCounter.ShouldBe(3);
    }

    [Fact]
    public async Task TapAsync_Should_NotExecuteTask_WhenTaskHasNoValue()
    {
        _checkCounter = 0;
        await _noneTask.TapAsync(x => Task.FromResult(_checkCounter += 3));
        _checkCounter.ShouldBe(0);
    }
}
