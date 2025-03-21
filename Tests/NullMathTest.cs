namespace Sandbox.Tests;

public class NullMathTest : ISandboxTest
{
    public void Execute()
    {
        var testObj = new SomeClass();
        Console.WriteLine(testObj.TestField is null ? "null" : testObj.TestField);
        
        // subtract from null
        var someVar = testObj.TestField - 10;
        Console.WriteLine(someVar is null ? "null" : someVar);

        // Divide by zero
        someVar = testObj.TestField / 0; // null
        Console.WriteLine(someVar is null ? "null" : someVar);
        
        testObj.TestField = 30;
        someVar = testObj.TestField / 0; // throws DivideByZeroException
        Console.WriteLine(someVar is null ? "null" : someVar);
    }

    public class SomeClass
    {
        public int? TestField {get;set;}
    }
}
