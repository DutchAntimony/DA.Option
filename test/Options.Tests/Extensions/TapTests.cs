using DA.Options.Extensions;
using Shouldly;

namespace Options.Tests.Extensions;

public class TapTests : OptionTestBase
{
    private int _testValue = 0;
    
    private void SomeAction(string original) => _testValue++;
    private void SomeValueAction(int original) => _testValue += original;

    private Task SomeActionTask(string original)
    {
        SomeAction(original);
        return Task.CompletedTask;
    }

    private Task SomeValueActionTask(int original)
    {
        SomeValueAction(original);
        return Task.CompletedTask;
    }
    private static void ThrowingAction(string original) => throw new ShouldAssertException("Should not be called");
    private static void ThrowingAction(int original) => throw new ShouldAssertException("Should not be called");

    private static Task ThrowingActionTask(string original)
    {
        ThrowingAction(original);
        return Task.CompletedTask;
    }

    private static Task ThrowingActionTask(int original)
    {
        ThrowingAction(original);
        return Task.CompletedTask;
    }

    [Fact]
    public void Tap_Should_ApplyAction_WhenOptionIsSome()
    {
        _testValue = 0;
        SomeOption.Tap(SomeAction);
        _testValue.ShouldBe(1);
    }

    [Fact]
    public void Tap_Should_ApplyAction_WhenValueOptionIsSome()
    {
        _testValue = 0;
        SomeValueOption.Tap(SomeValueAction);
        _testValue.ShouldBe(ValueOptionValue);
    }

    [Fact]
    public void Tap_Should_NotApplyAction_WhenOptionIsNone()
    {
        Should.NotThrow(() => NoneOption.Tap(ThrowingAction));
    }
    
    [Fact]
    public void Tap_Should_NotApplyAction_WhenValueOptionIsNone()
    {
        Should.NotThrow(() => NoneValueOption.Tap(ThrowingAction));
    }

    [Fact]
    public async Task Tap_Should_BehaveCorrectlyWithAsyncOverloads()
    {
        await Should.NotThrowAsync(() => NoneOption.TapAsync(ThrowingActionTask));
        await Should.NotThrowAsync(() => NoneValueOption.TapAsync(ThrowingActionTask));

        await Should.NotThrowAsync(() => NoneOptionTask.Tap(ThrowingAction));
        await Should.NotThrowAsync(() => NoneValueOptionTask.Tap(ThrowingAction));
    
        await Should.NotThrowAsync(() => NoneOptionTask.TapAsync(ThrowingActionTask));
        await Should.NotThrowAsync(() => NoneValueOptionTask.TapAsync(ThrowingActionTask));
        
        _testValue = 0;
        await SomeOptionTask.Tap(SomeAction);
        _testValue.ShouldBe(1);
        
        _testValue = 0;
        await SomeValueOptionTask.Tap(SomeValueAction);
        _testValue.ShouldBe(ValueOptionValue);
        
        _testValue = 0;
        await SomeOptionTask.TapAsync(SomeActionTask);
        _testValue.ShouldBe(1);
        
        _testValue = 0;
        await SomeValueOptionTask.TapAsync(SomeValueActionTask);
        _testValue.ShouldBe(ValueOptionValue);
    }
}