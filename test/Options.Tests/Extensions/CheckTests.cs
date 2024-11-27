using DA.Options;
using DA.Options.Extensions;
using Shouldly;

namespace Options.Tests.Extensions;

public class CheckTests : OptionTestBase
{
    private static bool PassingCheck(string value) => true;
    private static bool FailingCheck(string value) => false;
    private static Task<bool> FailingCheckTask(string value) => Task.FromResult(FailingCheck(value));
    private static bool ThrowingCheck(string value) => throw new ShouldAssertException("Should not be called");
    private static bool PassingValueCheck(int value) => true;
    private static bool FailingValueCheck(int value) => false;
    private static Task<bool> FailingValueCheckTask(int value) => Task.FromResult(FailingValueCheck(value));
    private static bool ThrowingValueCheck(int value) => throw new ShouldAssertException("Should not be called");
    
    [Fact]
    public void Check_Should_ReturnOption_IfCheckPasses()
    {
        SomeOption.Check(PassingCheck).ShouldBe(SomeOption);
    }
    
    [Fact]
    public void Check_Should_ReturnNone_IfCheckFails()
    {
        SomeOption.Check(FailingCheck).ShouldBe(Option.None);
    }

    [Fact]
    public void Check_Should_ReturnNone_AndNotThrow_IfCheckFails()
    {
        NoneOption.Check(ThrowingCheck).ShouldBe(Option.None);
    }
    
    [Fact]
    public void Check_Should_ReturnValueOption_IfCheckPasses()
    {
        SomeValueOption.Check(PassingValueCheck).ShouldBe(SomeValueOption);
    }
    
    [Fact]
    public void Check_Should_ReturnValueNone_IfCheckFails()
    {
        SomeValueOption.Check(FailingValueCheck).ShouldBe(ValueOption.None);
    }

    [Fact]
    public void Check_Should_ReturnValueNone_AndNotThrow_IfCheckFails()
    {
        NoneValueOption.Check(ThrowingValueCheck).ShouldBe(ValueOption.None);
    }

    [Fact]
    public async Task Check_Should_BehaveCorrectlyWithAsyncOverloads()
    {
        (await SomeOption.CheckAsync(FailingCheckTask)).ShouldBe(Option.None);
        (await SomeOptionTask.Check(FailingCheck)).ShouldBe(Option.None);
        (await SomeOptionTask.CheckAsync(FailingCheckTask)).ShouldBe(Option.None);
        
        (await SomeValueOption.CheckAsync(FailingValueCheckTask)).ShouldBe(ValueOption.None);
        (await SomeValueOptionTask.Check(FailingValueCheck)).ShouldBe(ValueOption.None);
        (await SomeValueOptionTask.CheckAsync(FailingValueCheckTask)).ShouldBe(ValueOption.None);
    }
}