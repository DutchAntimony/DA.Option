using DA.Options.Extensions;
using Shouldly;

namespace Options.Tests.Extensions;

public class AsNullableTests : OptionTestBase
{
    [Fact]
    public void AsNullable_Should_ReturnNull_IfOptionIsNone()
    {
        NoneOption.AsNullable().ShouldBeNull();
    }
    
    [Fact]
    public void AsNullable_Should_ReturnNull_IfValueOptionIsNone()
    {
        NoneValueOption.AsNullable().ShouldBeNull();
    }

    [Fact]
    public void AsNullable_Should_ReturnValue_IfOptionIsSome()
    {
        SomeOption.AsNullable().ShouldBe(OptionValue);
    }

    [Fact]
    public void AsNullable_Should_ReturnValue_IfValueOptionIsSome()
    {
        SomeValueOption.AsNullable().ShouldBe(ValueOptionValue);
    }

    [Fact]
    public async Task AsNullable_Should_BehaveCorrectlyWithAsyncOverloads()
    {
        (await SomeOptionTask.AsNullable()).ShouldBe(OptionValue);
        (await SomeValueOptionTask.AsNullable()).ShouldBe(ValueOptionValue);
    }
}