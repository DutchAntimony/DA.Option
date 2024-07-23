using DA.Options.Extensions;

namespace DA.Options.Tests.Extensions;

public class TapIfNoneTests : TestBase
{
    private int _checkCounter = 0;

    [Fact]
    public void TapIfNone_Should_NotExecuteFunction_WhenHasValue()
    {
        _checkCounter = 0;
        _option.TapIfNone(() => _checkCounter += 3);
        _checkCounter.ShouldBe(0);
    }

    [Fact]
    public void TapIfNone_Should_ExecuteFunction_WhenHasNoValue()
    {
        _checkCounter = 0;
        _none.TapIfNone(() => _checkCounter += 3);
        _checkCounter.ShouldBe(3);
    }

    [Fact]
    public async Task TapIfNoneAsync_Should_NotExecuteTask_WhenHasValue()
    {
        _checkCounter = 0;
        await _option.TapIfNoneAsync(() => Task.FromResult(_checkCounter += 3));
        _checkCounter.ShouldBe(0);
    }

    [Fact]
    public async Task TapIfNoneAsync_Should_ExecuteTask_WhenHasNoValue()
    {
        _checkCounter = 0;
        await _none.TapIfNoneAsync(() => Task.FromResult(_checkCounter += 3));
        _checkCounter.ShouldBe(3);
    }

    [Fact]
    public async Task TapIfNoneAsync_Should_NotExecuteFunction_WhenTaskHasValue()
    {
        _checkCounter = 0;
        await _optionTask.TapIfNoneAsync(() => _checkCounter += 3);
        _checkCounter.ShouldBe(0);
    }

    [Fact]
    public async Task TapAsync_Should_ExecuteFunction_WhenTaskHasNoValue()
    {
        _checkCounter = 0;
        await _noneTask.TapIfNoneAsync(() => _checkCounter += 3);
        _checkCounter.ShouldBe(3);
    }

    [Fact]
    public async Task TapIfNoneAsync_Should_NotExecuteTask_WhenTaskHasValue()
    {
        _checkCounter = 0;
        await _optionTask.TapIfNoneAsync(() => Task.FromResult(_checkCounter += 3));
        _checkCounter.ShouldBe(0);
    }

    [Fact]
    public async Task TapIfNoneAsync_Should_ExecuteTask_WhenTaskHasNoValue()
    {
        _checkCounter = 0;
        await _noneTask.TapIfNoneAsync(() =>Task.FromResult(_checkCounter += 3));
        _checkCounter.ShouldBe(3);
    }
}