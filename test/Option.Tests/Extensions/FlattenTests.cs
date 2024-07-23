using DA.Options.Extensions;

namespace DA.Options.Tests.Extensions;

public class FlattenTests : TestBase
{
    [Fact]
    public void Flatten_Should_FlattenAnyOptionOfOptionOfT()
    {
        var input = Option.From(_option);
        var result = input.Flatten();
        result.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(3);
    }

    [Fact]
    public void Flatten_Should_FlattenAnyNoneOption()
    {
        Option<Option<string>> input = Option.None;
        var result = input.Flatten();
        result.TryGetValue(out var _).ShouldBeFalse();
    }

    [Fact]
    public async Task FlattenAsync_Should_FlattenAnyTaskOfOptionOfOptionOfT()
    {
        var input = Task.FromResult(Option.From(_option));
        var result = await input.FlattenAsync();
        result.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(3);
    }
}