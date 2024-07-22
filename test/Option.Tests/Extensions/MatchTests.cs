using DA.Option.Extensions;

namespace DA.Option.Tests.Extensions;

public class MatchTests : TestBase
{
    private readonly Func<int, double> _someFunc = x => x * 1.5;
    private readonly Func<double> _noneFunc = () => 0;

    private readonly Func<int, Task<double>> _sometaskFunc = x => Task.FromResult(x * 1.5);
    private readonly Task<double> _nonetaskFunc = Task.FromResult(0d);

    [Fact]
    public void Match_Should_returnSomeFuncResult_IfHasValue()
    {
        var result = _option.Match(_someFunc, _noneFunc);
        result.ShouldBeOfType<double>();
        result.ShouldBe(4.5);
    }

    [Fact]
    public void Match_Should_returnNoneFuncResult_IfHasNoValue()
    {
        var result = _none.Match(_someFunc, _noneFunc);
        result.ShouldBeOfType<double>();
        result.ShouldBe(0d);
    }

    [Fact]
    public async Task MatchAsync_Should_returnSomeFuncResult_IfHasValue()
    {
        var result = await _option.MatchAsync(_sometaskFunc, _nonetaskFunc);
        result.ShouldBeOfType<double>();
        result.ShouldBe(4.5);
    }

    [Fact]
    public async Task MatchAsync_Should_returnNoneFuncResult_IfHasNoValue()
    {
        var result = await _none.MatchAsync(_sometaskFunc, _nonetaskFunc);
        result.ShouldBeOfType<double>();
        result.ShouldBe(0d);
    }

    [Fact]
    public async Task MatchAsync_Should_returnSomeFuncResult_IfTaskHasValue()
    {
        var result = await _optionTask.MatchAsync(_someFunc, _noneFunc);
        result.ShouldBeOfType<double>();
        result.ShouldBe(4.5);
    }

    [Fact]
    public async Task MatchAsync_Should_returnNoneFuncResult_IfTaskHasNoValue()
    {
        var result = await _noneTask.MatchAsync(_someFunc, _noneFunc);
        result.ShouldBeOfType<double>();
        result.ShouldBe(0d);
    }

    [Fact]
    public async Task MatchAsync_Should_returnSomeFuncResult_IfTaskHasValueOnTaskArguments()
    {
        var result = await _optionTask.MatchAsync(_sometaskFunc, _nonetaskFunc);
        result.ShouldBeOfType<double>();
        result.ShouldBe(4.5);
    }

    [Fact]
    public async Task MatchAsync_Should_returnNoneFuncResult_IfTaskHasNoValueOnTaskArguments()
    {
        var result = await _noneTask.MatchAsync(_sometaskFunc, _nonetaskFunc);
        result.ShouldBeOfType<double>();
        result.ShouldBe(0d);
    }
}