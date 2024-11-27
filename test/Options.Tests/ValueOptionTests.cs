using DA.Options;
using Shouldly;

namespace Options.Tests;

public class ValueOptionTests : OptionTestBase
{
    [Fact]
    public void ToString_Should_ReturnValue_ForSomeOption()
    {
        SomeValueOption.ToString().ShouldBe(ValueOptionValue.ToString());
    }

    [Fact]
    public void ToString_Should_ReturnEmptyString_ForNoneOption()
    {
        NoneValueOption.ToString().ShouldBe(string.Empty);
    }

    [Fact]
    public void Equals_ShouldBeTrue_ForEqualOption()
    {
        ValueOption<int> shadow = 42;
        
        (SomeValueOption == 42).ShouldBeTrue();
        (SomeValueOption == 43).ShouldBeFalse();
        (NoneValueOption == 0).ShouldBeFalse();
        (SomeValueOption != 43).ShouldBeTrue();
        
        (SomeValueOption == shadow).ShouldBeTrue();
        (SomeValueOption == ValueOption.From(123)).ShouldBeFalse();
        (NoneValueOption == shadow).ShouldBeFalse();
        (SomeValueOption != shadow).ShouldBeFalse();
        
        SomeOption.Equals(null).ShouldBeFalse();
        SomeValueOption.Equals(42).ShouldBeTrue();
        SomeValueOption.Equals(shadow).ShouldBeTrue();
        
        SomeValueOption.Equals((object?)null).ShouldBeFalse();
        SomeValueOption.Equals(42).ShouldBeTrue();
        SomeValueOption.Equals("abc").ShouldBeFalse();
        SomeValueOption.Equals((object?)shadow).ShouldBeTrue();
        
        NoneValueOption.Equals(null).ShouldBeTrue();
        NoneValueOption.Equals(42).ShouldBeFalse();
        NoneValueOption.Equals(Option.None).ShouldBeTrue();
    }

    [Fact]
    public void GetHashCode_Should_ReturnHashcodeOfObject_IfOptionIsSome()
    {
        SomeValueOption.GetHashCode().ShouldBe(42.GetHashCode());
    }

    [Fact]
    public void GetHashCode_Should_ReturnZero_IfOptionIsNone()
    {
        NoneValueOption.GetHashCode().ShouldBe(0);
    }
}