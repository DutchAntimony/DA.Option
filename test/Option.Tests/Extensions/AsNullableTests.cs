using DA.Options.Extensions;

namespace DA.Options.Tests.Extensions;

public class AsNullableTests
{
    [Fact]
    public void AsNullable_Should_KeepValue_ForStructWithValue()
    {
        var option = Option.From(1);
        var result = option.AsNullable();
        result.HasValue.ShouldBeTrue();
        result.Value.ShouldBe(1);
    }

    [Fact]
    public void AsNullable_Should_BeNull_ForStructWithoutValue()
    {
        Option<int> option = Option.None;
        var result = option.AsNullable();
        result.HasValue.ShouldBeFalse();
    }

    [Fact]
    public void AsNullable_Should_KeepValue_ForClassWithValue()
    {
        var option = Option.From("abc");
        var result = option.AsNullable();
        result.ShouldNotBeNull();
        result.ShouldBe("abc");
    }

    [Fact]
    public void AsNullable_Should_BeNull_ForClassesWithoutValue()
    {
        Option<string> option = Option.None;
        var result = option.AsNullable();
        result.ShouldBeNull();
    }

    [Fact]
    public async Task AsNullableStructAsync_Should_KeepValue_ForStructWithValue()
    {
        var optionTask = Task.FromResult(Option.From(1));
        var result = await optionTask.AsNullableStructAsync();
        result.HasValue.ShouldBeTrue();
        result.Value.ShouldBe(1);
    }

    [Fact]
    public async Task AsNullableStructAsync_Should_BeNull_ForStructWithoutValue()
    {
        var optionTask = Task.FromResult(Option<int>.None());
        var result = await optionTask.AsNullableStructAsync();
        result.HasValue.ShouldBeFalse();
    }

    [Fact]
    public async Task AsNullableAsync_Should_KeepValue_ForClassWithValue()
    {
        var optionTask = Task.FromResult(Option.From("abc"));
        var result = await optionTask.AsNullableAsync();
        result.ShouldNotBeNull();
        result.ShouldBe("abc");
    }

    [Fact]
    public async Task AsNullableAsync_Should_BeNull_ForClassesWithoutValue()
    {
        var optionTask = Task.FromResult(Option<string>.None());
        var result = await optionTask.AsNullableAsync();
        result.ShouldBeNull();
    }
}
