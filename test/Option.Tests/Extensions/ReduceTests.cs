using DA.Option.Extensions;

namespace DA.Option.Tests.Extensions;

public class ReduceTests : TestBase
{
    [Fact]
    public async Task Reduce_Should_KeepValueUnchanged_IfValueIsPresent()
    {
        _option.Reduce(0).ShouldBe(3);
        _option.Reduce(() => 0).ShouldBe(3);
        (await _option.ReduceAsync(Task.FromResult(0))).ShouldBe(3);
    }

    [Fact]
    public async Task Reduce_Should_TakeOrElseValue_IfValueIsNotPresent()
    {
        _none.Reduce(0).ShouldBe(0);
        _none.Reduce(() => 0).ShouldBe(0);
        (await _none.ReduceAsync(Task.FromResult(0))).ShouldBe(0);
    }

    [Fact]
    public async Task ReduceAsync_Should_KeepValueUnchanged_IfValueIsPresent()
    {
        (await _optionTask.ReduceAsync(0)).ShouldBe(3);
        (await _optionTask.ReduceAsync(() => 0)).ShouldBe(3);
        (await _optionTask.ReduceAsync(Task.FromResult(0))).ShouldBe(3);
    }

    [Fact]
    public async Task ReduceAsync_Should_TakeOrElseValue_IfValueIsNotPresent()
    {
        (await _noneTask.ReduceAsync(0)).ShouldBe(0);
        (await _noneTask.ReduceAsync(() => 0)).ShouldBe(0);
        (await _noneTask.ReduceAsync(Task.FromResult(0))).ShouldBe(0);
    }
}