using DA.Options.Extensions;

namespace DA.Options.Linq;

public static class LinqExtensions
{
    /// <summary>
    /// Declaration required for linq query syntax
    /// </summary>
    public static Option<TResult> Select<TSource, TResult>(this Option<TSource> source, Func<TSource, TResult> selector)
    {
        return source.Map(selector);
    }

    /// <summary>
    /// Declaration required for linq query syntax
    /// </summary>
    public static Option<TResult> SelectMany<TSource, TCollection, TResult>(
        this Option<TSource> source, 
        Func<TSource, Option<TCollection>> collectionSelector,
        Func<TSource, TCollection, TResult> resultSelector)
    {
        return source.Bind(source => collectionSelector(source).Map(value => resultSelector(source, value)));
    }

    public static Option<TValue> Where<TValue>(this Option<TValue> option, Func<TValue, bool> predicate)
    {
        return option.Check(predicate);
    }
}