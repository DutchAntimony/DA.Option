using DA.Options;

namespace Options.Tests;

public class OptionTestBase
{
    protected const string OptionValue = "abc";
    protected const int ValueOptionValue = 42;

    protected static readonly Option<string> SomeOption = OptionValue;
    protected static readonly Option<string> NoneOption = Option.None;
    protected static readonly ValueOption<int> SomeValueOption = ValueOptionValue;
    protected static readonly ValueOption<int> NoneValueOption = ValueOption.None;
    
    protected readonly Task<Option<string>> SomeOptionTask = Task.FromResult(SomeOption);
    protected readonly Task<ValueOption<int>> SomeValueOptionTask = Task.FromResult(SomeValueOption);
    
    protected readonly Task<Option<string>> NoneOptionTask = Task.FromResult(NoneOption);
    protected readonly Task<ValueOption<int>> NoneValueOptionTask = Task.FromResult(NoneValueOption);
}