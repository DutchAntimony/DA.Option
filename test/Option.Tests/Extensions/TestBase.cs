namespace DA.Option.Tests.Extensions;

public abstract class TestBase
{
    protected readonly Option<int> _option = Option.From(3);
    protected readonly Option<int> _none = Option.None;
    protected readonly Task<Option<int>> _optionTask = Task.FromResult(Option.From(3));
    protected readonly Task<Option<int>> _noneTask = Task.FromResult(Option<int>.None());
}