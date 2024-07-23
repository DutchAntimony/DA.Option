using DA.Options.Collections;

namespace DA.Options.Tests.Collections;

public class OptionExtensions_Collection_Tests
{
    private readonly IEnumerable<Option<int>> _filledList = [Option.None, Option.From(1), Option.None, Option.From(2), Option.From(3), Option.None];
    private readonly IEnumerable<Option<int>> _emptyList = [Option.None, Option.None];

    [Fact]
    public void Values_Should_ReturnFlattenedIEnumerableWithoutEmptyItems()
    {
        var result = _filledList.Values();
        result.ShouldBeAssignableTo<IEnumerable<int>>();
        result.ShouldBe(Enumerable.Range(1, 3));
    }

    [Fact]
    public void Values_Should_ReturnFlattenedIEnumerableWithoutEmptyItemsWithPredicate()
    {
        var result = _filledList.Values(x => x > 2);
        result.ShouldBeAssignableTo<IEnumerable<int>>();
        result.ShouldBe(Enumerable.Range(3, 1));
    }

    [Fact]
    public void FirstOrNone_Should_ReturnFirstNonNoneElementInSequence()
    {
        _filledList.FirstOrNone().ShouldBe(Option.From(1));
        _emptyList.FirstOrNone().ShouldBe(Option.None);
    }

    [Fact]
    public void FirstOrNone_Should_ReturnFirstNonNoneElementInSequenceWithPredicate()
    {
        _filledList.FirstOrNone(x => x > 1).ShouldBe(Option.From(2));
        _emptyList.FirstOrNone(x => true).ShouldBe(Option.None);
    }

    [Fact]
    public void LastOrNone_Should_ReturnLastNonNoneElementInSequence()
    {
        _filledList.LastOrNone().ShouldBe(Option.From(3));
        _emptyList.LastOrNone().ShouldBe(Option.None);
    }

    [Fact]
    public void LastOrNone_Should_ReturnLastNonNoneElementInSequenceWithPredicate()
    {
        _filledList.LastOrNone(x => x < 3).ShouldBe(Option.From(2));
        _emptyList.LastOrNone(x => true).ShouldBe(Option.None);
    }

    [Fact]
    public void CountNotNone_Should_ReturnNonNoneCountInSequence()
    {
        _filledList.CountNotNone().ShouldBe(3);
        _emptyList.CountNotNone().ShouldBe(0);
    }

    [Fact]
    public void CountNotNone_Should_ReturnNonNoneCountInSequenceWithPredicate()
    {
        _filledList.CountNotNone(x => x > 1).ShouldBe(2);
        _filledList.CountNotNone(x => x > 3).ShouldBe(0);
        _emptyList.CountNotNone(x => true).ShouldBe(0);
    }

    [Fact]
    public void AnyNotNone_Should_CheckIfAnyElementIsNotNone()
    {
        _filledList.AnyNotNone().ShouldBeTrue();
        _emptyList.AnyNotNone().ShouldBeFalse();
    }

    [Fact]
    public void AnyNotNone_Should_CheckIfAnyElementIsNotNoneWithPredicate()
    {
        _filledList.AnyNotNone(x => x > 1).ShouldBeTrue();
        _filledList.AnyNotNone(x => x > 3).ShouldBeFalse();
        _emptyList.AnyNotNone(x => true).ShouldBeFalse();
    }
}
