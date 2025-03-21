namespace Sandbox.Tests;

public class MaxByTests: ISandboxTest
{
	public void Execute()
	{
        var testList = new List<TestClass>()
        {
            new() {SomeValue = 100, SomeString = "abc1"},
            new() {SomeValue = 20, SomeString = "abc2"},
            new() {SomeValue = 100, SomeString = "abc3"},
            new() {SomeValue = 30, SomeString = "abc4"},
            new() {SomeValue = 100, SomeString = "abc5"},
        };

        var maxValue = testList.MaxBy(x => x.SomeValue);
        Console.WriteLine(maxValue);
	}

    public record TestClass
    {
        public required int SomeValue {get;set;}
        public required string SomeString {get;set;}
    }
}