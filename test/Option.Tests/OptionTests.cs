namespace DA.Option.Tests;

public class OptionTests
{
    [Fact]
    public void Some_Should_CreateOptionWithValue_WhenValueIsNotNull()
    {
        var option = Option<int>.Some(1);

        option.HasValue.ShouldBeTrue();
        option.HasNoValue.ShouldBeFalse();
    }

    [Fact]
    public void Some_Should_CreateOptionWithoutValue_WhenValueIsNull()
    {
        var option = Option<string>.Some(null!);
        option.HasValue.ShouldBeFalse();
        option.HasNoValue.ShouldBeTrue();
    }

    [Fact]
    public void None_Should_CreateOptionWithoutValue()
    {
        var option = Option<int>.None();
        option.HasValue.ShouldBeFalse();
        option.HasNoValue.ShouldBeTrue();
    }

    [Fact]
    public void From_Should_CreateOptionWithValue_WhenValueIsNotNull()
    {
        var option = Option<int>.From(1);

        option.HasValue.ShouldBeTrue();
        option.HasNoValue.ShouldBeFalse();
    }

    [Fact]
    public void From_Should_CreateOptionWithoutValue_WhenValueIsNull()
    {
        var option = Option<string>.From(null);
        option.HasValue.ShouldBeFalse();
        option.HasNoValue.ShouldBeTrue();
    }

    [Fact]
    public void TryGetValue_Should_ReturnTrueWithObject_WhenOptionHasValue()
    {
        var expected = 1;
        var optionWithValue = Option<int>.Some(expected);
        var result = optionWithValue.TryGetValue(out var value);
        result.ShouldBeTrue();
        value.ShouldBe(expected);
    }

    [Fact]
    public void TryGetValue_Should_ReturnFalse_WhenOptionHasNoValue()
    {
        var optionWithoutValue = Option<int>.None();
        var result = optionWithoutValue.TryGetValue(out var _);
        result.ShouldBeFalse();
    }

    [Fact]
    public void ToString_Should_ReturnValue_WhenOptionHasValue()
    {
        var expected = "expected";
        var optionWithValue = Option<string>.Some(expected);
        var result = optionWithValue.ToString();
        result.ShouldBe(expected);
    }

    [Fact]
    public void ToString_Should_ReturnEmptyString_WhenOptionHasNoValue()
    {
        var expected = string.Empty;
        var optionWithValue = Option<string>.None();
        var result = optionWithValue.ToString();
        result.ShouldBe(expected);
    }

    [Fact]
    public void Option_Should_BeConvertedToNoneResult()
    {
        Option<string> option = Option.None;
        option.HasValue.ShouldBeFalse();
    }

    [Fact]
    public void Option_Should_BeCreateableFromValue()
    {
        Option<string> option = Option.From("abc");
        option.HasValue.ShouldBeTrue();
    }

    [Fact]
    public void GetHashcode_Should_UseHashcodeFromValue()
    {
        var text = "123";
        var option = Option<string>.Some(text);
        option.GetHashCode().ShouldBe(text.GetHashCode());
    }

    [Fact]
    public void GetHashcode_Should_Be0WhenOptionIsNone()
    {
        var option = Option<string>.None();
        option.GetHashCode().ShouldBe(0);
    }

    [Fact]
    public void Equals_Should_BeTrue_WhenUnderlyingDataIsTheSame()
    {
        var text = "123";
        var option1 = Option.From(text);
        var option2 = Option.From(text);
        
        option1.Equals(option2).ShouldBeTrue();
        (option1 == option2).ShouldBeTrue();
        (option1 != option2).ShouldBeFalse();

        option1.Equals(text).ShouldBeTrue();
        (option1 == text).ShouldBeTrue();
        (option1 != text).ShouldBeFalse();
    }

    [Fact]
    public void Equals_Should_BeFalse_WhenUnderlyingDataIsNotTheSame()
    {
        var text = "123";
        var option1 = Option.From("012");
        var option2 = Option.From(text);

        option1.Equals(option2).ShouldBeFalse();
        (option1 == option2).ShouldBeFalse();
        (option1 != option2).ShouldBeTrue();

        option1.Equals(text).ShouldBeFalse();
        option1.Equals((string)null!).ShouldBeFalse();
        option1.Equals((object)text).ShouldBeFalse();
        (option1 == text).ShouldBeFalse();
        (option1 != text).ShouldBeTrue();
    }

    [Fact]
    public void Equals_Should_BeFalse_WhenUnderlyingDataIsDifferentType()
    {
        var doubleValue = 10d;
        var intValue = 10;
        var option1 = Option.From(doubleValue);
        var option2 = Option.From(intValue);

        option1.Equals(option2).ShouldBeFalse();
        (option1 == option2).ShouldBeFalse();
        (option1 != option2).ShouldBeTrue();

        option1.Equals(intValue).ShouldBeTrue();
        (option1 == intValue).ShouldBeTrue();
        (option1 != intValue).ShouldBeFalse();

        option1.Equals(null).ShouldBeFalse();
    }

    [Fact]
    public void Equals_Should_BeFalse_WhenOtherIsNone()
    {
        var value = 10;
        var option1 = Option.From(value);
        var option2 = Option.None;

        option1.Equals(option2).ShouldBeFalse();
        option1.Equals((Option<int>)option2).ShouldBeFalse();
        ((Option<int>)option2).Equals(option1).ShouldBeFalse();
        (option1 == option2).ShouldBeFalse();
        (option1 != option2).ShouldBeTrue();

        option2.Equals(value).ShouldBeFalse();
        ((Option<int>)option2).Equals(value).ShouldBeFalse();
        ((Option<int>)option2 == value).ShouldBeFalse();
        ((Option<int>)option2 != value).ShouldBeTrue();
    }

    [Fact]
    public void Equals_Should_BeTrue_WhenBothAreNone()
    {
        Option<string> option1 = Option.None;
        Option<string> option2 = Option.None;

        option1.Equals(option2).ShouldBeTrue();
        option1.Equals((object)option2).ShouldBeTrue();
        (option1 == option2).ShouldBeTrue();
        (option1 != option2).ShouldBeFalse();
    }
}
