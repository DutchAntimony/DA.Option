# DA.Option

## Overview

DA.Option is an Option monad implementation for C#, initially developed by DutchAntimony for personal projects.

## Inspiration

DA.Option draws inspiration from the following projects:
- [Optional](https://github.com/nlkl/Optional)
- [Maybe](https://github.com/dotnetfunctional/Maybe)

## Features

- Adheres to naming conventions of functional programming languages like F# and Haskell
- Fully supports asynchronous Tasks returning options without requiring prior task awaiting
- Enables query-style LINQ syntax
- Supports collections of optional objects
- Comprehensive testing with 100% code coverage using XUnit

## Syntax

A generic option can either contain a value or no value at all. Options can be created using the `Some` or `None` methods. Additionally, options can be created from nullable objects using the `From` method.

```csharp
var option = Option<int>.Some(1); // An option of an int with the value 1
var option = Option<int>.None();  // An option of an int with no value
var option = Option.From("abc");  // An option created from a nullable object
 ```

## Extension Methods

DA.Option includes many extension methods to enhance functionality:

- `AsNullable`: Converts the `Option<T>` back to a `T?` for compatibility with other libraries
- `AsOption`: Converts a `T?` to an `Option<T>`, an alternative to the `Option.From` method
- `Bind`: Binds the option from one type to another using a function that converts from `TIn` to `Option<TOut>`
- `Check`: Check whether the option's value satisfies a predicate and removes the value if it does not
- `Flatten`: Flattens nested options to single options
- `Map`: Maps the option from one type to another using a function that converts from `TIn` to `TOut`
- `Match`: Performs an action or task based on whether the option has a value or not
- `Reduce`: Provides an alternative value for the option if it has no value
- `Tap`: Performs an action only if the option has a value
- `TapIfNone`: Performs an action only if the option has no value

## LINQ query syntax

DA.Option style `Option<T>` structs can be used in query syntax by importing the namespace:

```csharp
using DA.Option.Linq
```

## Collections of optional objects

DA.Option also provides extension methods for collections of option objects, using the generic `IEnumerable<Option<T>>` method.
The following extension methods are provided:

- `Values`: yield return any not `none` element in a sequence of option objects.
- `FirstOrNone`: returns the first not `none` element in a sequence, or the `none` option if there is no such element.
- `LastOrNone`: returns the last not `none` element in a sequence, or the `none` option if there is no such element.
- `CountNotNone`: returns the integer amount of not `none` elements in the sequence.
- `AnyNotNone`: return a boolean indicating if the sequence contains any not `none` elements.

All these methods are also fitted with a predicate overload that can filter the sequence based on the provided predicate.

## Conclusion

This library is designed to streamline working with options in C#, providing robust support for functional programming paradigms.