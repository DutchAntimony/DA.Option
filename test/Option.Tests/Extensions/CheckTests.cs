using DA.Option.Extensions;

namespace DA.Option.Tests.Extensions;

public class CheckTests : TestBase
{
    [Fact]
    public async Task WhereAndWhereAsync_Should_ReturnOriginalOption_WhenOptionHasValueAndPassesPredicate()
    {
        _option.Check(x => x > 2).ShouldBe(_option);
        (await _option.CheckAsync(x => Task.FromResult(x > 2))).ShouldBe(_option);
        (await _optionTask.CheckAsync(x => x > 2)).ShouldBe(_option);
        (await _optionTask.CheckAsync(x => Task.FromResult(x > 2))).ShouldBe(_option);
    }

    [Fact]
    public async Task WhereAndWhereAsync_Should_ReturnNoneOption_WhenOptionHasValueButDoesNotPassPredicate()
    {
        _option.Check(x => x < 2).ShouldBe(Option.None);
        (await _option.CheckAsync(x => Task.FromResult(x < 2))).ShouldBe(Option.None);
        (await _optionTask.CheckAsync(x => x < 2)).ShouldBe(Option.None);
        (await _optionTask.CheckAsync(x => Task.FromResult(x < 2))).ShouldBe(Option.None);
    }

    [Fact]
    public async Task WhereAndWhereAsync_Should_ReturnNoneOption_WhenOptionIsNone()
    {
        _none.Check(x => true).ShouldBe(Option.None);
        (await _none.CheckAsync(x => Task.FromResult(true))).ShouldBe(Option.None);
        (await _noneTask.CheckAsync(x => true)).ShouldBe(Option.None);
        (await _noneTask.CheckAsync(x => Task.FromResult(true))).ShouldBe(Option.None);
    }
}
