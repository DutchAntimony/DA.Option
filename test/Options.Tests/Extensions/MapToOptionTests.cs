using DA.Options;
using DA.Options.Extensions;
using Shouldly;

namespace Options.Tests.Extensions;

public class MapToOptionTests : OptionTestBase
{
    private const string ExpectedFromOption = "abcdef";
    private const string ExpectedFromValueOption = "42def";
    private static string Selector(string original) => original + "def";
    private static string Selector(int original) => original + "def";
    private static Task<string> SelectorTask(string original) => Task.FromResult(Selector(original));
    private static Task<string> SelectorTask(int original) => Task.FromResult(Selector(original));
    
    [Fact]
    public void Map_Should_ReturnNone_IfOptionIsNone()
    {
        NoneOption.Map(Selector).ShouldBe(Option.None);
    }

    [Fact]
    public void Map_Should_ReturnSome_IfOptionIsSome()
    {
        SomeOption.Map(Selector).ShouldBe(ExpectedFromOption);
    }

    [Fact]
    public void Map_Should_ReturnNone_IfValueOptionInNone()
    {
        NoneValueOption.Map(Selector).ShouldBe(Option.None);
    }

    [Fact]
    public void Map_Should_ReturnSome_IfValueOptionInSome()
    {
        SomeValueOption.Map(Selector).ShouldBe(ExpectedFromValueOption);
    }
    
    
    [Fact]
    public async Task Map_Should_BehaveCorrectlyWithAsyncOverloads()
    {
        (await SomeOption.MapAsync(SelectorTask)).ShouldBe(ExpectedFromOption);
        (await SomeOptionTask.Map(Selector)).ShouldBe(ExpectedFromOption);
        (await SomeOptionTask.MapAsync(SelectorTask)).ShouldBe(ExpectedFromOption);
        
        (await SomeValueOption.MapAsync(SelectorTask)).ShouldBe(ExpectedFromValueOption);
        (await SomeValueOptionTask.Map(Selector)).ShouldBe(ExpectedFromValueOption);
        (await SomeValueOptionTask.MapAsync(SelectorTask)).ShouldBe(ExpectedFromValueOption);
    }
}