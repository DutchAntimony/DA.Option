using DA.Options.Extensions;
using Shouldly;

namespace Options.Tests.Extensions;

public class ReduceTests : OptionTestBase
{
    private static string ThrowingString() => throw new ShouldAssertException("Should not be called");
    private static int ThrowingInt() => throw new ShouldAssertException("Should not be called");
    private static Task<string> ThrowingStringTask() => throw new ShouldAssertException("Should not be called");
    private static Task<int> ThrowingIntTask() => throw new ShouldAssertException("Should not be called");
    
    [Fact]
    public void Reduce_Should_RemainOriginal_IfOptionIsSome()
    {
        SomeOption.Reduce("def").ShouldBe(OptionValue);
        SomeOption.Reduce(ThrowingString).ShouldBe(OptionValue);
    }

    [Fact]
    public void Reduce_Should_ReplaceOriginal_IfOptionIsNone()
    {
        NoneOption.Reduce("def").ShouldBe("def");
        NoneOption.Reduce(() => "def").ShouldBe("def");
    }
    
    [Fact]
    public void Reduce_Should_RemainOriginal_IfValueOptionIsSome()
    {
        SomeValueOption.Reduce(456).ShouldBe(ValueOptionValue);
        SomeValueOption.Reduce(ThrowingInt).ShouldBe(ValueOptionValue);
    }

    [Fact]
    public void Reduce_Should_ReplaceOriginal_IfValueOptionIsNone()
    {
        NoneValueOption.Reduce(456).ShouldBe(456);
        NoneValueOption.Reduce(() => 456).ShouldBe(456);
    }

    [Fact]
    public async Task Reduce_Should_BehaveCorrectlyWithAsyncOverloads()
    {
        (await SomeOptionTask.Reduce("def")).ShouldBe(OptionValue);
        (await SomeOptionTask.Reduce(ThrowingString)).ShouldBe(OptionValue);
        (await SomeOptionTask.ReduceAsync(ThrowingString)).ShouldBe(OptionValue);
        (await SomeOptionTask.ReduceAsync(ThrowingStringTask)).ShouldBe(OptionValue);
        (await SomeOption.ReduceAsync(ThrowingStringTask)).ShouldBe(OptionValue);
        
        (await SomeValueOptionTask.Reduce(456)).ShouldBe(ValueOptionValue);
        (await SomeValueOptionTask.Reduce(ThrowingInt)).ShouldBe(ValueOptionValue);
        (await SomeValueOptionTask.ReduceAsync(ThrowingInt)).ShouldBe(ValueOptionValue);
        (await SomeValueOptionTask.ReduceAsync(ThrowingIntTask)).ShouldBe(ValueOptionValue);
        (await SomeValueOption.ReduceAsync(ThrowingIntTask)).ShouldBe(ValueOptionValue);
    }
}