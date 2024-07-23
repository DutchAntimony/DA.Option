namespace DA.Options.Collections;

public static class CollectionExtensions
{
    /// <summary>
    /// Flattens the sequence of option values by omitting all none values.
    /// </summary>
    public static IEnumerable<TValue> Values<TValue>(this IEnumerable<Option<TValue>> sequence)
    {
        foreach (var option in sequence)
        {
            if (option.TryGetValue(out var value))
            {
                yield return value;
            }
        }
    }


    /// <summary>
    /// Flattens the sequence of option values by omitting all none values and values that do not satisfy the predicate.
    /// </summary>
    public static IEnumerable<TValue> Values<TValue>(this IEnumerable<Option<TValue>> sequence, Func<TValue, bool> predicate)
    {
        foreach (var option in sequence)
        {
            if (option.TryGetValue(out var value) && predicate(value))
            {
                yield return value;
            }
        }
    }

    /// <summary>
    /// Return the first filled non empty entry in this sequence.
    /// </summary>
    public static Option<TValue> FirstOrNone<TValue>(this IEnumerable<Option<TValue>> sequence) =>
        sequence.Where(option => option.HasValue).FirstOrDefault(Option.None);

    /// <summary>
    /// Return the first filled non empty entry in this sequence that satisfies the predicate.
    /// </summary>
    public static Option<TValue> FirstOrNone<TValue>(this IEnumerable<Option<TValue>> sequence, Func<TValue, bool> predicate) =>
        sequence.Where(option => option.TryGetValue(out var value) && predicate(value)).FirstOrDefault(Option.None);

    /// <summary>
    /// Return the last filled non empty entry in this sequence.
    /// </summary>
    public static Option<TValue> LastOrNone<TValue>(this IEnumerable<Option<TValue>> sequence) =>
        sequence.Where(option => option.HasValue).LastOrDefault(Option.None);

    /// <summary>
    /// Return the last filled non empty entry in this sequence that satisfies the predicate.
    /// </summary>
    public static Option<TValue> LastOrNone<TValue>(this IEnumerable<Option<TValue>> sequence, Func<TValue, bool> predicate) =>
        sequence.Where(option => option.TryGetValue(out var value) && predicate(value)).LastOrDefault(Option.None);

    /// <summary>
    /// Return the amount of non empty entries in this sequence.
    /// </summary>
    public static int CountNotNone<TValue>(this IEnumerable<Option<TValue>> sequence) =>
        sequence.Count(option => option.HasValue);

    /// <summary>
    /// Return the amount of non empty entries in this sequence that satisfy a given predicate.
    /// </summary>
    /// <param name="predicate">The predicate, a func from value to bool.</param>
    public static int CountNotNone<TValue>(this IEnumerable<Option<TValue>> sequence, Func<TValue, bool> predicate) =>
        sequence.Count(option => option.TryGetValue(out var value) && predicate(value));

    /// <summary>
    /// Return true if there are any non empty entries in this sequence.
    /// </summary>
    public static bool AnyNotNone<TValue>(this IEnumerable<Option<TValue>> sequence) =>
        sequence.Any(option => option.HasValue);

    /// <summary>
    /// Return true if there are any non empty entries in this sequence that satisfy a given predicate.
    /// </summary>
    /// <param name="predicate">The predicate, a func from value to bool.</param>
    public static bool AnyNotNone<TValue>(this IEnumerable<Option<TValue>> sequence, Func<TValue, bool> predicate) =>
        sequence.Any(option => option.TryGetValue(out var value) && predicate(value));
}