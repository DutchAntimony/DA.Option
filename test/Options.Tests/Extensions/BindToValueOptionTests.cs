using DA.Options;
using DA.Options.Extensions;
using Shouldly;

namespace Options.Tests.Extensions;

public class BindToValueOptionTests : OptionTestBase
{
    private const int ExpectedFromOption = 123;
    private const int ExpectedFromValueOption = 165;
    private static ValueOption<int> Selector(string original) => ExpectedFromOption;
    private static ValueOption<int> Selector(int original) => original + 123;
    private static Task<ValueOption<int>> SelectorTask(string original) => Task.FromResult(Selector(original));
    private static Task<ValueOption<int>> SelectorTask(int original) => Task.FromResult(Selector(original));
    
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