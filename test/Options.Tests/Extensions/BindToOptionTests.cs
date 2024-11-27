using DA.Options;
using DA.Options.Extensions;
using Shouldly;

namespace Options.Tests.Extensions;

public class BindToOptionTests : OptionTestBase
{
    private const string ExpectedFromOption = "abcdef";
    private const string ExpectedFromValueOption = "42def";
    private static Option<string> Selector(string original) => original + "def";
    private static Option<string> Selector(int original) => original + "def";
    private static Task<Option<string>> SelectorTask(string original) => Task.FromResult(Selector(original));
    private static Task<Option<string>> SelectorTask(int original) => Task.FromResult(Selector(original));
    
    [Fact]
    public void Bind_Should_ReturnNone_IfOptionIsNone()
    {
        NoneOption.Bind(Selector).ShouldBe(Option.None);
    }

    [Fact]
    public void Bind_Should_ReturnSome_IfOptionIsSome()
    {
        SomeOption.Bind(Selector).ShouldBe(ExpectedFromOption);
    }

    [Fact]
    public void Bind_Should_ReturnNone_IfValueOptionInNone()
    {
        NoneValueOption.Bind(Selector).ShouldBe(Option.None);
    }

    [Fact]
    public void Bind_Should_ReturnSome_IfValueOptionInSome()
    {
        SomeValueOption.Bind(Selector).ShouldBe(ExpectedFromValueOption);
    }
    
    
    [Fact]
    public async Task Bind_Should_BehaveCorrectlyWithAsyncOverloads()
    {
        (await SomeOption.BindAsync(SelectorTask)).ShouldBe(ExpectedFromOption);
        (await SomeOptionTask.Bind(Selector)).ShouldBe(ExpectedFromOption);
        (await SomeOptionTask.BindAsync(SelectorTask)).ShouldBe(ExpectedFromOption);
        
        (await SomeValueOption.BindAsync(SelectorTask)).ShouldBe(ExpectedFromValueOption);
        (await SomeValueOptionTask.Bind(Selector)).ShouldBe(ExpectedFromValueOption);
        (await SomeValueOptionTask.BindAsync(SelectorTask)).ShouldBe(ExpectedFromValueOption);
    }
}