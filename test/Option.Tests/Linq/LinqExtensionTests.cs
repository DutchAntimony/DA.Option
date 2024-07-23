using DA.Options.Linq;

namespace DA.Options.Tests.Linq;

public  class LinqExtensionTests
{

    private readonly Option<int> _none = Option.None;
    private readonly Option<int> _some = Option.From(1);

    [Fact]
    public void Linq_Tests_Select()
    {
        var noneDoubled =
            from x in _none
            select x * 2;

        var someDoubled =
            from x in _some
            select x * 2;

        noneDoubled.ShouldBeOfType<Option<int>>();
        noneDoubled.HasValue.ShouldBeFalse();

        someDoubled.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(2);
    }

    [Fact]
    public void Linq_Tests_SelectMany()
    {
        var someSelectedTwice =
            from x in _some
            from y in Option.From(x*2)
            select x * y;

        someSelectedTwice.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(2);
    }

    [Fact]
    public void Linq_Tests_Where()
    {
        var someFailingPredicate =
            from x in _some
            where x > 1
            select x;

        var somePassingPredicate =
            from x in _some
            where x <= 1
            select x;

        someFailingPredicate.HasValue.ShouldBeFalse();
        somePassingPredicate.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(1);
    }

    [Fact]
    public void Linq_Tests_SelectMany_ResultIndependent()
    {
        var multiplied =
            from x in _some
            from y in Option.From(x * 2)
            select y;

        multiplied.TryGetValue(out var value).ShouldBeTrue();
        value.ShouldBe(2);
    }
}
