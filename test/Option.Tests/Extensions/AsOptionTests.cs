using DA.Options.Extensions;

namespace DA.Options.Tests.Extensions;

public class AsOptionTests
{
    [Fact]
    public void AsOption_Should_KeepValue_ForStructWithValue()
    {
        int? expected = 1;
        var result = expected.AsOption();
        result.TryGetValue(out var actual).ShouldBeTrue();
        actual.ShouldBe(expected.Value);
    }

    [Fact]
    public void AsOption_Should_BeNull_ForStructWithoutValue()
    {
        int? expected = null;
        var result = expected.AsOption();
        result.TryGetValue(out var _).ShouldBeFalse();
    }

    [Fact]
    public void AsOption_Should_KeepValue_ForClassWithValue()
    {
        string? expected = "abc";
        var result = expected.AsOption();
        result.TryGetValue(out var actual).ShouldBeTrue();
        actual.ShouldBe(expected);
    }

    [Fact]
    public void AsOption_Should_BeNull_ForClassesWithoutValue()
    {
        string? expected = null;
        var result = expected.AsOption();
        result.TryGetValue(out var _).ShouldBeFalse();
    }

    [Fact]
    public async Task AsOptionAsync_Should_KeepValue_ForStructWithValue()
    {
        int? expected = 1;
        var expectedTask = Task.FromResult(expected);
        var result = await expectedTask.AsOptionAsync();
        result.TryGetValue(out var actual).ShouldBeTrue();
        actual.ShouldBe(expected.Value);
    }

    [Fact]
    public async Task AsOptionAsync_Should_BeNull_ForStructWithoutValue()
    {
        int? expected = null;
        var expectedTask = Task.FromResult(expected);
        var result = await expectedTask.AsOptionAsync();
        result.TryGetValue(out var _).ShouldBeFalse();
    }

    [Fact]
    public async Task AsOptionAsync_Should_KeepValue_ForClassWithValue()
    {
        string? expected = "abc";
        var expectedTask = Task.FromResult((string?)expected);
        var result = await expectedTask.AsOptionAsync();
        result.TryGetValue(out var actual).ShouldBeTrue();
        actual.ShouldBe(expected);
    }

    [Fact]
    public async Task AsOptionAsync_Should_BeNull_ForClassesWithoutValue()
    {
        string? expected = null;
        var expectedTask = Task.FromResult(expected);
        var result = await expectedTask.AsOptionAsync();
        result.TryGetValue(out var _).ShouldBeFalse();
    }
}
