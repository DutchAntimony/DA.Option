using DA.Options;
using DA.Options.Extensions;
using Shouldly;

namespace Options.Tests.Extensions;

public class MapToValueOptionTests : OptionTestBase
{
    private const int ExpectedFromOption = 123;
    private const int ExpectedFromValueOption = 165;
    private static int Selector(string original) => 123;
    private static int Selector(int original) => original + 123;
    private static Task<int> SelectorTask(string original) => Task.FromResult(Selector(original));
    private static Task<int> SelectorTask(int original) => Task.FromResult(Selector(original));
    
    [Fact]
    public void Map_Should_ReturnNone_IfOptionIsNone()
    {
        NoneOption.MapValue(Selector).ShouldBe(Option.None);
    }

    [Fact]
    public void Map_Should_ReturnSome_IfOptionIsSome()
    {
        SomeOption.MapValue(Selector).ShouldBe(ExpectedFromOption);
    }

    [Fact]
    public void Map_Should_ReturnNone_IfValueOptionInNone()
    {
        NoneValueOption.MapValue(Selector).ShouldBe(Option.None);
    }

    [Fact]
    public void Map_Should_ReturnSome_IfValueOptionInSome()
    {
        SomeValueOption.MapValue(Selector).ShouldBe(ExpectedFromValueOption);
    }
    
    
    [Fact]
    public async Task Map_Should_BehaveCorrectlyWithAsyncOverloads()
    {
        (await SomeOption.MapValueAsync(SelectorTask)).ShouldBe(ExpectedFromOption);
        (await SomeOptionTask.MapValue(Selector)).ShouldBe(ExpectedFromOption);
        (await SomeOptionTask.MapValueAsync(SelectorTask)).ShouldBe(ExpectedFromOption);
        
        (await SomeValueOption.MapValueAsync(SelectorTask)).ShouldBe(ExpectedFromValueOption);
        (await SomeValueOptionTask.MapValue(Selector)).ShouldBe(ExpectedFromValueOption);
        (await SomeValueOptionTask.MapValueAsync(SelectorTask)).ShouldBe(ExpectedFromValueOption);
    }
}