using DA.Options;
using DA.Options.Collections;
using Shouldly;

namespace Options.Tests.Collections;

public class CollectionOfOptionExtensionTests
{
    private readonly IEnumerable<Option<string>> _optionCollection = [Option.None, "A", "AB", Option.None, "C", Option.None];
    private readonly IEnumerable<Option<string>> _emptyCollection = [Option.None, Option.None];

    [Fact]
    public void Values_Should_ReturnAllNoneValues_FromCollection()
    {
        _optionCollection.Values().Count().ShouldBe(3);
        _emptyCollection.Values().Count().ShouldBe(0); 
    }
    
    [Fact]
    public void Values_Should_ReturnAllNoneValuesMatchingCriteria_FromCollection()
    {
        _optionCollection.Values(v => v.StartsWith('A')).Count().ShouldBe(2);
        _optionCollection.Values(v => v.StartsWith('Z')).Count().ShouldBe(0);
        _emptyCollection.Values(v => v.StartsWith('A')).Count().ShouldBe(0); 
    }

    [Fact]
    public void FirstOrNone_Should_ReturnFirstValue_FromCollection()
    {
        _optionCollection.FirstOrNone().ShouldBe("A");
        _emptyCollection.FirstOrNone().ShouldBe(Option.None);
    }

    [Fact]
    public void FirstOrNone_Should_ReturnFirstValueMatchingCriteria_FromCollection()
    {
        _optionCollection.FirstOrNone(v => v.StartsWith('A')).ShouldBe("A");
        _optionCollection.FirstOrNone(v => v.StartsWith('Z')).ShouldBe(Option.None);
        _emptyCollection.FirstOrNone(v => v.StartsWith('A')).ShouldBe(Option.None);
    }
    
    [Fact]
    public void LastOrNone_Should_ReturnLastValue_FromCollection()
    {
        _optionCollection.LastOrNone().ShouldBe("C");
        _emptyCollection.LastOrNone().ShouldBe(Option.None);
    }

    [Fact]
    public void LastOrNone_Should_ReturnLastValueMatchingCriteria_FromCollection()
    {
        _optionCollection.LastOrNone(v => v.StartsWith('A')).ShouldBe("AB");
        _optionCollection.LastOrNone(v => v.StartsWith('Z')).ShouldBe(Option.None);
        _emptyCollection.LastOrNone(v => v.StartsWith('A')).ShouldBe(Option.None);
    }

    [Fact]
    public void CountValues_Should_ReturnTheAmountOfNotNoneValues_FromCollection()
    {
        _optionCollection.CountValues().ShouldBe(3);
        _emptyCollection.CountValues().ShouldBe(0);
    }
    
    [Fact]
    public void CountValues_Should_ReturnTheAmountOfNotNoneValues_MatchingCriteria_FromCollection()
    {
        _optionCollection.CountValues(v => v.StartsWith('A')).ShouldBe(2);
        _optionCollection.CountValues(v => v.StartsWith('Z')).ShouldBe(0);
        _emptyCollection.CountValues(v => v.StartsWith('A')).ShouldBe(0);
    }

    [Fact]
    public void AnyValues_Should_ReturnTrue_IfAnyValuesExist_FromCollection()
    {
        _optionCollection.AnyValues().ShouldBeTrue();
        _emptyCollection.AnyValues().ShouldBeFalse();
    }
    
    [Fact]
    public void AnyValues_Should_ReturnTrue_IfAnyValuesMatched_FromCollection()
    {
        _optionCollection.AnyValues(v => v.StartsWith('A')).ShouldBeTrue();
        _optionCollection.AnyValues(v => v.StartsWith('Z')).ShouldBeFalse();
        _emptyCollection.AnyValues(v => v.StartsWith('A')).ShouldBeFalse();
    }
}

public class CollectionOfValueOptionsExtensionTests
{
    private readonly IEnumerable<ValueOption<int>> _optionCollection = [Option.None, 1, 2, Option.None, 3, Option.None];
    private readonly IEnumerable<ValueOption<int>> _emptyCollection = [Option.None, Option.None];
    
    [Fact]
    public void Values_Should_ReturnAllNoneValues_FromCollection()
    {
        _optionCollection.Values().Count().ShouldBe(3);
        _emptyCollection.Values().Count().ShouldBe(0); 
    }
    
    [Fact]
    public void Values_Should_ReturnAllNoneValuesMatchingCriteria_FromCollection()
    {
        _optionCollection.Values(v => v > 1).Count().ShouldBe(2);
        _optionCollection.Values(v => v < 1).Count().ShouldBe(0);
        _emptyCollection.Values(v => v > 1).Count().ShouldBe(0); 
    }

    [Fact]
    public void FirstOrNone_Should_ReturnFirstValue_FromCollection()
    {
        _optionCollection.FirstOrNone().ShouldBe(1);
        _emptyCollection.FirstOrNone().ShouldBe(Option.None);
    }

    [Fact]
    public void FirstOrNone_Should_ReturnFirstValueMatchingCriteria_FromCollection()
    {
        _optionCollection.FirstOrNone(v => v > 1).ShouldBe(2);
        _optionCollection.FirstOrNone(v => v < 1).ShouldBe(Option.None);
        _emptyCollection.FirstOrNone(v => v > 1).ShouldBe(Option.None);
    }
    
    [Fact]
    public void LastOrNone_Should_ReturnLastValue_FromCollection()
    {
        _optionCollection.LastOrNone().ShouldBe(3);
        _emptyCollection.LastOrNone().ShouldBe(Option.None);
    }

    [Fact]
    public void LastOrNone_Should_ReturnLastValueMatchingCriteria_FromCollection()
    {
        _optionCollection.LastOrNone(v => v < 3).ShouldBe(2);
        _optionCollection.LastOrNone(v => v > 3).ShouldBe(Option.None);
        _emptyCollection.LastOrNone(v => v > 1).ShouldBe(Option.None);
    }

    [Fact]
    public void CountValues_Should_ReturnTheAmountOfNotNoneValues_FromCollection()
    {
        _optionCollection.CountValues().ShouldBe(3);
        _emptyCollection.CountValues().ShouldBe(0);
    }
    
    [Fact]
    public void CountValues_Should_ReturnTheAmountOfNotNoneValues_MatchingCriteria_FromCollection()
    {
        _optionCollection.CountValues(v => v > 1).ShouldBe(2);
        _optionCollection.CountValues(v => v < 1).ShouldBe(0);
        _emptyCollection.CountValues(v => v > 1).ShouldBe(0);
    }

    [Fact]
    public void AnyValues_Should_ReturnTrue_IfAnyValuesExist_FromCollection()
    {
        _optionCollection.AnyValues().ShouldBeTrue();
        _emptyCollection.AnyValues().ShouldBeFalse();
    }
    
    [Fact]
    public void AnyValues_Should_ReturnTrue_IfAnyValuesMatched_FromCollection()
    {
        _optionCollection.AnyValues(v => v > 1).ShouldBeTrue();
        _optionCollection.AnyValues(v => v < 1).ShouldBeFalse();
        _emptyCollection.AnyValues(v => v > 1).ShouldBeFalse();
    }
}